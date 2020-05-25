using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfblockediplog
    {
        public byte[] Ip { get; set; }
        public string CountryCode { get; set; }
        public int BlockCount { get; set; }
        public int Unixday { get; set; }
        public string BlockType { get; set; }
    }
}
