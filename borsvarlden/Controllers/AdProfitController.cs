using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using borsvarlden.Models;
using borsvarlden.Views;

namespace borsvarlden.Controllers
{
    public class AdProfitController : Controller
    {
        [Route("sponsrat/{id}")]
        public async Task<IActionResult> AdProfitArticle(string id)
        {
            return View();
        }
    }
}