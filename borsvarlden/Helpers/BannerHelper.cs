using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace borsvarlden.Helpers
{
    public static class BannerHelper
    {
        private static readonly string _url = "https://borsvarlden-banners.azurewebsites.net/getslider.php";

        public static async Task<string> GetHtmlAsync()
        {
            using (var response = new StreamReader(((HttpWebResponse)await WebRequest.Create(_url).GetResponseAsync())?.GetResponseStream()))
            {
                var res = response.ReadToEnd();
                return res;
            }
        }
    }
}
