using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsvarlden.Extensions
{
    public static class ListExtensions
    {
        private static Lazy<Random> _random = new Lazy<Random>(() => new Random());

        public static T GetRandomElement<T>(this List<T> inpList)
        {
            var n = _random.Value.Next(0, inpList.Count);
            return inpList[n];
        }

        public static string ElementsToString<T>(this List<T> inpList)
        {
            StringBuilder sb = new StringBuilder();
            inpList.ForEach(x => sb.Append($"{x.ToString()}, "));
            var t = sb.ToString();
            t = t.Remove(t.Length - 2);
            return t;
        }
    }
}
