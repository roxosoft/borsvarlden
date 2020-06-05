using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using borsvarlden.Db;
using borsvarlden.Models;

namespace borsvarlden.Services.Entities
{
    public interface IFinwireCompaniesService
    {
        FinwireNew JoinCompanies(FinwireNew finwireNew, List<string> companies);
    }

    public class FinwireCompaniesService : IFinwireCompaniesService
    {
        private ApplicationContext _dbContext;

        public FinwireCompaniesService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

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
    }
}
