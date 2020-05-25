using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclFlags
    {
        public int Id { get; set; }
        public string LangCode { get; set; }
        public string Flag { get; set; }
        public byte FromTemplate { get; set; }
    }
}
