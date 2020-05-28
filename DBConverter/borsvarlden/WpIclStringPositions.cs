using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclStringPositions
    {
        public long Id { get; set; }
        public long StringId { get; set; }
        public byte? Kind { get; set; }
        public string PositionInPage { get; set; }
    }
}
