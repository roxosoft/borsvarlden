using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfblocks7
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public byte[] Ip { get; set; }
        public long BlockedTime { get; set; }
        public string Reason { get; set; }
        public int? LastAttempt { get; set; }
        public int? BlockedHits { get; set; }
        public long Expiration { get; set; }
        public string Parameters { get; set; }
    }
}
