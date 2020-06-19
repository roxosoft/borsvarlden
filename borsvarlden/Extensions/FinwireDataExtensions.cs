using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Helpers;
using borsvarlden.Models;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Extensions
{
    public static class FinwireDataExtensions
    { 
        private static Dictionary<DayOfWeek, string> _dictDaysOfWeek = new Dictionary<DayOfWeek, string>
        {
            { DayOfWeek.Monday,   "Måndagens" },
            { DayOfWeek.Tuesday,  "Tisdagens" },
            { DayOfWeek.Wednesday,"Onsdagens" },
            { DayOfWeek.Thursday, "Torsdagens" },
            { DayOfWeek.Friday,   "Fredagens" },
            { DayOfWeek.Saturday, "Lördagens" },
            { DayOfWeek.Sunday,   "Söndagens" }
        };

        public static FinWireData BuildSubtitle(this FinWireData finwireData)
        {
            var paragraphDelimeter = "<br/><br/>";
            var splitedEls = finwireData.NewsText.Split(paragraphDelimeter);

            finwireData.SubTitle = splitedEls[0];
            //if single paragraph do nothing
            if (splitedEls.Length > 1)
            {
                finwireData.NewsText = finwireData.NewsText.Remove(0, splitedEls[0].Length+ paragraphDelimeter.Length);
            }

            return finwireData;
        }

        public static FinWireData PostProcessTitle(this FinWireData finwireData)
        {
            finwireData = finwireData.ParseStockRecommendationsDayOfWeek();
            finwireData.Title = finwireData.Title
                .ReplaceStockholmBullets()
                .Remove("(R)")
                .Trim();
            
            return finwireData;
        }

        public static string ReplaceStockholmBullets(this string input)
        {
            return input.Replace("Stockholm Bullets", "Stocks in Play");
        }

        //ported by original finauto_publish.php started line 82
        public static FinWireData ParseStockRecommendationsDayOfWeek(this FinWireData finWireData)
        {
            if (finWireData.Title.Contains("Dagens aktierekommendationer i översikt") ||
                finWireData.Title.Contains("Dagens aktierekomendationer i översikt"))
            {
                finWireData.Title =
                    $"{_dictDaysOfWeek[finWireData.Date.DayOfWeek]} aktierekommendationer i översikt";

                finWireData.HtmlText = "<p>En kort sammanställning av de rekommendationsnyheter som Finwire News har rapporterat om hittills idag, med nyheter som rör...</p>" +
                            finWireData.HtmlText.Replace("I tabellen nedan visas ett axplock av de rekommendationsnyheter som Finwire News har rapporterat om i dag.",
                                                         "I tabellen nedan visas ett axplock av dagens rekommendationsnyheter.");
            }

            return finWireData;
        }

        public static FinwireNew ToFinwireNews(this FinWireData finwireData)
        {
            var imgData = ImageHelper.GetImageData(finwireData.SocialTags, finwireData.Companies);

            var r = new FinwireNew
            {
                Guid = finwireData.Guid,
                Title = finwireData.Title,
                Subtitle = finwireData.SubTitle,
                Date = finwireData.Date,
                NewsText = finwireData.HtmlText,
                ImageRelativeUrl = ImageHelper.AbsoluteUrlToRelativeUrl(imgData.ImageAbsoluteUrl),
                ImageSource = imgData.ImageSource,
                ImageLabel = imgData.Label,
                Slug = finwireData.TittleSlug,
                IsFinwireNews = true
            };
            return r;
        }

    }
}
