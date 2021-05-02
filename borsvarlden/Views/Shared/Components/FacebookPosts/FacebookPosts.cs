using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using HttpMethod = System.Net.Http.HttpMethod;

namespace borsvarlden.Views.Shared.Components.FinanceJob
{
    public class FacebookPosts : ViewComponent
    {
        private IHttpClientFactory _clientFactory;
        private IMemoryCache _memoryCache;
        private static int KeyPosts = 1;
        private static int HoursCaching = 4;
        public static CancellationTokenSource _resetCacheToken = new CancellationTokenSource();
        public FacebookPosts(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = clientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<FacebookViewModel> model;

            if (_memoryCache.TryGetValue(KeyPosts, out model))// Look for cache key.
            {
                return View("FacebookPosts", model);
            }

            model = new List<FacebookViewModel>();

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get,
                    "https://www.facebook.com/borsvarlden/posts");

                request.Headers.Add("User-Agent", "Apache-HttpClient/4.5.12 (Java/1.8.0_291)");

                var response = await _clientFactory.CreateClient().SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var pageDocument = new HtmlDocument();
                    pageDocument.LoadHtml(await response.Content.ReadAsStringAsync());

                    var nodes = pageDocument.DocumentNode.SelectNodes("(//div[contains(@class,'userContentWrapper')])");

                    if (nodes == null)
                        throw new ApplicationException("Wrong parsing Facebook");

                    nodes.Take(Math.Min(nodes.Count, 3)).ToList().ForEach(
                        x =>
                            model.Add(new FacebookViewModel
                            {
                                PostId = Regex.Match(x.InnerHtml, "borsvarlden/posts/([0-9]+)\"").Groups[1].Value,
                                Url = Regex.Match(x.InnerHtml, "<a href=\"https://l.facebook.com/l.php\\?u=([a-zA-Z0-9.%\\-]*)").Groups[1].Value
                            })
                        );
                }

               var entryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(HoursCaching));
                entryOptions.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));
                _memoryCache.Set(KeyPosts, model, entryOptions);
            }
            catch
            {
                //do nothing as it Facebook "plugin"
            }

            return View("FacebookPosts", model);
        }
    }
}
