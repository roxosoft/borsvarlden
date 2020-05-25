using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclTranslations
    {
        public long TranslationId { get; set; }
        public string ElementType { get; set; }
        public long? ElementId { get; set; }
        public long Trid { get; set; }
        public string LanguageCode { get; set; }
        public string SourceLanguageCode { get; set; }
    }
}
