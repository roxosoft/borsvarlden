using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfcrawlers
    {
        public byte[] Ip { get; set; }
        public byte[] PatternSig { get; set; }
        public string Status { get; set; }
        public int LastUpdate { get; set; }
        public string Ptr { get; set; }
    }
}
