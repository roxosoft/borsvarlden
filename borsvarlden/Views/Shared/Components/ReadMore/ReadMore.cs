using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.ReadMore
{
    public class ReadMore : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public ReadMore(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.ReadMoreCount;

            List<NewsViewModel> model = await _finwireNewsService.GetNews(newsCount);

            return View("ReadMore", model);
        }
    }
}
