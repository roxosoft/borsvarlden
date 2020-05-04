﻿using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using borsvarlden.Areas.Admin.ViewModels;
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
                NewsText = finwireData.NewsText,
                FinwireAgency = _dbContext.FinwireAgencies.FirstOrDefault(x => x.Agency == finwireData.Agency)
                            ?? _dbContext.Add(new FinwireAgency {Agency = finwireData.Agency}).Entity,
                ImageRelativeUrl = ImageHelper.AbsoluteUrlToRelativeUrl(imgData.ImageAbsoluteUrl),
                ImageLabel = imgData.Label,
                TittleSlug = _dbContext.Add(new TittleSlug {Slug = finwireData.TittleSlug}).Entity
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
            List<FinwireNew> newsList = await _dbContext.FinwireNews.Include(m => m.TittleSlug).OrderByDescending(x => x.Date).Take(newsCount).ToListAsync();
            result.News = MapFinwireNewToViewModel(newsList);

            return result;
        }

        public async Task<List<NewsViewModel>> GetNews(int newsCount)
        {
            List<FinwireNew> newsList = await _dbContext.FinwireNews.Include(m => m.TittleSlug).OrderByDescending(x => x.Date).Take(newsCount).ToListAsync();
            var result = MapFinwireNewToViewModel(newsList);
            return result;
        }

        public async Task<PaggingSearchResponseViewModel<NewsViewModel>> GetNewsSearchPagging(int newsOnPageCount, int nextPage, string searchText)
        {
            var result = new PaggingSearchResponseViewModel<NewsViewModel>();
            var query = _dbContext.FinwireNews.Include(m => m.TittleSlug).OrderByDescending(x => x.Date).AsQueryable();

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
                .Include(m => m.TittleSlug)
                .Where(x => x.Id == articleId)
                .ToListAsync();
            var result = MapFinwireNewToViewModel(article).FirstOrDefault();
            return result;
        }

        public async Task<NewsViewModel> GetDetailedArticle(string titleSlug)
        {
            List<FinwireNew> article = await _dbContext.FinwireNews
                .Include(m =>m.TittleSlug)
                .Where(x => x.TittleSlug.Slug == titleSlug)
                .ToListAsync();
            var result = MapFinwireNewToViewModel(article).FirstOrDefault();
            return result;
        }
        
        public async Task<LoadResult> GetNewsList(DataSourceLoadOptions options)
        {
            var r = await DataSourceLoader.LoadAsync(_dbContext.FinwireNews, options);
            return r;
            
            // var result = await _dbContext.FinwireNews.Select(c => new ArticleInListViewModel
            //     {
            //         Id = c.Id,
            //         Title = c.Title,
            //         Date = c.Date,
            //         ImageUrl = c.ImageRelativeUrl
            //     }).ToListAsync();
            //
            // return result;
        }

        private List<NewsViewModel> MapFinwireNewToViewModel(List<FinwireNew> news)
        {
            var result = new List<NewsViewModel>();

            foreach (var newsItem in news)
            {
                var articleModel = new NewsViewModel()
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Subtitle = newsItem.Subtitle,
                    Date = newsItem.Date,
                    NewsText = newsItem.NewsText,
                    ImageUrl = newsItem.ImageRelativeUrl,
                    Label = newsItem.ImageLabel,
                    TittleSlug = newsItem.TittleSlug.Slug
                };
                result.Add(articleModel);
            }

            return result;
        }
    }
}
