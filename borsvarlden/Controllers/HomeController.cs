using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using borsvarlden.Models;
using borsvarlden.ViewModels;
using borsvarlden.Services.Entities;
using borsvarlden.Helpers;

namespace borsvarlden.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public HomeController(ILogger<HomeController> logger, IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _logger = logger;
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> NewsList(int page = 1)
        {
            int newsOnPageCount = _configurationHelper.ListedNewsCount;

            PaggingResponseViewModel<NewsViewModel> model = await _finwireNewsService.GetNewsPagging(newsOnPageCount, page);

            return View(model);
        }

        public async Task<IActionResult> DetailedArticle(int articleId)
        {
            NewsViewModel model = await _finwireNewsService.GetDetailedArticle(articleId);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
