using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclLanguages
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
        public byte Major { get; set; }
        public byte Active { get; set; }
        public string DefaultLocale { get; set; }
        public string Tag { get; set; }
        public byte EncodeUrl { get; set; }
    }
}
