using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfsnipcache
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string Body { get; set; }
        public int Count { get; set; }
        public int Type { get; set; }
    }
}
