using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfls2faSecrets
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public byte[] Secret { get; set; }
        public byte[] Recovery { get; set; }
        public int Ctime { get; set; }
        public int Vtime { get; set; }
        public string Mode { get; set; }
    }
}
