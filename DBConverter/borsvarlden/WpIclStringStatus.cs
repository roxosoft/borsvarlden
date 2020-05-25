using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclStringStatus
    {
        public long Id { get; set; }
        public long Rid { get; set; }
        public long StringTranslationId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Md5 { get; set; }
    }
}
