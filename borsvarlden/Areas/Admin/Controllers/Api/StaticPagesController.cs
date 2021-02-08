using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace borsvarlden.Areas.Admin.Controllers.Api
{
    using Services.Entities;
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaticPagesController : Controller
    {
        private readonly IStaticPagesService _staticPageService;
        public StaticPagesController(IStaticPagesService staticPageService)
        {
            _staticPageService = staticPageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var result = await _staticPageService.GetListAsync();
            return new JsonResult(result);
        }

        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] int key, [FromForm] string values)
        {
            var staticPage = await _staticPageService.GetAsync(key);
            JsonConvert.PopulateObject(values, staticPage);

            if (!TryValidateModel(staticPage))
            {
                return BadRequest();
            }

            await _staticPageService.UpdateAsync(staticPage);
            return Ok();

          
        }

    }
}
