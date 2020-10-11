using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using borsvarlden.ViewModels;

namespace borsvarlden.Helpers
{
    public static class MetaHelper
    {
        private static readonly string IndexDescriptionContent = "Modern distributionskonsult inom börs, finans och trading med fokus på digital kommunikation, paketering och spridning av finansiella nyheter och koncept.";
        private static readonly string IndexTitleContent = "Börsvärlden - Maximera din digitala synlighet";
        private static readonly string ArticlesListDescriptionContent = "Börsnyheter, event, utbildningskurser och communitys med ledande börsprofiler.";

        public static string GetMetaNameDescription(string path)
        {
            if (IsRootPage(path))
                return GetMetaName("description", IndexDescriptionContent);

            return "";
        }

        public static string GetMetaPropertyOgDescription(string path, NewsViewModel newsViewModel)
        {
            if (IsRootPage(path))
                return GetMetaProperty("og:description", IndexDescriptionContent);

            if (IsArticle(path))
                return  GetMetaProperty("og:description", newsViewModel?.Subtitle ?? String.Empty);

            return "";
        }

        public static string GetMetaPropertyOgTitle(string path, NewsViewModel newsViewModel, dynamic viewData)
        {
            if (IsRootPage(path))
                return GetMetaProperty("og:title", IndexTitleContent);

            if (IsArticle(path))
                return GetMetaProperty("og:title", newsViewModel?.Title ?? String.Empty);

            if (IsArticlesList(path))
                return GetMetaProperty("og:title", (viewData["Title"] ?? String.Empty) + " - Börsvärlden");

            return "";
        }

        public static string GetMetaPropertyOgImage(string hostName, string path, NewsViewModel newsViewModel)
        {
            if (IsArticle(path))
            {
                if (newsViewModel.IsUseAzureStorage)
                    return GetMetaProperty("og:image", $"{newsViewModel.ImageUrl}".Replace("borsvarlden.blob.core.windows.net", hostName));
                else
                    return GetMetaProperty("og:image", $"https://{hostName}{newsViewModel.ImageUrl}");
            }
            else
                return GetMetaProperty("og:image", $"https://{hostName}/assets/images/meta/borsvarlden-facebook-share-image.jpg");
        }

        public static string GetMetaPropertyOgImageSecure(string hostName, string path, NewsViewModel newsViewModel)
        {
            if (IsArticle(path))
            {
                if (newsViewModel.IsUseAzureStorage)
                    return GetMetaProperty("og:image:secure_url", $"{newsViewModel.ImageUrl}".Replace("borsvarlden.blob.core.windows.net", hostName));
                else
                    return GetMetaProperty("og:image:secure_url", $"https://{hostName}{newsViewModel.ImageUrl}");
            }
            else
                return GetMetaProperty("og:image:secure_url", $"https://{hostName}/assets/images/meta/borsvarlden-facebook-share-image.jpg");
        }

        public static string GetMetaPropertyOgUrl(string hostName, string path, NewsViewModel newsViewModel)
        {
            if (IsArticle(path))
                return GetMetaProperty("og:url", $"https://{hostName}/artiklar/{newsViewModel.TittleSlug}");
            else
                return GetMetaProperty("og:url", $"https://{hostName}");
        }

        public static string GetMetaNameTwitterDescription(string path, NewsViewModel newsViewModel)
        {
            if (IsRootPage(path))
                return GetMetaName("twitter:description", IndexDescriptionContent);

            if (IsArticle(path))
                return GetMetaName("twitter:description", newsViewModel?.Subtitle ?? String.Empty);

            if (IsArticlesList(path))
                return GetMetaName("twitter:description", ArticlesListDescriptionContent);

            return "";
        }

        public static string GetMetaNameTwitterTitle(string path, NewsViewModel newsViewModel, dynamic viewData)
        {
            if (IsRootPage(path))
                return GetMetaName("twitter:title", IndexTitleContent);

            if (IsArticle(path))
                return GetMetaName("twitter:title", newsViewModel?.Title ?? String.Empty);

            if (IsArticlesList(path))
                return GetMetaProperty("twitter:title", (viewData["Title"] ?? String.Empty) + " - Börsvärlden");

            return "";
        }

        private static string GetMetaName(string name, string content) => $"<meta name=\"{name}\" content=\"{content}\" />";

        private static string GetMetaProperty(string property, string content) => $"<meta property=\"{property}\" content=\"{content}\" />";

        private static bool IsRootPage(string path) => path == "/";

        private static bool IsArticle(string path) => Regex.IsMatch(path,"artiklar/.+") && !path.Contains("artiklar/sida/") || path.Contains("/finwire/");

        private static bool IsArticlesList(string path) => path == "artiklar/" || path.Contains("artiklar/sida/");
    }
}
