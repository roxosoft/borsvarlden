using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclTranslate
    {
        public long Tid { get; set; }
        public long JobId { get; set; }
        public long ContentId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string FieldType { get; set; }
        public string FieldWrapTag { get; set; }
        public string FieldFormat { get; set; }
        public byte FieldTranslate { get; set; }
        public string FieldData { get; set; }
        public string FieldDataTranslated { get; set; }
        public byte FieldFinished { get; set; }
    }
}
