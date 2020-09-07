using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using borsvarlden.Models;
using borsvarlden.Services.Entities;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace borsvarlden.Areas.Admin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [Route("Insert")]
        public async Task<IActionResult> Insert([FromForm] string values)
        {
            var article = new FinwireNew();
            JsonConvert.PopulateObject(values, article);
            
            if (!TryValidateModel(article))
            {
                return BadRequest();
            }

            await _newsService.AddArticle(article);
            
            return Ok(article);
        }

        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] int key, [FromForm] string values)
        {
            var article = await _newsService.GetArticle(key);
            JsonConvert.PopulateObject(values, article);

            if (!TryValidateModel(article))
            {
                return BadRequest();
            }

            await _newsService.UpdateArticle(article);
            
            return Ok(article);
        }

        [Route("Delete")]
        public async Task Delete([FromForm] int key)
        {
            await _newsService.DeleteArticle(key);
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage()
        {
            var files = Request.Form.Files;
            if (files.Count != 1)
                return BadRequest();

            var formFile = files[0];
            if (formFile.Length <= 0)
                return BadRequest();

            var url = await _newsService.UploadImage(formFile);

            return Ok(url);
        }
    }
}