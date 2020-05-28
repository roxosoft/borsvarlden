using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpIclMoFilesDomains
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FilePathMd5 { get; set; }
        public string Domain { get; set; }
        public string Status { get; set; }
        public int NumOfStrings { get; set; }
        public int LastModified { get; set; }
        public string ComponentType { get; set; }
        public string ComponentId { get; set; }
    }
}
