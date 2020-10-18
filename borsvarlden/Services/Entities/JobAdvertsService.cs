using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;

namespace borsvarlden.Services.Entities
{
    using Db;
    using Models;
    using Extensions;

    public interface IJobAdvertsService
    {
        Task<LoadResult> GetListAsync(DataSourceLoadOptions options);
        Task CreateAsync(JobAdvert jobAdvert);
        Task DeleteAsync(int id);
        Task<JobAdvert> GetAsync(int id);
        Task<List<JobAdvert>> GetListAsync();
        Task UpdateAsync(JobAdvert jobAdvert);
    }

    public class  JobAdvertsService : IJobAdvertsService
    {
        private ApplicationContext _dbContext;

        public JobAdvertsService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoadResult> GetListAsync(DataSourceLoadOptions options)
            => await DataSourceLoader.LoadAsync(_dbContext.JobAdverts.OrderByDescending(x => x.DateCreated), options);

        public async Task<List<JobAdvert>> GetListAsync()
            => await _dbContext.JobAdverts.OrderByDescending(x => x.DateCreated).ToListAsync();

        public async Task<JobAdvert> GetAsync(int id)
             => await _dbContext.JobAdverts.FirstOrDefaultAsync(x => x.Id == id);

        public async Task DeleteAsync(int id)
        {
            _dbContext.Entry(await GetAsync(id)).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(JobAdvert jobAdvert)
        {
            jobAdvert.DateCreated = DateTime.UtcNow;

            if (jobAdvert.Logo != null && jobAdvert.Logo.Contains("blob.core", StringComparison.OrdinalIgnoreCase))
                jobAdvert.IsAzureStorage = true;

            await _dbContext.JobAdverts.AddAsync(jobAdvert);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobAdvert jobAdvert)
        {
            jobAdvert.DateModified = DateTime.UtcNow;
      
            if (jobAdvert.Logo!=null &&  jobAdvert.Logo.Contains("blob.core", StringComparison.OrdinalIgnoreCase))
                jobAdvert.IsAzureStorage = true;

            _dbContext.Entry(jobAdvert).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
