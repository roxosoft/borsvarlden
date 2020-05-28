using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireAgencies
    {
        public FinwireAgencies()
        {
            FinwireCompanies = new HashSet<FinwireCompanies>();
            FinwireNews = new HashSet<FinwireNews>();
        }

        public int Id { get; set; }
        public string Agency { get; set; }

        public virtual ICollection<FinwireCompanies> FinwireCompanies { get; set; }
        public virtual ICollection<FinwireNews> FinwireNews { get; set; }
    }
}
