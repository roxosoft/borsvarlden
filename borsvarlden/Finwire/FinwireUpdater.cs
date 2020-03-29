using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Db;

namespace borsvarlden.Finwire
{
    public class FinwireUpdater 
    {
        private ApplicationContext _dbContext;

        public FinwireUpdater(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  void Execute()
        {
            _dbContext.FinwireSocialTags.Add(new Models.FinwireSocialTag {Tag = "foo"});
            _dbContext.SaveChanges();
        }
    }
}
