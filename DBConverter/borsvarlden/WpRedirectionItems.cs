using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpRedirectionItems
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string MatchUrl { get; set; }
        public string MatchData { get; set; }
        public int Regex { get; set; }
        public int Position { get; set; }
        public int LastCount { get; set; }
        public DateTime LastAccess { get; set; }
        public int GroupId { get; set; }
        public string Status { get; set; }
        public string ActionType { get; set; }
        public int ActionCode { get; set; }
        public string ActionData { get; set; }
        public string MatchType { get; set; }
        public string Title { get; set; }
    }
}
