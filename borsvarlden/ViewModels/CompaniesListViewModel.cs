using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.ViewModels
{
    using borsvarlden.Models;
    public class CompaniesListViewModel
    {
        public List<FinwireCompany> CompaniesList { get; set; }
        public FinwireCompany CompanyInFocus { get; set; }
        public string Letter { get; set; }
    }
}
