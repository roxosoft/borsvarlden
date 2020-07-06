using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Extensions
{
    public static class TimeExtensions
    {
        private static readonly TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");

        public static DateTime ToDisplayTime(this DateTime inpTime)  => TimeZoneInfo.ConvertTimeFromUtc(inpTime, cstZone);
    }
}
