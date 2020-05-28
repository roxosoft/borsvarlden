using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclStringTranslations
    {
        public long Id { get; set; }
        public long StringId { get; set; }
        public string Language { get; set; }
        public byte Status { get; set; }
        public string Value { get; set; }
        public string MoString { get; set; }
        public long? TranslatorId { get; set; }
        public string TranslationService { get; set; }
        public int BatchId { get; set; }
        public DateTimeOffset TranslationDate { get; set; }
    }
}
