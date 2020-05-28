using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireNew2FinwireCompany
    {
        public int FinwireNewId { get; set; }
        public int FinwareCompanyId { get; set; }

        public virtual FinwireCompanies FinwareCompany { get; set; }
        public virtual FinwireNews FinwireNew { get; set; }
    }
}
