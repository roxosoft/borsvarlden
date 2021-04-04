using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileHeader { get; set; }
        public string FileDescription { get; set; }
        public string FilePassword { get; set; }
        public string FileLink { get; set; }
        public int CountOfDownloads { get; set; }
    }
}
