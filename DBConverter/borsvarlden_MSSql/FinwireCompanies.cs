using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireCompanies
    {
        public FinwireCompanies()
        {
            FinwireNew2FinwireCompany = new HashSet<FinwireNew2FinwireCompany>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public int? FinwireAgencyId { get; set; }

        public virtual FinwireAgencies FinwireAgency { get; set; }
        public virtual ICollection<FinwireNew2FinwireCompany> FinwireNew2FinwireCompany { get; set; }
    }
}
