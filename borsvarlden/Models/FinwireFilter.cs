using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class FinwireFilter
    {
        public int Id { get; set; }
        public EnumFinwireFilterTypes FinwireFilterType { get; set; }
        public string Value { get; set; }
    }

}
