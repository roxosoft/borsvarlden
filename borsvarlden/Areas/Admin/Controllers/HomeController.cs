using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace borsvarlden.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}