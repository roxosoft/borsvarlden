using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWflocs
    {
        public byte[] Ip { get; set; }
        public int Ctime { get; set; }
        public byte Failed { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public float? Lat { get; set; }
        public float? Lon { get; set; }
    }
}
