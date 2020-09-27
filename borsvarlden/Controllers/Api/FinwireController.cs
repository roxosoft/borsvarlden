using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using borsvarlden.Services.Finwire;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Hosting;

namespace borsvarlden.Controllers.Api
{
    using Services.Facebook;

    public class FinwireController
    {
        private IFinwireNewsService _finwireNewsService;
        private IFinwireParserService _finwireParserService;
        private IFacebookService _facebookService;
        private ILogger _logger;
        private IWebHostEnvironment _webHostEnvironment;

        public FinwireController(IFinwireNewsService finwireNewsService, IFinwireParserService finwireParserService, IFacebookService facebookService, 
                                ILogger<FinwireController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _finwireNewsService = finwireNewsService;
            _finwireParserService = finwireParserService;
            _facebookService = facebookService;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("api/updatenews")]
        public async Task<string> UpdateNews(string xml, string uid)
        {
            _logger.LogWarning($"API updeatenews uid={uid}");
            var data = await _finwireParserService.ParseXmlContent(xml);
            await _finwireNewsService.AddSingleNews(data);
            return "OK";
        }

        [HttpGet]
        [Route("api/facebook")]
        public async Task<string> PublishToFacebok()
        {
            _facebookService.PublishToFacebook("<h1>Test html</h1> and some text", "https://borsvarlden.com/assets/images/finauto/socialtag/tech/bvfa-s-tech-0016.jpg");
            return "Ok";
        }

        [HttpGet]
        [Route("api/seednews")]
        public async Task<string> SeedNews()
        {
            if (!_webHostEnvironment.IsDevelopment())
                return "";

            var pathBase = Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\TestData\FinwireFiles");

           
            foreach(var dir in Directory.GetDirectories(pathBase).ToList())
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    var finwireData = _finwireParserService.ParseFile(file);
                    await _finwireNewsService.AddSingleNews(finwireData.Result);
                }
            }
            return "OK";
        }
    }
}
