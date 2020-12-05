using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;


namespace borsvarlden.Helpers
{
    using  Extensions;

    public static class BannerHelper
    {
        private static readonly string _url = "https://borsvarlden-banners.azurewebsites.net/getslider.php";
        private static readonly string _url_param = "https://borsvarlden-banners.azurewebsites.net/getslider-details.php?slider={0}";


        public static async Task<string> GetHtmlAsync()
        {
            using (var response = new StreamReader(((HttpWebResponse)await WebRequest.Create(_url).GetResponseAsync())?.GetResponseStream()))
            {
                var res = response.ReadToEnd();
                return res;
            }
        }

        public static async Task<string> GetHtmlAsync(string slider)
        {
            using (var response = new StreamReader(((HttpWebResponse)await WebRequest.Create(String.Format(_url_param, slider)).GetResponseAsync())?.GetResponseStream()))
            {
                var res = response.ReadToEnd();

                if (res.Contains("Revolution Slider Error: Slider with alias"))
                    return string.Empty;

                return res;
            }
        }
    }
}
