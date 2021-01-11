using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.IndexGreenTagFeed
{
    public class IndexGreenTagFeed : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public IndexGreenTagFeed(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.IndexNewsCount;
            var model = await _finwireNewsService.GetGreenTagNewsForFeeding(newsCount);

            model.FirstBigBlockCount = _configurationHelper.FirstBigBlockCount;
            model.FirstSmallBlockCount = _configurationHelper.FirstSmallBlockCount;
            model.SecondBigBlockCount = _configurationHelper.SecondBigBlockCount;
            model.SecondSmallBlockCount = _configurationHelper.SecondSmallBlockCount;

            return View("IndexGreenTagFeed", model);
        }
    }
}
