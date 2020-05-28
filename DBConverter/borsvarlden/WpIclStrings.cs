using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclStrings
    {
        public long Id { get; set; }
        public string Language { get; set; }
        public string Context { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public long? StringPackageId { get; set; }
        public long? Location { get; set; }
        public string WrapTag { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public byte Status { get; set; }
        public string GettextContext { get; set; }
        public string DomainNameContextMd5 { get; set; }
        public string TranslationPriority { get; set; }
        public int? WordCount { get; set; }
    }
}
