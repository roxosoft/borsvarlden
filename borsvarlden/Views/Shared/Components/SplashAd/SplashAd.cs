using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace borsvarlden.Views.Shared.Components.SplashAd
{
    public class SplashAd : ViewComponent
    {
        private readonly IStaticPagesService _staticPagesService;
        public SplashAd(IStaticPagesService staticPagesService)
        {
            _staticPagesService = staticPagesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _staticPagesService.GetSplashAdPage();
            model.Text =  WebUtility.HtmlDecode(model.Text);
            return View("SplashAd", model);
        }
    }
}