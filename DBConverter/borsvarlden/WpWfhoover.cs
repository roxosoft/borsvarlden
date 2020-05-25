using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfhoover
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public byte[] HostKey { get; set; }
    }
}
