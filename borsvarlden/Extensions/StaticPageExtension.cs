using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Extensions
{
    using Models;
    using ViewModels;
    public static class StaticPageExtension
    {
        private static Dictionary<StaticPageType, string> _pageExtensions = new Dictionary<StaticPageType, string>
        {
            {
                StaticPageType._001_SplashAd, "Splash advertise "
            }
        };

        public static StaticPageViewModel ToViewModel(this StaticPage staticPage)
        {
            string pageName = null;

            if (!_pageExtensions.TryGetValue(staticPage.StaticPageType, out pageName))
                throw new ApplicationException("StaticPageExtension. Unknown static page type");

            return new StaticPageViewModel
            {
                PageName = pageName, 
                Id = staticPage.Id, 
                Text = staticPage.Text
            };
        }
    }
}
