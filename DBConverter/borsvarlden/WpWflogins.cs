using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWflogins
    {
        public int Id { get; set; }
        public int? HitId { get; set; }
        public double Ctime { get; set; }
        public byte Fail { get; set; }
        public string Action { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public byte[] Ip { get; set; }
        public string Ua { get; set; }
    }
}
