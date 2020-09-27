using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace borsvarlden.Areas.Admin.Controllers.Api
{
    using Services.Entities;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : Controller
    {
        private IFinwireCompaniesService _finwireCompaniesService;

        public ServiceController(IFinwireCompaniesService finwireCompaniesService)
            => _finwireCompaniesService = finwireCompaniesService;

        [HttpGet("GenSlugComp")]
        public async Task<IActionResult> GenerateSlugsForCompanies()
        {
            await _finwireCompaniesService.GenCompaniesSlug();
            return Ok();
        }
    }
}
