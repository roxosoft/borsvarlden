﻿using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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

        public static string ToMd5Hash(this string value)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(value);
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string Remove(this string value, string substring)
        {
            return value.Replace(substring, string.Empty);
        }

        public static string RemoveRegex(this string input, string regex)
        {
            return Regex.Replace(input, regex, string.Empty);
        }
    }
}
