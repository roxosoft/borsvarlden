using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireFilters
    {
        public int Id { get; set; }
        public short FinwireFilterType { get; set; }
        public string Value { get; set; }
    }
}
