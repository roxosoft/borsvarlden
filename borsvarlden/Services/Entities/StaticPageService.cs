using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Db;
using borsvarlden.Models;
using Microsoft.EntityFrameworkCore;

namespace borsvarlden.Services.Entities
{
    using Models;
    using ViewModels;
    using Extensions;
    public interface IStaticPagesService
    {
        Task<List<StaticPageViewModel>> GetListAsync();
        Task<StaticPage> GetAsync(int id);
        Task UpdateAsync(StaticPage staticPage);
        Task<StaticPage> GetSplashAdPage();
    }

  
    public class StaticPageService: IStaticPagesService
{
        private readonly ApplicationContext _dbContext;
        public StaticPageService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StaticPageViewModel>> GetListAsync()
        {
            var lst = new List<StaticPageViewModel>();

            (await _dbContext.StaticPages.ToListAsync())
                .ForEach(x => lst.Add(x.ToViewModel()));

            return lst;
        }

        public async Task<StaticPage> GetAsync(int id)
        {
            return await _dbContext.StaticPages.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<StaticPage> GetSplashAdPage()
        {
            return await _dbContext.StaticPages
                .Where(x => x.StaticPageType == StaticPageType._001_SplashAd)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(StaticPage staticPage)
        {
            _dbContext.Entry(staticPage).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
