using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using borsvarlden.Areas.Admin.ViewModels;
using borsvarlden.Services.Entities;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace borsvarlden.Areas.Admin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IFinwireNewsService _newsService;

        public ArticlesController(IFinwireNewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var result = await _newsService.GetNewsList(loadOptions);

            return new JsonResult(result);
        }
    }
}