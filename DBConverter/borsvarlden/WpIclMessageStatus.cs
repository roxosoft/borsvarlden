using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclMessageStatus
    {
        public long Id { get; set; }
        public long Rid { get; set; }
        public long ObjectId { get; set; }
        public string FromLanguage { get; set; }
        public string ToLanguage { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Md5 { get; set; }
        public string ObjectType { get; set; }
        public short Status { get; set; }
    }
}
