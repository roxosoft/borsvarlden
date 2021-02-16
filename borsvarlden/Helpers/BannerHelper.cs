using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;


namespace borsvarlden.Helpers
{
    using  Extensions;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Primitives;
    using System.Threading;

    public static class BannerHelper
    {
        public enum BannerKeys
        {
            SIDEBANNER1,
            SIDEBANNER2,
            SIDEBANNER3
        }
        private static readonly string _url = "https://borsvarlden-banners.azurewebsites.net/getslider.php";
        private static readonly string _url_param = "https://borsvarlden-banners.azurewebsites.net/getslider-details.php?slider={0}";
        public static CancellationTokenSource _resetCacheToken = new CancellationTokenSource();

        public static async Task<string> GetHtmlAsync()
        {
            using (var response = new StreamReader(((HttpWebResponse)await WebRequest.Create(_url).GetResponseAsync())?.GetResponseStream()))
            {
                var res = response.ReadToEnd();
                return res;
            }
        }

        public static async Task<string> GetHtmlAsync(string slider, IMemoryCache memoryCache)
        {
            string result;
            if (memoryCache.TryGetValue(slider, out result))// Look for cache key.
            {
                return result;
            }
            using (var response = new StreamReader(((HttpWebResponse)await WebRequest.Create(String.Format(_url_param, slider)).GetResponseAsync())?.GetResponseStream()))
            {
                var res = response.ReadToEnd();

                if (res.Contains("Revolution Slider Error: Slider with alias"))
                    res = string.Empty;

                result = res;
            }

            MemoryCacheEntryOptions entryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1));
            entryOptions.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));
            memoryCache.Set(slider, result, entryOptions);
            return result;
        }
    }
}
