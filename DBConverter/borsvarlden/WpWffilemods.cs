using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWffilemods
    {
        public byte[] FilenameMd5 { get; set; }
        public string Filename { get; set; }
        public byte KnownFile { get; set; }
        public byte[] OldMd5 { get; set; }
        public byte[] NewMd5 { get; set; }
        public byte[] Shac { get; set; }
        public string StoppedOnSignature { get; set; }
        public int StoppedOnPosition { get; set; }
        public string IsSafeFile { get; set; }
    }
}
