using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclTranslationStatus
    {
        public long Rid { get; set; }
        public long TranslationId { get; set; }
        public byte Status { get; set; }
        public long TranslatorId { get; set; }
        public byte NeedsUpdate { get; set; }
        public string Md5 { get; set; }
        public string TranslationService { get; set; }
        public int BatchId { get; set; }
        public string TranslationPackage { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public byte LinksFixed { get; set; }
        public string Prevstate { get; set; }
        public string Uuid { get; set; }
        public int? TpId { get; set; }
        public int TpRevision { get; set; }
        public string TsStatus { get; set; }
    }
}
