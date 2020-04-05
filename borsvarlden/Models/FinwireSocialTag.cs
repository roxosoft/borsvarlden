using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class FinwireSocialTag
    {
        public int Id { get; set; }
        public string Tag { get; set;}
        public List<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTags { get; set; }
    }
}
