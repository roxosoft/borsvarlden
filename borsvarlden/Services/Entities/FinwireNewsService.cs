using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using borsvarlden.Db;
using borsvarlden.Models;
using borsvarlden.Services.Finwire;
using borsvarlden.ViewModels;

using borsvarlden.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace borsvarlden.Services.Entities
{
    public interface IFinwireNewsService
    {
        void AddSingleNews(FinWireData finwireData);
        Task<IndexNewsViewModel> GetMainNews(int newsCount);
        Task<List<NewsViewModel>> GetNews(int newsCount);
        Task<NewsViewModel> GetDetailedArticle(int articleId);
        Task<NewsViewModel> GetDetailedArticle(string titleSlug);
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

        private List<NewsViewModel> MapFinwireNewToViewModel(List<FinwireNew> news)
        {
            var result = new List<NewsViewModel>();

            foreach (var newsItem in news)
            {
                var articleModel = new NewsViewModel()
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
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
