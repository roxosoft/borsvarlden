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

    public interface IFinwireCompaniesService
    {
        FinwireNew JoinCompanies(FinwireNew finwireNew, List<string> companies);
        Task<LoadResult> GetCompanies(DataSourceLoadOptions loadOptions);
        Task<List<string>> GetCompaniesByFinwireNewsId(int id);
        Task AddCompanyToNews(int newsId, string company);
        Task DeleteCompaniesForeNews(int newsId, string companiesList);
        Task<List<FinwireCompany>> GetListFinwireCompaniesByLetter(string letter);
        Task<LoadResult> GetListFinwireCompanies(DataSourceLoadOptions options);
        Task UpdateCompany(FinwireCompany company);
        Task<FinwireCompany> GetFinwireCompany(int id);
        Task<FinwireCompany> GetFinwireCompany(string slug);
        Task GenCompaniesSlug();
    }

    public class FinwireCompaniesService : IFinwireCompaniesService
    {
        private ApplicationContext _dbContext;

        public FinwireCompaniesService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task <FinwireCompany> GetFinwireCompany(int id)
        {
            return await _dbContext.FinwireCompanies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FinwireCompany> GetFinwireCompany(string slug)
            => await _dbContext.FinwireCompanies.FirstOrDefaultAsync(x => x.Slug == slug);
        
        public FinwireNew JoinCompanies(FinwireNew finwireNew, List<string> companies)
        {
            //todo check companies null case !!!!!
            if (finwireNew != null)
            {

                _dbContext.FinwireCompanies.Where(x => companies.Contains(x.Company))
                    ?.Include(x => x.FinwireNew2FinwireCompanies);
                    
                return finwireNew;
            }
            else
                return finwireNew;
                //?.Join(_dbContext.FinwireCompanies, x=>x.Id, x=>x.

        }

        public async Task<LoadResult> GetCompanies(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_dbContext.FinwireCompanies.OrderBy(x=>x.Company).Select(x=>x.Company), loadOptions);
        }

        public async Task GenCompaniesSlug()
        {
            await _dbContext.FinwireCompanies.ForEachAsync(x => x.Slug = x.Company.ToSlug());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FinwireCompany>> GetListFinwireCompaniesByLetter(string letter)
        {
            return await _dbContext.FinwireCompanies
                .Where(x => x.Company.Substring(0,1) == letter)
                .OrderBy(x=>x.Company)
                .ToListAsync();
        }

        public async Task<LoadResult> GetListFinwireCompanies(DataSourceLoadOptions options)
        {
            return await DataSourceLoader.LoadAsync(_dbContext.FinwireCompanies, options);
        }

        public async Task<List<string>> GetCompaniesByFinwireNewsId(int id)
        {
            return await _dbContext.FinwireNew2FinwireCompany
                .Where(x=>x.FinwireNewId == id)
                .Include(x=>x.FinwireCompany)
                .OrderBy(x=>x.FinwireCompany.Company)
                .Select(x=>x.FinwireCompany.Company)
                .ToListAsync();
        }

        public async Task AddCompanyToNews(int newsId, string company)
        {
            var finwireCompany = _dbContext.FinwireCompanies.FirstOrDefault(x => x.Company == company);

            _dbContext.FinwireNew2FinwireCompany.Add(new FinwireNew2FinwireCompany
            {
                FinwireCompany = finwireCompany, 
                FinwireNewId = newsId
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCompaniesForeNews(int newsId, string companiesList)
        {
            var companies = companiesList.Split(',').ToList();

            var entitiesToRemove = (await _dbContext.FinwireNews.Where(x => x.Id == newsId).Include(x => x.FinwireNew2FinwireCompanies)
                                           .ThenInclude(y => y.FinwireCompany).Select(y => y.FinwireNew2FinwireCompanies).ToListAsync())
                .FirstOrDefault()
                ?.Where(x => companies.Contains(x.FinwireCompany.Company))
                .ToList();

            _dbContext.FinwireNew2FinwireCompany.RemoveRange(entitiesToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCompany(FinwireCompany company)
        {
            _dbContext.Entry(company).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
