using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfstatus
    {
        public long Id { get; set; }
        public double Ctime { get; set; }
        public byte Level { get; set; }
        public string Type { get; set; }
        public string Msg { get; set; }
    }
}
