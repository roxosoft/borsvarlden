using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class FinwireNew
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string PathRelative { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string NewsText { get; set; }
    

        //todo with flags
        public bool FinautoPassed { get; set;}
        public bool FinautoPublished { get; set; }

        public FinwireAgency FinwireAgency { get; set; }

        public List<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTags { get; set; }
        public List<FinwireNew2FinwireCompany> FinwireNew2FinwireCompanies { get; set; }
    }
}
