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

    }
}
