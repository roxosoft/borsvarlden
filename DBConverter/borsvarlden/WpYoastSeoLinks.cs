using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpYoastSeoLinks
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long PostId { get; set; }
        public long TargetPostId { get; set; }
        public string Type { get; set; }
    }
}
