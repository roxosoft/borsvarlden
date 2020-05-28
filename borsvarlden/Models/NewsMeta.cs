using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class NewsMeta
    {
        public int Id { get; set; }
        public int FinwireNewId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public FinwireNew FinwireNew { get; set; }
    }
}
