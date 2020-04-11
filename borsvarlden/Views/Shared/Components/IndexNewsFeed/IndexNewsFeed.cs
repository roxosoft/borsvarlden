using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.IndexNewsFeed
{
    public class IndexNewsFeed : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public IndexNewsFeed(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.IndexNewsCount;
            var model = await _finwireNewsService.GetMainNews(newsCount);

            model.FirstBigBlockCount = _configurationHelper.FirstBigBlockCount;
            model.FirstSmallBlockCount = _configurationHelper.FirstSmallBlockCount;
            model.SecondBigBlockCount = _configurationHelper.SecondBigBlockCount;
            model.SecondSmallBlockCount = _configurationHelper.SecondSmallBlockCount;

            return View("IndexNewsFeed", model);
        }
    }
}
