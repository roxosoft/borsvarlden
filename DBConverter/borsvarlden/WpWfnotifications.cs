﻿using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfnotifications
    {
        public string Id { get; set; }
        public byte New { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public int Ctime { get; set; }
        public string Html { get; set; }
        public string Links { get; set; }
    }
}
