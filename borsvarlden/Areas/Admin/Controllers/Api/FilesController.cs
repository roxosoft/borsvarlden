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
    public class FilesController : Controller
    {
        private readonly IFilesService _fileService;
        private readonly IAzureStorageImageService _azureStorageImageService;

        public FilesController(IFilesService fileService, IAzureStorageImageService azureStorageImageService)
        {
            _fileService = fileService;
            _azureStorageImageService = azureStorageImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var result = await _fileService.Get(loadOptions);
            var r = new JsonResult(result);
            return r;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List(DataSourceLoadOptions loadOptions)
        {
            var result = await _fileService.Get(loadOptions);
            var r = new JsonResult(result);
            return r;
        }

        [Route("Insert")]
        public async Task<IActionResult> Insert([FromForm] string values)
        {
            var entity = new File();
            JsonConvert.PopulateObject(values, entity);

            if (!TryValidateModel(entity))
            {
                return BadRequest();
            }

            await _fileService.Add(entity);
            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] int key, [FromForm] string values)
        {
            var entity = await _fileService.Get(key);
            JsonConvert.PopulateObject(values, entity);

            if (!TryValidateModel(entity))
            {
                return BadRequest();
            }

            await _fileService.Update(entity);

            return Ok(entity);
        }

        [Route("Delete")]
        public async Task Delete([FromForm] int key)
        {
            await _fileService.Delete(key);
        }
    }
}
