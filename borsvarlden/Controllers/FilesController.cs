using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace borsvarlden.Controllers
{
    using Services.Entities;
    public class FilesController : Controller
    {
        private IFilesService _filesService;

        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        public async Task<IActionResult> Index()
            => View(await _filesService.Get());

        [Route("Files/RequestFile/{id}")]
        public async Task<IActionResult> RequestFile(int id, string password = null)
        {
            var file = await _filesService.Get(id);

            if (file == null)
                throw new ApplicationException("File not found");

            if (password == null)
            {
                return View();
            }

            if (password == file.FilePassword)
            {
                await _filesService.IncCountOfDownloads(id);
                return View("LinkToDownload", file.FileLink);
            }

            return View("RequestFile", "Felaktigt lösenord !");
        }
    }
}
