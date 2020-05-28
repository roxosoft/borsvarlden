using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclStringPackages
    {
        public long Id { get; set; }
        public string KindSlug { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string EditLink { get; set; }
        public string ViewLink { get; set; }
        public int? PostId { get; set; }
        public string WordCount { get; set; }
    }
}
