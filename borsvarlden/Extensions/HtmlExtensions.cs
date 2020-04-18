using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace borsvarlden.Extensions
{
    public static class HtmlExtensions
    {
        public static string FistParagraph(this string input)
        {
            var res = input.Split("<br/><br/>")[0];
            return res;
        }
    }
}
