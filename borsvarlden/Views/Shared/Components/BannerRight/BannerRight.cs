using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.BannerTop
{
    public class BannerRight : ViewComponent
    {
        public BannerRight()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("BannerRight");
        }
    }
}