using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Db;
using borsvarlden.Models;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Services.Entities
{

    public interface IFinwireFilterService
    {

    }

    public class FinwireFilterService : IFinwireFilterService
    {
        private ApplicationContext _dbContext;

        public FinwireFilterService(ApplicationContext context)
        {
            _dbContext = context;
        }

        public bool IsFilterPassed(FinWireData finwireData)
        {
            return IsTitleWhiteListPassed(finwireData.Title);   
        }

        public bool IsTitleWhiteListPassed(string title)
        {
            return IsTagWhitelistFilterPassed(EnumFinwireFilterTypes._01_TitleWhitelist, title);
        }

        public bool IsTagBlackFilterNotPassed(string title)
        {
            return IsTagBlackFilterNotPassed(EnumFinwireFilterTypes._02_TitleBlackList, title);
        }

        private bool IsTagWhitelistFilterPassed(EnumFinwireFilterTypes type, string value)
        {
            return Contains(type, value);
        }

        

        private bool IsTagBlackFilterNotPassed(EnumFinwireFilterTypes type, string value)
        {
            return Contains(type, value);
        }

        private bool Contains(EnumFinwireFilterTypes filterType, string value)
        {
            return _dbContext.FinwireFilters.Any(x =>
                x.FinwireFilterType == filterType && x.Value.ToLower() == value.ToLower());
        }
    }
}
