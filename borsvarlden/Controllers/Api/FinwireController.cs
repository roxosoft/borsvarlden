using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using borsvarlden.Services.Finwire;
using borsvarlden.Services.Entities;

namespace borsvarlden.Controllers.Api
{
    public class FinwireController
    {
        private IFinwireNewsService _finwireNewsService;
        private IFinwireParserService _finwireParserService;
        private ILogger _logger;

        public FinwireController(IFinwireNewsService finwireNewsService, IFinwireParserService finwireParserService,  ILogger<FinwireController> logger)
        {
            _finwireNewsService = finwireNewsService;
            _finwireParserService = finwireParserService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/updatenews")]
        public async Task<string> UpdateNews(string xml, string uid)
        {
            _logger.LogWarning($"API updeatenews uid={uid}");
            var data = await _finwireParserService.ParseXmlContent(xml);
            _finwireNewsService.AddSingleNews(data);
            return "OK";
        }
    }
}
