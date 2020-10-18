using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.FinanceJob
{ 
    public class FinanceJob : ViewComponent
    {
        private readonly IJobAdvertsService _jobAdertsService;
        private readonly IConfigurationHelper _configurationHelper;

        public FinanceJob(IJobAdvertsService jobAdvertsService, IConfigurationHelper configurationHelper)
        {
            _jobAdertsService = jobAdvertsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.IndexNewsCount;
            var model = await _jobAdertsService.GetListAsync();
            return View("FinanceJob", model);
        }
    }
}
