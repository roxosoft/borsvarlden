using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.SponsoredNews
{
    public class MostReadNews : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public MostReadNews(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.MostReadNewsCount;
            int id = -1;

            if (ViewComponentContext.Arguments.TryGetValue("News", out var news))
                id = ((NewsViewModel) news).Id;
            
            var model = await _finwireNewsService.GetMostReadNews(newsCount, id);

            return View("MostReadNews", model);
        }
    }
}
