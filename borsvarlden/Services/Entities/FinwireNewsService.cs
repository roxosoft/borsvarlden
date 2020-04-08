using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Db;
using borsvarlden.Models;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Services.Entities
{
    public interface IFinwireNewsService
    {
        void AddSingleNews(FinWireData finwireData);
    }

    public class FinwireNewsService : IFinwireNewsService
    {
        private ApplicationContext _dbContext;
        private IFinwireFilterService _finwireFilterService;

        public FinwireNewsService(ApplicationContext dbContext, IFinwireFilterService finwireNewsService)
        {
            _dbContext = dbContext;
            _finwireFilterService = finwireNewsService;
        }

        public void AddSingleNews(FinWireData finwireData)
        {
            if (_dbContext.FinwireNews.Any(x => finwireData.Guid == x.Guid))
                return;

            

            var newsEntity = new FinwireNew()
            {
                Guid = finwireData.Guid,
                Title = finwireData.Title,
                Date = finwireData.Date,
                NewsText = finwireData.NewsText,
                FinwireAgency = _dbContext.FinwireAgencies.FirstOrDefault(x => x.Agency == finwireData.Agency)
                            ?? _dbContext.Add(new FinwireAgency {Agency = finwireData.Agency}).Entity

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
    }
}
