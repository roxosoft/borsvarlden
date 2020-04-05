using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class FinwireNew2FirnwireSocialTag
    {
        public int FinwireNewId { get; set; }
        public FinwireNew FinwireNew { get; set; }
        public int FinwireSocialTagId { get; set; }
        public FinwireSocialTag FinwireSocialTag { get; set; }
    }
}
