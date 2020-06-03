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

            var callingViewModel = (NewsViewModel)this.ViewComponentContext.Arguments["News"];
            List<NewsViewModel> model = await _finwireNewsService.GetMoreNews(callingViewModel.Id);

            return View("ReadMore", model);
        }
    }
}
