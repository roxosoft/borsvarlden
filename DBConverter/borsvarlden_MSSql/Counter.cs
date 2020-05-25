using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class Counter
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
