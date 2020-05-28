using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpOptions
    {
        public long OptionId { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
        public string Autoload { get; set; }
    }
}
