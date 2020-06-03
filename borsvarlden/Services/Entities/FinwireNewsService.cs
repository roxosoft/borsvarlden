﻿using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using borsvarlden.Db;
 using borsvarlden.Helpers;
 using borsvarlden.Models;
 using borsvarlden.Services.Finwire;
 using borsvarlden.ViewModels;
 using DevExtreme.AspNet.Data;
 using DevExtreme.AspNet.Data.ResponseModel;
 using DevExtreme.AspNet.Mvc;
 using Microsoft.AspNetCore.Hosting;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.ChangeTracking;

 namespace borsvarlden.Services.Entities
{
    public interface IFinwireNewsService
    {
        void AddSingleNews(FinWireData finwireData);
        Task<IndexNewsViewModel> GetMainNews(int newsCount);
        Task<List<NewsViewModel>> GetNews(int newsCount);
        Task<NewsViewModel> GetDetailedArticle(int articleId);
        Task<PaggingSearchResponseViewModel<NewsViewModel>> GetNewsSearchPagging(int newsOnPageCount, int nextPage, string searchText);
        Task<NewsViewModel> GetDetailedArticle(string titleSlug);

        Task<LoadResult> GetNewsList(DataSourceLoadOptions options);
        Task<FinwireNew> GetArticle(int id);
        Task AddArticle(FinwireNew article);
        Task UpdateArticle(FinwireNew article);
        Task DeleteArticle(int id);
        Task<List<NewsViewModel>> GetRelatedNews(int id, int newsCount);
    }

    public class FinwireNewsService : IFinwireNewsService
    {
        private ApplicationContext _dbContext;
        private IFinwireFilterService _finwireFilterService;
        private readonly string _webRootPath;
        private string _imagesRootPath => $@"{_webRootPath}\assets\images\finauto";

        public FinwireNewsService(ApplicationContext dbContext, IFinwireFilterService finwireNewsService, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _finwireFilterService = finwireNewsService;
            _webRootPath = hostEnvironment.WebRootPath;
            ImageHelper.Init(_imagesRootPath);
        }

        public void AddSingleNews(FinWireData finwireData)
        {
            if (_dbContext.FinwireNews.Any(x => finwireData.Guid == x.Guid))
                return;

            if (!_finwireFilterService.IsFilterPassed(finwireData))
                return;

            var imgData = ImageHelper.GetImageData(finwireData.SocialTags, finwireData.Companies);
            
            var newsEntity = new FinwireNew()
            {
                Guid = finwireData.Guid,
                Title = finwireData.Title,
                Subtitle = finwireData.SubTitle,
                Date = finwireData.Date,
                NewsText = finwireData.HtmlText,
                FinwireAgency = _dbContext.FinwireAgencies.FirstOrDefault(x => x.Agency == finwireData.Agency)
                            ?? _dbContext.Add(new FinwireAgency {Agency = finwireData.Agency}).Entity,
                ImageRelativeUrl = ImageHelper.AbsoluteUrlToRelativeUrl(imgData.ImageAbsoluteUrl),
                ImageLabel = imgData.Label,
                Slug = finwireData.TittleSlug
            };

            var newsEntityAdded = _dbContext.Add(newsEntity).Entity;

            //todo make generic method in helper etc, find better solution using EF Core
            finwireData.SocialTags?.ForEach(x =>
                _dbContext.Add(new FinwireNew2FirnwireSocialTag
                {
                    FinwireNew = newsEntityAdded,
                FinwireSocialTag = _dbContext.FinwireSocialTags.FirstOrDefault(y => y.Tag == x)
                                   ?? _dbContext.Add(new FinwireSocialTag {Tag = x}).Entity
                })
            );

            finwireData.Companies?.ForEach(x =>
            {
                _dbContext.Add(new FinwireNew2FinwireCompany
                {
                    FinwireNew = newsEntityAdded,
                    FinwireCompany = _dbContext.FinwireCompanies.FirstOrDefault(y => y.Company == x)
                                 ?? _dbContext.Add(new FinwireCompany {Company = x}).Entity
                });
            });

            _dbContext.SaveChanges();
        }

