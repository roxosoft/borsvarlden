﻿using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace borsvarlden.Views.Shared.Components.SubscribeForm
{
    public class SubscribeForm : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;
        private readonly IConfigurationHelper _configurationHelper;

        public SubscribeForm(IFinwireNewsService finwireNewsService, IConfigurationHelper configurationHelper)
        {
            _finwireNewsService = finwireNewsService;
            _configurationHelper = configurationHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int newsCount = _configurationHelper.LatestNewsCount;

            List<NewsViewModel> model = await _finwireNewsService.GetNews(newsCount);

            return View("SubscribeForm", model);
        }
    }
}
