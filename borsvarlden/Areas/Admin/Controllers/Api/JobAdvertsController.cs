using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Services.Entities;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace borsvarlden.Areas.Admin.Controllers.Api
{
    using Services.Azure;
    using Extensions;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobAdvertsController : Controller
    {
        private readonly IJobAdvertsService _jobAdvertsService;
        private readonly IAzureStorageImageService _azureStorageImageService;

        public JobAdvertsController(IJobAdvertsService finwireCompaniesService, IAzureStorageImageService azureStorageImageService)
        {
            _jobAdvertsService = finwireCompaniesService;
            _azureStorageImageService = azureStorageImageService;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List(DataSourceLoadOptions loadOptions)
        {

            var result = await _jobAdvertsService.GetListAsync(loadOptions);
            var r = new JsonResult(result);
            return r;
        }

        [Route("Insert")]
        public async Task<IActionResult> Insert([FromForm] string values)
        {
            var jobAdvert = new JobAdvert();
            JsonConvert.PopulateObject(values, jobAdvert);
            //TODO slug
            if (!TryValidateModel(jobAdvert))
            {
                return BadRequest();
            }

            await _jobAdvertsService.CreateAsync(jobAdvert);
            return Ok();
        }

        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] int key, [FromForm] string values)
        {
            var article = await  _jobAdvertsService.GetAsync(key);
            JsonConvert.PopulateObject(values, article);

            if (!TryValidateModel(article))
            {
                return BadRequest();
            }

            await _jobAdvertsService.UpdateAsync(article);

            return Ok(article);
        }

        [Route("Delete")]
        public async Task Delete([FromForm] int key)
        {
            await _jobAdvertsService.DeleteAsync(key);
        }
    }
}
