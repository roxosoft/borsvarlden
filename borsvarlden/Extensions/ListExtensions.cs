using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this List<T> inpList)
        {
            var n = new Random().Next(0, inpList.Count - 1);
            return inpList[n];
        }
    }
}
