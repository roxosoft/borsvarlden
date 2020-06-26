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
    public class FinwireController
    {
        private IFinwireNewsService _finwireNewsService;
        private IFinwireParserService _finwireParserService;
        private ILogger _logger;
        private IWebHostEnvironment _webHostEnvironment;

        public FinwireController(IFinwireNewsService finwireNewsService, IFinwireParserService finwireParserService,  
                                ILogger<FinwireController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _finwireNewsService = finwireNewsService;
            _finwireParserService = finwireParserService;
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
