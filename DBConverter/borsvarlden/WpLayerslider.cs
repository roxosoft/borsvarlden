using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpLayerslider
    {
        public int Id { get; set; }
        public int Author { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Data { get; set; }
        public int DateC { get; set; }
        public int DateM { get; set; }
        public byte FlagHidden { get; set; }
        public byte FlagDeleted { get; set; }
    }
}
