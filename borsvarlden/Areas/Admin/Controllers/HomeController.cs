using System.Threading;
using System.Threading.Tasks;
using borsvarlden.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace borsvarlden.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        private IMemoryCache _cache;
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult ClearCache()
        {
            var oldCacheToken = BannerHelper._resetCacheToken;
            BannerHelper._resetCacheToken = new CancellationTokenSource();
            oldCacheToken.Cancel(true);


            return new EmptyResult();
        }
    }
}