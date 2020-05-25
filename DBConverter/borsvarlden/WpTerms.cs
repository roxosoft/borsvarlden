using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpTerms
    {
        public long TermId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long TermGroup { get; set; }
    }
}
