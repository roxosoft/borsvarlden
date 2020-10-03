using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.HotStocks
{
    public class HotStocks : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public HotStocks(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.IndexNewsCount;
            var model = await _finwireNewsService.GetHotStocksForFeeding(newsCount);

            model.FirstBigBlockCount = 1;
            model.FirstSmallBlockCount = 3;

            return View("HotStocks", model);
        }
    }
}
