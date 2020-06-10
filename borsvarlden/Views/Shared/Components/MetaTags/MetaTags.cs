using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.MetaTags
{
    public class MetaTags : ViewComponent
    {
        public MetaTags()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewComponentContext.Arguments.TryGetValue("Model", out var model);
            
            return View("MetaTags",model);
        }
    }
}