using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpFinwireNews
    {
        public long Id { get; set; }
        public string Guid { get; set; }
        public string File { get; set; }
        public string Title { get; set; }
        public byte? FinautoPassed { get; set; }
        public byte FinautoPublished { get; set; }
        public DateTime Published { get; set; }
    }
}
