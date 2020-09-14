using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using borsvarlden.Services.Entities;
using borsvarlden.Extensions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace borsvarlden.Controllers
{
    public class RSSController : Controller
    {

        private IFinwireNewsService _finwireNewsService;

        public RSSController(IFinwireNewsService finwireNewsService)
        {
            _finwireNewsService = finwireNewsService;
        }

        [ResponseCache(Duration = 1200)]
        [HttpGet]
        [Route("feed/borskollen")]
        public async Task<IActionResult> Index()
        {
            var urlSiteRoot = $"{Request.Scheme}://{Request.Host}";
            var feed = new SyndicationFeed(title: "Börsvärlden",
                description: "Modern distributionskonsult inom börs, finans och trading med fokus på digital kommunikation, paketering och spridning av finansiella nyheter och koncept",
                feedAlternateLink: new Uri(urlSiteRoot),
                id: "Börsvärlden",
                lastUpdatedTime: DateTime.Now);

            void AddNamespace(string nameSpaceName, string nameSpaceUrl)
                => feed.AttributeExtensions.Add(new XmlQualifiedName(nameSpaceName, "http://www.w3.org/2000/xmlns/"), nameSpaceUrl);

            var contentNs = "http://purl.org/rss/1.0/modules/content/";
            var wfwNs = "http://wellformedweb.org/CommentAPI/";
            var dcNs = "http://purl.org/dc/elements/1.1/";
            var atomNs = "http://www.w3.org/2005/Atom";
            var syNs = "http://purl.org/rss/1.0/modules/syndication/";
            var slashNs = "http://purl.org/rss/1.0/modules/slash/";

            AddNamespace("content", contentNs);
            AddNamespace("wfw", wfwNs);
            AddNamespace("dc", dcNs);
            AddNamespace("atom", atomNs);
            AddNamespace("sy", syNs);
            AddNamespace("slash", slashNs);

            feed.ElementExtensions.Add("updatePeriod", syNs, "hourly");
            feed.ElementExtensions.Add("updateFrequency", syNs, "12");
            feed.ElementExtensions.Add("language", String.Empty, "en-US");
            XNamespace atom = "http://www.w3.org/2005/Atom";
            feed.ElementExtensions.Add(new XElement(atom + "link",
                new XAttribute("href", $"{urlSiteRoot}/feed/borskollen"),
                new XAttribute("rel", "self"),
                new XAttribute("type", "application/rss+xml")));
            var xmlImage = new XElement("image");

            void AddChildToImage(string name, string value)
            {
                var childUrl = new XElement(name);
                childUrl.Value = value;
                xmlImage.Add(childUrl);
            }

            AddChildToImage("url", $"{urlSiteRoot}/assets/uploads/2016/10/borsvarlden_logo_rss.png");
            AddChildToImage("title", "Börsvärlden");
            AddChildToImage("link", urlSiteRoot);
            AddChildToImage("width", "144");
            AddChildToImage("height","144");

            feed.ElementExtensions.Add(xmlImage);
            var items = new List<SyndicationItem>();

            (await _finwireNewsService.GetNewsForFeedingWithPrio(20)).ForEach(x =>
                {
                    var item = new SyndicationItem(title:x.Title,x.Subtitle, new Uri($@"{urlSiteRoot}/artiklar/{x.Slug}"),
                        x.Id.ToString(), x.Date);
                    var guid = new XElement("guid", new XAttribute("isPermaLink", "false"));
                    guid.Value = $@"{urlSiteRoot}/artiklar/{x.Id.ToString()}";
                    item.ElementExtensions.Add(guid.CreateReader());
                    item.ElementExtensions.Add(new XElement("enclosure", 
                                           new XAttribute("url", $"{urlSiteRoot}/{x.ImageRelativeUrl}"), 
                                           new XAttribute("type","image/jpg")));
                    item.ElementExtensions.Add("pubDate", String.Empty, x.Date.ToDisplayTime().ToString("ddd, dd MMM yyyy HH:mm:ss zzz"));
                    item.ElementExtensions.Add("creator", dcNs, "<![CDATA[Börsvärlden]]>");
                    item.ElementExtensions.Add("encoded", contentNs, $"<![CDATA[{x.NewsText}]]>");
                    item.ElementExtensions.Add("commentRss", wfwNs, $"{urlSiteRoot}/artiklar/{x.Slug}");
                    item.ElementExtensions.Add("comments", slashNs, "0");
                    items.Add(item);
                }
            );

            feed.Items = items;
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NewLineHandling = NewLineHandling.Entitize,
                NewLineOnAttributes = true,
                Indent = true
            };
            using (var stream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(stream, settings))
                {
                    var rssFormatter = new Rss20FeedFormatter(feed, false);
                    rssFormatter.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                }
                return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
            }
        }
    }
}
