using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Helpers;
using borsvarlden.ViewModels;
using borsvarlden.Models;

namespace borsvarlden.Extensions
{
    public static class FinwireNewsExtensions
    {
        public static NewsViewModel ToNewsViewModel(this FinwireNew newsItem)
        {
            return new NewsViewModel 
            {
                Id = newsItem.Id,
                Title = newsItem.Title,
                Subtitle = newsItem.Subtitle,
                Date = newsItem.Date.ToDisplayTime(),
                NewsText = newsItem.NewsText,
                ImageUrl = (newsItem.IsUseAzureStorage ? newsItem.ImageRelativeUrl : String.Format("/{0}", newsItem.ImageRelativeUrl)),
                ImageLabel = newsItem.Label != null ? newsItem.Label : newsItem.ImageLabel,
                TittleSlug = newsItem.Slug,
                Guid = newsItem.Guid,
                IsFinwireNews = newsItem.IsFinwireNews,
                CompanyName = newsItem.CompanyName,
                IsAdvertising = newsItem.IsAdvertising,
                CopyrightLabel = newsItem.IsBorsvarldenArticle ? "Börsvärlden" : "Finwire / Börsvärlden",
                Label = newsItem.Label,
                ImageSource = newsItem.ImageSource,
                IsUseAzureStorage = newsItem.IsUseAzureStorage
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

        public static IQueryable<FinwireNew> GetPublic(this IQueryable<FinwireNew> inp)
        {
            return inp.Where(x => !x.IsBorsvarldenArticle ||
                                  (
                                    x.IsBorsvarldenArticle && x.IsPublished && 
                                    (x.DateStartVisible == default(DateTime) ||  TimeHelper.Time >= x.DateStartVisible) &&
                                    (!x.Is15MinutesVideo || (x.Is15MinutesVideo && TimeHelper.Time < x.VideoVisibleDeadLine))
                                  )
                            );
        }
    }
}
