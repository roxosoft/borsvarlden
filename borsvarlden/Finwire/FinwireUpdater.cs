using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using borsvarlden.Models;
using borsvarlden.Helpers;
using borsvarlden.Db;

namespace borsvarlden.Finwire
{
    public class FinwireUpdater 
    {
        private ApplicationContext _dbContext;
        private IFinwireParser _parser;
      
        public FinwireUpdater(ApplicationContext dbContext, IFinwireParser parser)
        {
            _dbContext = dbContext;
            _parser = parser;

        }

        public  void Execute()
        {
            var pathBase = @"f:\cs_proj\roxosoft_borsvarlden\finwire_files\test\";

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}{i.ToString("D2")}";
                var finwireData = _parser.Parse(Directory.GetFiles(path)[0]);
                AddSingleNews(finwireData);
            }
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
                                ?? _dbContext.Add(new FinwireAgency { Agency = finwireData.Agency }).Entity

            };
            
            var newsEntityAdded = _dbContext.Add(newsEntity).Entity;

            //todo make generic method in helper etc, find better solution using EF Core
            finwireData.SocialTags.ForEach(x =>
                _dbContext.Add(new FinwireNew2FirnwireSocialTag
                {
                    FinwireNew = newsEntityAdded,
                    FinwireSocialTag = _dbContext.FinwireSocialTags.FirstOrDefault(y => y.Tag == x)
                                       ?? _dbContext.Add(new FinwireSocialTag { Tag = x }).Entity
                })
            );

            finwireData.Companies?.ForEach(x =>
            {
                _dbContext.Add(new FinwireNew2FinwireCompany
                {
                    FinwireNew = newsEntityAdded,
                    FinwireCompany = _dbContext.FinwireCompanies.FirstOrDefault(y => y.Company == x)
                                    ?? _dbContext.Add(new FinwireCompany { Company = x }).Entity
                });
            });

            _dbContext.SaveChanges();
        }
    }
}
