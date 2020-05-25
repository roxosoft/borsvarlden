using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclTranslateJob
    {
        public long JobId { get; set; }
        public long Rid { get; set; }
        public int TranslatorId { get; set; }
        public byte Translated { get; set; }
        public int ManagerId { get; set; }
        public int? Revision { get; set; }
        public string Title { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Editor { get; set; }
        public long? EditorJobId { get; set; }
        public int? EditTimestamp { get; set; }
    }
}
