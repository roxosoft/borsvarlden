using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Helpers
{
    public static class TimeHelper
    {
        private static TimeZoneInfo _cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");

        public static DateTime Time => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _cstZone);
    }
}