        public async Task<IndexNewsViewModel> GetMainNews(int newsCount)
        {
            var result = new IndexNewsViewModel();
            List<FinwireNew> newsList = await _dbContext.FinwireNews.OrderByDescending(x => x.Date).Take(newsCount).ToListAsync();
            result.News = MapFinwireNewToViewModel(newsList);

            return result;
        }

        public async Task<List<NewsViewModel>> GetNews(int newsCount)
        {
            List<FinwireNew> newsList = await _dbContext.FinwireNews.OrderByDescending(x => x.Date).Take(newsCount).ToListAsync();
            var result = MapFinwireNewToViewModel(newsList);
            return result;
        }

        public async Task<List<NewsViewModel>> GetRelatedNews(int id, int newsCount)
        {
            return await Task.Run(
                () =>
                {
                    var companiesOfNews = _dbContext.FinwireNews
                        .Where(x => x.Id == id)
                        .Include(x => x.FinwireNew2FinwireCompanies)
                        .FirstOrDefault()
                        ?.FinwireNew2FinwireCompanies
                        .Select(x => x.FinwareCompanyId);
                    
                    var newsIdWithCompanies = _dbContext.FinwireNew2FinwireCompany
                        .Where(x => companiesOfNews.Contains(x.FinwareCompanyId) && x.FinwireNewId != id)
                        .Select(x => x.FinwireNewId);

                    var relatedNewsWithCompanies = _dbContext.FinwireNews
                        .Where(x => newsIdWithCompanies.Contains(x.Id))
                        .OrderByDescending(x => x.Date)
                        .Take(newsCount);

                    var socialTagsOfNews = _dbContext.FinwireNews
                        .Where(x => x.Id == id)
                        .Include(x => x.FinwireNew2FirnwireSocialTags)
                        .FirstOrDefault()
                        ?.FinwireNew2FirnwireSocialTags
                        .Select(x => x.FinwireSocialTagId);

                    var newsIdWithSocialTags = _dbContext.FinwireNew2FirnwireSocialTag
                        .Where(x => socialTagsOfNews.Contains(x.FinwireSocialTagId) && x.FinwireNewId != id)
                        .Select(x => x.FinwireNewId);

                    var relatedNewsWithSocialTags = _dbContext.FinwireNews
                        .Where(x => newsIdWithSocialTags.Contains(x.Id))
                        .OrderByDescending(x => x.Date)
                        .Take(newsCount);

                    var rs = relatedNewsWithCompanies
                        .Union(relatedNewsWithSocialTags)
                        .OrderByDescending(x=>x.Date)
                        .Take(newsCount)
                        .ToList();

                    return MapFinwireNewToViewModel(rs); 
                });
        }

        public async Task<PaggingSearchResponseViewModel<NewsViewModel>> GetNewsSearchPagging(int newsOnPageCount, int nextPage, string searchText)
        {
            var result = new PaggingSearchResponseViewModel<NewsViewModel>();
            var query = _dbContext.FinwireNews.OrderByDescending(x => x.Date).AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.Title.Contains(searchText));
            }

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
        public async Task AddArticle(FinwireNew article)
        {
            article.DateModified = DateTime.UtcNow;

            _dbContext.Entry(article).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateArticle(FinwireNew article)
        {
            article.DateModified = DateTime.UtcNow;
            
            _dbContext.Entry(article).State = EntityState.Modified;
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

        private List<NewsViewModel> MapFinwireNewToViewModel(List<FinwireNew> news)
        {
            var result = new List<NewsViewModel>();
           

            foreach (var newsItem in news)
            {
                var subtitle = newsItem.Subtitle; 
                var subtitleMaxLength = 140;

                if (subtitle.Length >= subtitleMaxLength)
                {
                    var index = subtitle.LastIndexOf(' ', subtitleMaxLength - 1);
                    subtitle = subtitle.Substring(0, index) + "...";
                }

                var articleModel = new NewsViewModel()
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Subtitle = subtitle,
                    Date = newsItem.Date,
                    NewsText = newsItem.NewsText,
                    ImageUrl = newsItem.ImageRelativeUrl,
                    Label = newsItem.ImageLabel,
                    TittleSlug = newsItem.Slug
                };
                result.Add(articleModel);
            }

            return result;
        }

       // private void GetNew

    }
}
