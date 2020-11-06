﻿using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using borsvarlden.Db;
 using borsvarlden.Helpers;
 using borsvarlden.Models;
 using borsvarlden.Services.Finwire;
 using borsvarlden.ViewModels;
 using borsvarlden.Extensions;
 using DevExtreme.AspNet.Data;
 using DevExtreme.AspNet.Data.ResponseModel;
 using DevExtreme.AspNet.Mvc;
 using Microsoft.AspNetCore.Hosting;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace borsvarlden.Services.Entities
{
    public interface IFinwireNewsService
    {
        Task AddSingleNews(FinWireData finwireData);
        Task<IndexNewsViewModel> GetMainNewsForFeeding(int newsCount);
        Task<List<NewsViewModel>> GetNews(int newsCount);
        Task<NewsViewModel> GetDetailedArticle(int articleId);
        Task<PaggingSearchResponseViewModel<NewsViewModel>> GetNewsSearchPaging(int newsOnPageCount, int nextPage, string searchText, bool only15MinutesVideo);
        Task<NewsViewModel> GetDetailedArticle(string titleSlug);
        Task<NewsViewModel> GetDetailedArticleByGuid(string guid);
        Task<List<FinwireNew>> GetNewsForFeedingWithPrio(int count);
        Task<LoadResult> GetNewsList(DataSourceLoadOptions options);
        Task<FinwireNew> GetArticle(int id);
        Task AddArticle(FinwireNew article, List<CompanyCommon> lstCompanies);
        Task UpdateArticle(FinwireNew article, List<CompanyCommon> lstCompanies);
        Task DeleteArticle(int id);
        Task<List<NewsViewModel>> GetRelatedNews(NewsViewModel newsView, int newsCount);
        Task<List<NewsViewModel>> GetMoreNews(int id);
        Task UpdateReadCount(string slug);
        Task<List<NewsViewModel>> GetMostReadNews(int count, int id);
        Task<List<NewsViewModel>> GetAdvertiseNewsList(int newsCount);
        Task<List<FinwireNew>> GetFinwireNewWithCompany(int id);
        Task<IndexNewsViewModel> GetHotStocksForFeeding(int newsCount);
    }

    public class FinwireNewsService : IFinwireNewsService
    {
        private ApplicationContext _dbContext;
        private IFinwireFilterService _finwireFilterService;
        private readonly string _webRootPath;
        private string _imagesRootPath => $@"{_webRootPath}\assets\images\finauto";
        private string _imagesUploadRootPath => $@"{_webRootPath}\assets\uploads";
        private string _imagesAzureUploadRootPath => $@"uploads/";
        private static Random rndGen = new Random();

        public FinwireNewsService(ApplicationContext dbContext, IFinwireFilterService finwireNewsFilterService, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _finwireFilterService = finwireNewsFilterService;
            _webRootPath = hostEnvironment.WebRootPath;
            ImageHelper.Init(_imagesRootPath);
        }

        public async Task AddSingleNews(FinWireData finwireData)
        {
            var finwireXmlNewsAdded = await _dbContext.FinwireXmlNews.AddAsync(new FinwireXmlNews
                {
                    DateTime = DateTime.Now,
                    FileContent = finwireData.RoughXml,
                    FileName = finwireData.Guid,
                });

                if (!_dbContext.FinwireNews.Any(x => finwireData.Guid == x.Guid))
                {
                    var newsEntity = finwireData.ToFinwireNews();
                    newsEntity.FinautoPassed =  _finwireFilterService.IsFilterPassed(finwireData);

                    newsEntity.FinwireAgency =
                        _dbContext.FinwireAgencies.FirstOrDefault(x => x.Agency == finwireData.Agency)
                        ?? (await _dbContext.AddAsync(new FinwireAgency {Agency = finwireData.Agency})).Entity;

                    newsEntity.FinwireXmlNews = finwireXmlNewsAdded.Entity;

                    var newsEntityAdded = (await _dbContext.AddAsync(newsEntity)).Entity;
                  
                    //todo make generic method in helper etc, find better solution using EF Core
                    finwireData.SocialTags?.ForEach(async x =>
                        await _dbContext.AddAsync(new FinwireNew2FirnwireSocialTag
                        {
                            FinwireNew = newsEntityAdded,
                            FinwireSocialTag = _dbContext.FinwireSocialTags.FirstOrDefault(y => y.Tag == x)
                                               ?? (await _dbContext.AddAsync(new FinwireSocialTag {Tag = x})).Entity
                        })
                    );

                    finwireData.Companies?.ForEach(async x =>
                    {
                        await _dbContext.AddAsync(new FinwireNew2FinwireCompany
                        {
                            FinwireNew = newsEntityAdded,
                            FinwireCompany = _dbContext.FinwireCompanies.FirstOrDefault(y => y.Company == x)
                                             ?? (await _dbContext.AddAsync(new FinwireCompany {Company = x, Slug = x.ToSlug()})).Entity
                        });
                    });
                }

                await _dbContext.SaveChangesAsync();
        }

        public async Task<IndexNewsViewModel> GetMainNewsForFeeding(int newsCount)
        {
            var result = new IndexNewsViewModel();
            var newsList = await GetNewsForFeedingWithPrio(newsCount);
            result.News = MapFinwireNewToViewModel(newsList);
            var first = result.News.FirstOrDefault();
            if (first?.IsFinwireNews ?? false)
                first.IsTopFinwireNews = true;

            return result;
        }

        public async Task<IndexNewsViewModel> GetHotStocksForFeeding(int newsCount)
        {
            var result = new IndexNewsViewModel();
            var newsList = await GetHotStocks(newsCount).ToListAsync();
            result.News = MapFinwireNewToViewModel(newsList);

            return result;
        }

        public async Task<List<NewsViewModel>> GetAdvertiseNewsList(int newsCount)
        {
            return MapFinwireNewToViewModel(await GetActualNews().ToListAsync());
        }

        public async Task<List<NewsViewModel>> GetNews(int newsCount)
        {
            List<FinwireNew> newsList = await GetMainNewsListAsync(newsCount);
            var result = MapFinwireNewToViewModel(newsList);
            return result;
        }

        public async Task<List<NewsViewModel>> GetRelatedNews(NewsViewModel newsViewModel, int newsCount)
        {
            return await Task.Run(
                async () =>
                {
                    var listNewsOutput = new List<FinwireNew>();
                    if (newsViewModel.IsFinwireNews)
                    {
                          var companiesOfNews = _dbContext.FinwireNews
                              .Where(x => x.Id == newsViewModel.Id)
                              .Include(x => x.FinwireNew2FinwireCompanies)
                              .FirstOrDefault()
                              ?.FinwireNew2FinwireCompanies
                              .Select(x => x.FinwareCompanyId);

                          var newsIdWithCompanies = _dbContext.FinwireNew2FinwireCompany
                              .Where(x => companiesOfNews.Contains(x.FinwareCompanyId) &&
                                          x.FinwireNewId != newsViewModel.Id)
                              .Select(x => x.FinwireNewId);

                          var relatedNewsWithCompanies = _dbContext.FinwireNews
                              .Where(x => newsIdWithCompanies.Contains(x.Id) && x.IsFinwireNews)
                              .OrderByDescending(x => x.Date)
                              .Take(newsCount);

                          var socialTagsOfNews = _dbContext.FinwireNews
                              .Where(x => x.Id == newsViewModel.Id)
                              .Include(x => x.FinwireNew2FirnwireSocialTags)
                              .FirstOrDefault()
                              ?.FinwireNew2FirnwireSocialTags
                              .Select(x => x.FinwireSocialTagId);

                          var newsIdWithSocialTags = _dbContext.FinwireNew2FirnwireSocialTag
                              .Where(x => socialTagsOfNews.Contains(x.FinwireSocialTagId) &&
                                          x.FinwireNewId != newsViewModel.Id)
                              .Select(x => x.FinwireNewId);

                          var relatedNewsWithSocialTags = _dbContext.FinwireNews
                              .Where(x => newsIdWithSocialTags.Contains(x.Id) &&  x.IsFinwireNews)
                              .OrderByDescending(x => x.Date)
                              .Take(newsCount);

                          listNewsOutput = await relatedNewsWithCompanies
                              .Union(relatedNewsWithSocialTags)
                              .OrderByDescending(x => x.Date)
                              .Take(newsCount)
                              .ToListAsync();
                    }

                    return MapFinwireNewToViewModel(listNewsOutput);
                });
        }


        public async Task<List<NewsViewModel>> GetMoreNews(int id)
        {
            return await Task.Run(
                async () =>
                {
                    var paramOutputNews = 8;
                    var paramDepthOfRetrieve = 20;
                    var topNews = await GetMainNewsListAsync(paramDepthOfRetrieve);

                    int n = topNews.Count;
                    while (n > 1)
                    {
                        n--;
                        int k = rndGen.Next(n + 1);
                        var value = topNews[k];
                        topNews[k] = topNews[n];
                        topNews[n] = value;
                    }

                    return MapFinwireNewToViewModel(topNews.Take(paramOutputNews).ToList());
                }
            );
        }

        public async Task<PaggingSearchResponseViewModel<NewsViewModel>> GetNewsSearchPaging(int newsOnPageCount, int nextPage, string searchText, bool only15MinutesVideo)
        {
            var result = new PaggingSearchResponseViewModel<NewsViewModel>();
            var query = string.IsNullOrEmpty(searchText) ? GetNonBorsvarldenArticles() : GetAllArticles();
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.Title.Contains(searchText));
            }

            if (only15MinutesVideo)
                query = query.Where(x => x.Is15MinutesVideo);


            List<FinwireNew> newsList = await query.Skip(newsOnPageCount * (nextPage - 1)).Take(newsOnPageCount).ToListAsync();

            result.TotalCount = await query.CountAsync();

            result.Data = MapFinwireNewToViewModel(newsList);
            result.CurrentPage = nextPage;
            result.ItemsOnPageCount = newsOnPageCount;
            result.SearchText = searchText;

            return result;
        }

        public async Task<NewsViewModel> GetDetailedArticle(int articleId)
        {
            List<FinwireNew> article = await _dbContext.FinwireNews
                .Where(x => x.Id == articleId)
                .ToListAsync();
            var result = MapFinwireNewToViewModel(article).FirstOrDefault();
            return result;
        }

        public async Task<NewsViewModel> GetDetailedArticle(string titleSlug)
        {
            List<FinwireNew> article = await _dbContext.FinwireNews
                .Where(x => x.Slug == titleSlug)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
            var result = MapFinwireNewToViewModel(article).FirstOrDefault();
            return result;
        }

        public async Task<NewsViewModel> GetDetailedArticleByGuid(string guid)
        {
            List<FinwireNew> article = await _dbContext.FinwireNews
                .Where(x => x.Guid == guid)
                .ToListAsync();
            var result = MapFinwireNewToViewModel(article).FirstOrDefault();
            return result;
        }
        
        public async Task<LoadResult> GetNewsList(DataSourceLoadOptions options)
        {
            var result = await DataSourceLoader.LoadAsync(_dbContext.FinwireNews, options);

            return result;
        }

        /// <inheritdoc />
        public async Task<FinwireNew> GetArticle(int id)
        {
            var result = await _dbContext.FinwireNews.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        /// <inheritdoc />
        public async Task AddArticle(FinwireNew article, List<CompanyCommon> lstCompanies)
        {
            article.DateModified = DateTime.UtcNow;
            if (article.ImageRelativeUrl != null && article.ImageRelativeUrl.Contains("blob.core", StringComparison.OrdinalIgnoreCase))
                article.IsUseAzureStorage = true;

            _dbContext.Entry(article).State = EntityState.Added;
            lstCompanies.ForEach(x =>
            {
                _dbContext.FinwireNew2FinwireCompany
                    .Add(new FinwireNew2FinwireCompany
                    {
                        FinwireNew = article, 
                        FinwireCompany = _dbContext.FinwireCompanies.Where(y=>y.Id == x.Id).FirstOrDefault()
                    });
            });


            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateArticle(FinwireNew article, List<CompanyCommon> lstCompanies)
        {
            article.DateModified = DateTime.UtcNow;
            if (article.ImageRelativeUrl.Contains("blob.core", StringComparison.OrdinalIgnoreCase))
                article.IsUseAzureStorage = true;

            _dbContext.Entry(article).State = EntityState.Modified;

            var companiesDB = _dbContext.FinwireNew2FinwireCompany
                .Where(x => x.FinwireNewId == article.Id)
                .Select(x => new CompanyCommon
                {
                    Id = x.FinwareCompanyId,
                    Company = x.FinwireCompany.Company
                }); 

            (await companiesDB.ToListAsync()).Except(lstCompanies, new CompanyCommonComparer()).ToList().ForEach(x =>
                _dbContext.FinwireNew2FinwireCompany
                    .Remove(_dbContext.FinwireNew2FinwireCompany.Where(y => y.FinwareCompanyId == x.Id).FirstOrDefault())); 

            lstCompanies.Except(companiesDB, new CompanyCommonComparer()).ToList().ForEach(x =>
            {
                var finwireCompany = _dbContext.FinwireCompanies.Where(y => x.Id == y.Id).FirstOrDefault();
                _dbContext.FinwireNew2FinwireCompany.Add(new FinwireNew2FinwireCompany
                    {FinwireCompany = finwireCompany, FinwireNew = article});
            });

          await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteArticle(int id)
        {
            var article = await GetArticle(id);

            if (article != null)
            {
                _dbContext.Entry(article).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateReadCount(string slug)
        {
            var rec = await _dbContext.FinwireNews
                .FirstOrDefaultAsync(x => x.Slug == slug);

            if (rec != null)
            {
                rec.ReadCount++;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task <List<NewsViewModel>> GetMostReadNews(int countNeed, int id)
        {
            var parDeptDays = 1;
            var lstFinwirewNews = new List<FinwireNew>();

            lstFinwirewNews = await _dbContext.FinwireNews
                .Where(x => x.FinautoPassed || x.IsBorsvarldenArticle)
                .Where(x => x.Date > DateTime.Now.AddDays(-parDeptDays) && x.Id != id)
                .OrderByDescending(x => x.ReadCount)
                .ThenByDescending(x => x.Date)
                .Take(countNeed)
                .ToListAsync();

            if (lstFinwirewNews.Count < countNeed)
            {
                var r = await _dbContext.FinwireNews
                    .Where(x => x.FinautoPassed || x.IsBorsvarldenArticle)
                    .Where(x => x.Id != id)
                    .OrderByDescending(x => x.Date)
                    .Take(countNeed)
                    .ToListAsync();

               lstFinwirewNews.AddRange(r);
               lstFinwirewNews = lstFinwirewNews.Distinct()
                   .Take(countNeed)
                   .ToList();
            }

            return MapFinwireNewToViewModel(lstFinwirewNews);
        }
        
        public async Task<List<FinwireNew>> GetNewsForFeedingWithPrio(int count)
        {
            var prioNews = await GetPrioNews().ToListAsync();
            var nonBorsvarldenArticles = await GetNonBorsvarldenArticles(count).ToListAsync();
            prioNews.AddRange(nonBorsvarldenArticles);
            var res = prioNews.Take(count).ToList();
            var firstFinwire = res.FirstOrDefault(x => !x.IsBorsvarldenArticle);

            if (firstFinwire != null)
            {
                var ind = res.IndexOf(firstFinwire);
                res.Insert(0, firstFinwire);
                res.RemoveAt(ind + 1);
            }

            return res;
        }

        private IQueryable<FinwireNew> GetNonBorsvarldenArticles()
        {
            return _dbContext.FinwireNews
                .Where(x => !x.IsBorsvarldenArticle && x.FinautoPassed)
                .OrderByDescending(x => x.Date);
        }

        private IQueryable<FinwireNew> GetHotStocks()
            =>  _dbContext.FinwireNews
                .Where(x => x.IsHotStocks && x.IsPublished)
                .OrderByDescending(x => x.Date);

        private IQueryable<FinwireNew> GetAllArticles()
            => _dbContext.FinwireNews
                .Where(x => x.FinautoPassed || (x.IsBorsvarldenArticle && x.IsPublished))
                .OrderByDescending(x => x.Date);

        private IQueryable<FinwireNew> GetNonBorsvarldenArticles(int count)
        {
            return GetNonBorsvarldenArticles()
                .Take(count);
        }

        private IQueryable<FinwireNew> GetHotStocks(int count)
            => GetHotStocks().Take(count);

        private IQueryable<FinwireNew> GetActualNews()
        {
            return _dbContext.FinwireNews
                .Where(x => x.IsBorsvarldenArticle && x.IsPublished && TimeHelper.Time < x.ActualDeadLine && x.DateStartVisible <= TimeHelper.Time && x.DateStartVisible >= default(DateTime))
                .OrderByDescending(x => x.Date);
        }

        private IQueryable<FinwireNew> GetPrioNews()
        {
            return _dbContext.FinwireNews
                .Where(x => x.IsBorsvarldenArticle && x.IsPublished && TimeHelper.Time < x.PrioDeadLine && x.DateStartVisible <= TimeHelper.Time && x.DateStartVisible >= default(DateTime))
                .OrderBy(x => x.Order)
                .ThenBy(x => x.Date);
        }


        private List<NewsViewModel> MapFinwireNewToViewModel(List<FinwireNew> news)
        {
            var result = new List<NewsViewModel>();

            foreach (var newsItem in news)
            {
                var articleModel = newsItem.ToNewsViewModel();
                result.Add(articleModel);
            }

            return result;
        }

        private IQueryable<FinwireNew> GetMainNews()
        {
            return _dbContext.FinwireNews
                .Where(x => x.FinautoPassed || x.IsBorsvarldenArticle && x.IsPublished)
                .OrderByDescending(x => x.Date);
        }

        private IQueryable<FinwireNew> GetMainNews(int newsCount)
        {
            return GetMainNews()
                .Take(newsCount);
        }

        private async Task<List<FinwireNew>> GetMainNewsListAsync(int newsCount)
        {
            return  await GetMainNews(newsCount).ToListAsync();
        }

        public async Task<List<FinwireNew>> GetFinwireNewWithCompany(int id)
        {
            return await _dbContext.FinwireNews
                .Include(x => x.FinwireNew2FinwireCompanies)
                .ThenInclude(x => x.FinwireCompany)
                .Where(x => x.FinwireNew2FinwireCompanies.Any(y => y.FinwareCompanyId == id))
                .OrderByDescending(x=>x.Date)
                .ToListAsync();
        }
    }

   

}
