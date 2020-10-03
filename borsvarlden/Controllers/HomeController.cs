﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using borsvarlden.Models;
using borsvarlden.ViewModels;
using borsvarlden.Extensions;
using borsvarlden.Services.Finwire;
using borsvarlden.Services.Entities;
using borsvarlden.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace borsvarlden.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;
        private readonly IFinwireParserService _finwireParserService;
        private readonly IFinwireXmlNewsService _finwireXmlService;
        private readonly IFinwireCompaniesService _finwireCompaniesService;

        public HomeController(ILogger<HomeController> logger, IFinwireNewsService finwireNewsService, IFinwireParserService finwireParserService,
                              IFinwireXmlNewsService finwireXmlService,  IFinwireCompaniesService finwireCompaniesService, IConfigurationHelper configurationHelper)
        {
            _logger = logger;
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
            _finwireParserService = finwireParserService;
            _finwireXmlService = finwireXmlService;
            _finwireCompaniesService = finwireCompaniesService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("heta-aktier")]
        public async Task<IActionResult> HotStocks()
        { 
            return View();
        }

        [Route("artiklar")]
        [Route("artiklar/sida/{page}")]
        [Route("artiklar/sida/{page}/{searchText}")]
        [Route("artiklar/endast15MinuterVideo/{only15MinutesVideo}")]
        [Route("artiklar/endast15MinuterVideo/{only15MinutesVideo}/sida/{page}")]
        [Route("artiklar/endast15MinuterVideo/{only15MinutesVideo}/sida/{page}/{searchText}")]
        public async Task<IActionResult> NewsList(int page = 1, string searchText = null, bool only15MinutesVideo = false)
        {
            int newsOnPageCount = _configurationHelper.ListedNewsCount;

            PaggingSearchResponseViewModel<NewsViewModel> model = await _finwireNewsService.GetNewsSearchPaging(newsOnPageCount, page, searchText, only15MinutesVideo);

            return View(model);
        }

        public async Task<IActionResult> DetailedArticle(int articleId)
        {
            NewsViewModel model = await _finwireNewsService.GetDetailedArticle(articleId);
            return View(model);
        }

        [Route("artiklar/{titleSlug}")]
        public async Task<IActionResult> DetailedArticle([FromRoute]string titleSlug)
        {
            var cookie = this.GetCookie(titleSlug);

            if (cookie == null)
            {
                this.SetCookie(titleSlug);
                await _finwireNewsService.UpdateReadCount(titleSlug);
            }

            NewsViewModel model = await _finwireNewsService.GetDetailedArticle(titleSlug);
            if (model == null)
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            return View(model);
        }

        [Route("finwire/{guid}")]
        public async Task<IActionResult> FinwireArticleFromXmlByGuid(string guid)
        {
            NewsViewModel model = await _finwireNewsService.GetDetailedArticleByGuid(guid);

            if (model == null)
                 return View("Error",new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            var cookie = this.GetCookie(model.TittleSlug);

             if (cookie == null)
             {
                 this.SetCookie(model.TittleSlug);
                 await _finwireNewsService.UpdateReadCount(model.TittleSlug);
             }
             
            return View("DetailedArticle",model);
        }

        [Route("nyhetsbrev")]
        public async Task<IActionResult> SubscribeNews()
        {
            return View();
        }

        public async Task<IActionResult> SignUpForIPOs()
        {
            return View();
        }

        public async Task<IActionResult> ProInvestors()
        {
            return View();
        }

        [Route("traders-club")]
        public async Task<IActionResult> TradersClub()
        {
            return Redirect ("https://www.facebook.com/groups/tradersclubsverige");
        }

        [Route("om-borsvarlden")]
        public async Task<IActionResult> About()
        {
            return View();
        }

        [Route("friskrivning")]
        public async Task<IActionResult> Disclaimer()
        {
            return View();
        }

        [Route("integritetspolicy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("information-om-cookies")]
        public async Task<IActionResult> InformationCookies()
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
