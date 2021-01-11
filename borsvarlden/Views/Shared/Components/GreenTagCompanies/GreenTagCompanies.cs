using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.GreenTagCompanies
{
    public class GreenTagCompanies : ViewComponent
    {
        private readonly IFinwireCompaniesService _finwireCompanyService;
        private readonly IConfigurationHelper _configurationHelper;

        public GreenTagCompanies(IFinwireCompaniesService finwireCompanyService, IConfigurationHelper configurationHelper)
        {
            _finwireCompanyService = finwireCompanyService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.MostReadNewsCount;
            int id = -1;

            if (ViewComponentContext.Arguments.TryGetValue("News", out var news))
                id = ((NewsViewModel) news).Id;
            
            //var model = await _finwireCompanyService.GetMostReadNews(newsCount, id);
            var model = await _finwireCompanyService.GetGreenTagCompanies();

            return View("GreenTagCompanies", model);
        }
    }
}
