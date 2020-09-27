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

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IAzureStorageImageService _azureStorageImageService;

        public ImageController(IAzureStorageImageService azureStorageImageService)
        {
            _azureStorageImageService = azureStorageImageService;
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

            var url = await _azureStorageImageService.UploadImage(formFile);

            return Ok(url);
        }
    }
}
