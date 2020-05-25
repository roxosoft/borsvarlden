using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpRedirection404
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public string Agent { get; set; }
        public string Referrer { get; set; }
        public string Ip { get; set; }
    }
}
