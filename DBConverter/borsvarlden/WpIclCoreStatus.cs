using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclCoreStatus
    {
        public long Id { get; set; }
        public long Rid { get; set; }
        public string Module { get; set; }
        public string Origin { get; set; }
        public string Target { get; set; }
        public short Status { get; set; }
        public int TpRevision { get; set; }
        public string TsStatus { get; set; }
    }
}
