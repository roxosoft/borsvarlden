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
                UpdateSingleNews(finwireData);
               
            }
        }

        public void UpdateSingleNews(FinWireData finwireData)
        {
            var newsEntity = new FinwireNew();

            var socialTagsFound = new List<FinwireSocialTag>();

            if (finwireData.SocialTags.Count > 1)
                System.Threading.Thread.Sleep(100);

            //todo make generic method in helper etc, find better solution using EF Core
            finwireData.SocialTags.ForEach(x =>
            {
                FinwireSocialTag socialTag = _dbContext.FinwireSocialTags.FirstOrDefault(y => y.Tag == x);
                //not exist
                if (socialTag == null)
                    socialTag = _dbContext.Add(new FinwireSocialTag { Tag = x }).Entity;

                socialTagsFound.Add(socialTag);
            });

            var newsEntityAdded = _dbContext.Add(newsEntity).Entity;

            socialTagsFound.ForEach(el => _dbContext.Add(new FinwireNew2FirnwireSocialTag
            {
                FinwireNew = newsEntityAdded,
                FinwireSocialTag = el
            }));

            var finwireCompaniesFound = new List<FinwireCompany>();

            finwireData.Companies?.ForEach(x =>
            {
                FinwireCompany finwireCompany = _dbContext.FinwireCompanies.FirstOrDefault(y => y.Company == x);
                //not exist
                if (finwireCompany == null)
                    finwireCompany = _dbContext.Add(new FinwireCompany { Company = x }).Entity;

                finwireCompaniesFound.Add(finwireCompany);
            });

              

            finwireCompaniesFound.ForEach(el => _dbContext.Add(new FinwireNew2FinwireCompany
            {
                FinwireNew = newsEntityAdded,
                FinwireCompany = el
            }));

            if (finwireCompaniesFound.Count > 0)
                System.Threading.Thread.Sleep(1000);

            _dbContext.SaveChanges();
        }
    }
}
