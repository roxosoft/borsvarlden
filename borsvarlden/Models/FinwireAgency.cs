using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class FinwireAgency
    {
        public int Id { get; set; }
        public string Agency { get; set; }
        public List<FinwireCompany> FinwireCompanies { get; set; }
    }
}
