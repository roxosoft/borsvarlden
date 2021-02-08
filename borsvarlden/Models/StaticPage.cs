using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{

    public enum StaticPageType: int
    {
        _001_SplashAd = 1
    };

    public class StaticPage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public StaticPageType StaticPageType { get; set; }
    }
}
