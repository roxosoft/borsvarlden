using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class AggregatedCounter
    {
        public string Key { get; set; }
        public long Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
