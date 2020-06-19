using System;
using System.Collections.Generic;
using System.Text;

namespace DBConverter.Extensions
{
    public static class ContentExtensions
    {
        public static string ChangeImagePathInPost(this string content)
        {
            return content.Replace("https://borsvarlden.com/wp-content", @"/assets");
        }

        public static string ChangeImagePathForTitle(this string content)
        {
            return content.Replace("https://borsvarlden.com/wp-content", @"assets");
        }

        public static (string, string) SplitSubtitleAndNews(this string input)
        {
            var res = input.Split("</p>");
            var subtitle = res[0].Replace("<p>","");
            var newsText = input.Replace($"<p>{subtitle}</p>","");

            return (subtitle, newsText);
        }

    }
}
