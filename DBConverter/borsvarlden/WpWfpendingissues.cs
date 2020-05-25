using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfpendingissues
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int LastUpdated { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public byte Severity { get; set; }
        public string IgnoreP { get; set; }
        public string IgnoreC { get; set; }
        public string ShortMsg { get; set; }
        public string LongMsg { get; set; }
        public string Data { get; set; }
    }
}
