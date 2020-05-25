using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclReminders
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public byte CanDelete { get; set; }
        public byte Show { get; set; }
    }
}
