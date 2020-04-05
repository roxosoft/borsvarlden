using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class FinwireNew2FinwireCompany
    {
        public int FinwireNewId { get; set; }
        public FinwireNew FinwireNew { get; set; }
        public int FinwareCompanyId { get; set; }
        public FinwireCompany FinwireCompany { get; set; }

    }
}
