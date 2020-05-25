using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclTranslationBatches
    {
        public int Id { get; set; }
        public string BatchName { get; set; }
        public int? TpId { get; set; }
        public string TsUrl { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
