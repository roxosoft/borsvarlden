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
using Newtonsoft.Json.Linq;


namespace borsvarlden.Areas.Admin.Controllers.Api
{
    using Services.Facebook;
    using Services.Azure;
    using Extensions;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        private readonly IFinwireNewsService _newsService;

        private readonly IFacebookService _facebookService;

        private readonly IAzureStorageImageService _azureStorageImageService;

        public ArticlesController(IFinwireNewsService newsService, IFacebookService facebookService, IAzureStorageImageService azureStorageImageService)
        {
            _newsService = newsService;
            _facebookService = facebookService;
            _azureStorageImageService = azureStorageImageService;
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
            var companies = RetrieveCompanies(values);

            if (!TryValidateModel(article))
            {
                return BadRequest();
            }

            if (article.DateStartVisible == default(DateTime))
                article.DateStartVisible = DateTime.Now;

            await _newsService.AddArticle(article, companies);

            //Facebook stuff disabled for a while
            //var textForFaceBook = (HttpUtility.HtmlDecode(article.NewsText.ToPlainText()));
            //_facebookService.PublishToFacebook(textForFaceBook,
              //  article.ImageRelativeUrl);

            return Ok();
        }

        
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] int key, [FromForm] string values)
        {
            var article = await _newsService.GetArticle(key);
            JsonConvert.PopulateObject(values, article);
            var companies = RetrieveCompanies(values);

            article.FinwireNew2FinwireCompanies = null;

            if (!TryValidateModel(article))
            {
                return BadRequest();
            }

            await _newsService.UpdateArticle(article,companies);

            return Ok();
        }

        [Route("Delete")]
        public async Task Delete([FromForm] int key)
        {
            await _newsService.DeleteArticle(key);
        }

        private List<CompanyCommon> RetrieveCompanies(string receivedString)
        {
            var companies = new List<CompanyCommon>();

            foreach (var x in JsonConvert.DeserializeObject(receivedString) as JObject)
                if (x.Key == "FinwireNew2FinwireCompanies")
                {
                    foreach (var g in x.Value)
                        companies.Add(g.ToObject<CompanyCommon>());

                    break;
                }

            return companies;
        }
    }
}