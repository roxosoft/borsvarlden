using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpRevsliderSlides
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int SlideOrder { get; set; }
        public string Params { get; set; }
        public string Layers { get; set; }
        public string Settings { get; set; }
    }
}
