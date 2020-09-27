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

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly IFinwireCompaniesService _finwireCompaniesService;
        private readonly IAzureStorageImageService _azureStorageImageService;

        public CompaniesController(IFinwireCompaniesService finwireCompaniesService, IAzureStorageImageService azureStorageImageService)
        {
            _finwireCompaniesService = finwireCompaniesService;
            _azureStorageImageService = azureStorageImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var result = await _finwireCompaniesService.GetCompanies(loadOptions);
            var r = new JsonResult(result);
            return r;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IActionResult> List(DataSourceLoadOptions loadOptions)
        {
            var result = await _finwireCompaniesService.GetListFinwireCompanies(loadOptions);
            var r = new JsonResult(result);
            return r;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] string values)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] int key, [FromForm] string values)
        {
            throw new NotImplementedException();
        }

        [Route("UpdateCompanyInfo")]
        public async Task<IActionResult> UpdateCompanyInfo([FromForm] int key, [FromForm] string values)
        {
            var company = await _finwireCompaniesService.GetFinwireCompany(key);
            JsonConvert.PopulateObject(values, company);
            company.Slug = company.Company.ToSlug();

            if (!TryValidateModel(company))
            {
                return BadRequest();
            }

            await _finwireCompaniesService.UpdateCompany(company);

            return Ok(company);
        }

        [Route("GetCompaniesByNews/{id}")]
        public async Task<IActionResult> GetCompaniesByNews([FromRoute]int id)
        {
            var result = await _finwireCompaniesService.GetCompaniesByFinwireNewsId(id);
            var r = new JsonResult(result);
            return r;
        }

        [Route("AddCompanyToNews/{newsId}/{company}")]
        public async Task<IActionResult> AddCompanyToNews([FromRoute]int newsId, [FromRoute]string company)
        {
            await _finwireCompaniesService.AddCompanyToNews(newsId, company);
            return Ok();
        }

        [Route("DeleteCompanyForNews/{newsId}/{companiesList}")]
        public async Task<IActionResult> DeleteCompaniesForNews([FromRoute]int newsId, [FromRoute]string companiesList)
        {
            await _finwireCompaniesService.DeleteCompaniesForeNews(newsId, companiesList);
            return Ok();
        }
    }
}
