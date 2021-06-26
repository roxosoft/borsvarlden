using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace borsvarlden.Views.Shared.Components.IndexGreenTagFeed
{
    using ViewModels;
    public class IndexGreentagRight : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public IndexGreentagRight(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _finwireNewsService.GetAdvertiseNewsList(_configurationHelper.IndexNewsCount);
            model.AddRange(await _finwireNewsService.GetMostReadNews(_configurationHelper.MostReadNewsCount, -1));
            model.AddRange(await _finwireNewsService.GetNews(_configurationHelper.LatestNewsCount));

            return View("IndexGreenTagRight", model.GroupBy(x => x.Id)
                                                    .Select(x => x.First())
                                                    .ToList());
        }
    }
}
