using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpPostmeta
    {
        public long MetaId { get; set; }
        public long PostId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
