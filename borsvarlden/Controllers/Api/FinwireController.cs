﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using borsvarlden.Services.Finwire;
using borsvarlden.Services.Entities;

namespace borsvarlden.Controllers.Api
{
    public class FinwireController
    {
        private IFinwireNewsService _finwireNewsService;
        private IFinwireParserService _finwireParserService;

        public FinwireController(IFinwireNewsService finwireNewsService, IFinwireParserService finwireParserService)
        {
            _finwireNewsService = finwireNewsService;
            _finwireParserService = finwireParserService;
        }

        [HttpPost]
        [Route("api/updatenews")]
        public async Task<string> UpdateNews(string xml, string uid)
        {
            var data = await _finwireParserService.ParseXmlContent(xml);
            _finwireNewsService.AddSingleNews(data);          
            return "OK";
        }
    }
}
