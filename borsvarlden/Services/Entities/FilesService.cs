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

    public interface IFilesService
    {
        Task <List<File>> Get();
        Task<LoadResult> Get(DataSourceLoadOptions options);
        Task<File> Get(int id);
        Task Add(File file);
        Task Update(File file);
        Task Delete(int id);
        Task IncCountOfDownloads(int id);
    }

    public class FilesService : IFilesService
    {
        private ApplicationContext _dbContext;

        public FilesService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task <File>Get(int id)
            => await _dbContext.Files.FirstOrDefaultAsync(x => x.Id == id);
            
        public async Task<LoadResult> Get(DataSourceLoadOptions options)
        {
            return await DataSourceLoader.LoadAsync(_dbContext.Files, options);
        }

        public async Task<List<File>> Get()
            => await _dbContext
                .Files
                .OrderByDescending(x=>x.Id)
                .ToListAsync();

        public async Task Add(File file)
        {
            await _dbContext.AddAsync(file);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(File file)
        {
            _dbContext.Entry(file).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _dbContext.Entry(await Get(id)).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task IncCountOfDownloads(int id)
        {
            var file = await Get(id);
            file.CountOfDownloads++;
            _dbContext.Entry(file).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
