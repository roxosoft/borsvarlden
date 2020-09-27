using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using borsvarlden.Models;
using borsvarlden.Services.Entities;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace borsvarlden.Areas.Admin.Controllers.Api
{
    using Services.Facebook;
    using Extensions;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        private readonly IFinwireNewsService _newsService;

        private readonly IFacebookService _facebookService;

        public ArticlesController(IFinwireNewsService newsService, IFacebookService facebookService)
        {
            _newsService = newsService;
            _facebookService = facebookService;
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

            //Facebook stuff disabled for a while
            var textForFaceBook = (HttpUtility.HtmlDecode(article.NewsText.ToPlainText()));
            _facebookService.PublishToFacebook(textForFaceBook,
                article.ImageRelativeUrl);

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