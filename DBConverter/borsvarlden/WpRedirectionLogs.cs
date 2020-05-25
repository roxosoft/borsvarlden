using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpRedirectionLogs
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        public string SentTo { get; set; }
        public string Agent { get; set; }
        public string Referrer { get; set; }
        public int? RedirectionId { get; set; }
        public string Ip { get; set; }
        public int ModuleId { get; set; }
        public int? GroupId { get; set; }
    }
}
