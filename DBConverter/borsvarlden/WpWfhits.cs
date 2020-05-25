using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpWfhits
    {
        public int Id { get; set; }
        public double AttackLogTime { get; set; }
        public double Ctime { get; set; }
        public byte[] Ip { get; set; }
        public byte? JsRun { get; set; }
        public int StatusCode { get; set; }
        public byte IsGoogle { get; set; }
        public int UserId { get; set; }
        public byte NewVisit { get; set; }
        public string Url { get; set; }
        public string Referer { get; set; }
        public string Ua { get; set; }
        public string Action { get; set; }
        public string ActionDescription { get; set; }
        public string ActionData { get; set; }
    }
}
