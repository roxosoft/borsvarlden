using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.ViewModels;
using borsvarlden.Models;

namespace borsvarlden.Extensions
{
    public static class FinwireNewsExtensions
    {
        public static NewsViewModel ToNewsViewModel(this FinwireNew newsItem)
        {
            var subtitle = newsItem.Subtitle;
            var subtitleMaxLength = 140;

            if (subtitle.Length >= subtitleMaxLength)
            {
                var index = subtitle.LastIndexOf(' ', subtitleMaxLength - 1);
                subtitle = subtitle.Substring(0, index) + "...";
            }
            return new NewsViewModel {

                Id = newsItem.Id,
                Title = newsItem.Title,
                Subtitle = subtitle,
                Date = newsItem.Date,
                NewsText = newsItem.NewsText,
                ImageUrl = newsItem.ImageRelativeUrl,
                Label = newsItem.ImageLabel,
                TittleSlug = newsItem.Slug,
                Guid = newsItem.Guid
            };
        }

        public static NewsViewModel ToNewsViewModelFromXml(this FinwireNew newsItem, List<string> companies, List<string> socialTags)
        {
            var output = ToNewsViewModel(newsItem);
            output.SocialTags = socialTags;
            output.Companies = companies;
            output.IsFromXml = true;
            return output;
        }
    }
}
