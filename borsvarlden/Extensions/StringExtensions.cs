using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace borsvarlden.Extensions
{
    public static class StringExtensions
    {
        public static string ToSlug(this string inpStr)
        {
            var stringBuilder = new StringBuilder();

            foreach (var c in inpStr.Normalize(NormalizationForm.FormD))
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            
            var result = stringBuilder.ToString().ToLower();
            result = Regex.Replace(result, @"[^a-z0-9\s-]", "");
            result = Regex.Replace(result, @"\s+", " ").Trim();
            result = result.Trim();
            result = Regex.Replace(result, @"\s", "-"); // hyphens
            result = Regex.Replace(result, @"\-+", "-"); // merge hyphens

            return result;
        }
    }
}
