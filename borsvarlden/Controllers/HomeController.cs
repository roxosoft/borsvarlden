using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using borsvarlden.Models;
using borsvarlden.Services.Entities;

namespace borsvarlden.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IFinwireNewsService _finwireNewsService;

        public HomeController(ILogger<HomeController> logger, IFinwireNewsService finwireNewsService)
        {
            _logger = logger;
            _finwireNewsService = finwireNewsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _finwireNewsService.GetMainNews(30);
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
