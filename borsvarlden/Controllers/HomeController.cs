using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
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
using HtmlAgilityPack;

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
        private readonly IJobAdvertsService _jobadvertService;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IFinwireNewsService finwireNewsService, IFinwireParserService finwireParserService,
                              IFinwireXmlNewsService finwireXmlService,  IFinwireCompaniesService finwireCompaniesService, IJobAdvertsService jobAdvertService,
                              IConfigurationHelper configurationHelper, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
            _finwireParserService = finwireParserService;
            _finwireXmlService = finwireXmlService;
            _finwireCompaniesService = finwireCompaniesService;
            _jobadvertService = jobAdvertService;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {

            /*   var request = new HttpRequestMessage(HttpMethod.Get,
                   "https://api.github.com/repos/aspnet/AspNetCore.Docs/branches");
               request.Headers.Add("Accept", "application/vnd.github.v3+json");
               request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

               var client = _clientFactory.CreateClient();

               var response = await client.SendAsync(request);

               if (response.IsSuccessStatusCode)
               {
                   using var responseStream = await response.Content.ReadAsStreamAsync();
                   string responseBody = await response.Content.ReadAsStringAsync();

               }
               */

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://www.facebook.com/borsvarlden/posts");
          //  request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                string responseBody = await response.Content.ReadAsStringAsync();

                HtmlDocument pageDocument = new HtmlDocument();
                pageDocument.LoadHtml(responseBody);

                //var headlineText = pageDocument.DocumentNode.SelectSingleNode("(//div[contains(@class,'userContentWrapper')]//div)[1]");//.InnerText;

                var headlineText = pageDocument.DocumentNode.SelectNodes("(//div[contains(@class,'userContentWrapper')])");

                //var b = Regex.Matches(responseBody, "(borsvarlden/posts/[0-9]+\")");
                // var b = Regex.Matches(responseBody, "(<div class=\"_5pcr userContentWrapper\".*</div>)");

                var b = Regex.Matches(responseBody, "(<div class=\"_5pcr userContentWrapper\".*</div></form></div></div></div></div>)<div>");


                //responseBody

            }


            HttpClient http = new HttpClient();
           //http.DefaultRequestHeaders.Add(schemename, header);
         //  var r = http.GetAsync("https://www.facebook.com/borsvarlden/").Result;


            var data = http.GetAsync("https://www.facebook.com/borsvarlden/").Result.Content.ReadAsStringAsync().Result;

            return View();
        }

        [Route("artiklar/hallbaraInvesteringar")]
        public async Task<IActionResult> IndexGreenTag()
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

        [Route("artiklar/hallbaraInvesteringar/{greenTag}")]
        [Route("artiklar/hallbaraInvesteringar/{greenTag}/sida/{page}")]
        [Route("artiklar/hallbaraInvesteringar/{greenTag}/sida/{page}/{searchText}")]
        public async Task<IActionResult> NewsListGreenTag(int page = 1, string searchText = null)
        {
            int newsOnPageCount = _configurationHelper.ListedNewsCount;

            PaggingSearchResponseViewModel<NewsViewModel> model = await _finwireNewsService.GetNewsSearchPaging(newsOnPageCount, page, searchText, false, true);

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

        [Route("Finansjobb")]
        public async Task<IActionResult> FinanceJob()
        {
            
            return View();
        }

        [Route("FinansjobbDetaljer/{id}")]
        public async Task<IActionResult> FinanceJobDetail(int id)
        {
            var vm = await _jobadvertService.GetAsync(id);
            return View(vm);
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

        [Route("uploads/uploads/{year}/{month}/{id}")]
        public IActionResult Images(string year, string month, string id) => Redirect($"https://borsvarlden.blob.core.windows.net/uploads/uploads/{year}/{month}/{id}");

        public async Task<IActionResult> SubscribePopupPreview()
        {
            return View();
        }

    }
}
