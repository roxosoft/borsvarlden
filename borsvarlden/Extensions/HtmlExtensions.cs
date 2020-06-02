using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using borsvarlden.Extensions;
      
namespace borsvarlden.Extensions
{
    public static class HtmlExtensions
    {
        public static string FistParagraph(this string input)
        {
            var res = input.Split("<br/><br/>")[0];
            return res;
        }

        public static string ParseHtmlText(this string input)
        {
            var res = input.Replace("<![CDATA[", string.Empty)
                .Remove("]]>")
                .RemoveRegex("<span[=_a-zA-Z\" ]*>")
                .Remove("</span>");
            
            return res;
        }

        public static (string, string) SplitSubtitleAndNews(this string input)
        {
            var res = input.Split("<br><br>");

            var subtitle = res[0];
            var newsText = input.Remove($"{res[0]}<br><br>");
            
            return (subtitle, newsText);
        }
    }
}
