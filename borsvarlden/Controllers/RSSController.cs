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
        public async Task<IActionResult> Index()
        {
            var url = $"{Request.Scheme}://{Request.Host}";
            var feed = new SyndicationFeed(title: "Börsvärlden - Maximera din digitala synlighet",
                description: "Modern distributionskonsult inom börs, finans och trading med fokus på digital kommunikation, paketering och spridning av finansiella nyheter och koncept",
                feedAlternateLink: new Uri(url),
                id: "Börsvärlden",
                lastUpdatedTime: DateTime.Now);

            var baseNamespace = "http://www.w3.org/2000/xmlns/";

            XmlQualifiedName n = new XmlQualifiedName("content", baseNamespace);
          

            void AddNamespace(string nameSpaceName, string nameSpaceUrl)
                => feed.AttributeExtensions.Add(new XmlQualifiedName(nameSpaceName, "http://www.w3.org/2000/xmlns/"), nameSpaceUrl);

            var contentNs = "http://purl.org/rss/1.0/modules/content/";
            AddNamespace("content", contentNs);

            //feed.AttributeExtensions.Add(n, "http://purl.org/rss/1.0/modules/content/");

            feed.Copyright = new TextSyndicationContent($"{DateTime.Now.Year} Börsvärlden");



            var items = new List<SyndicationItem>();


            (await _finwireNewsService.GetNewsForFeedingWithPrio(20)).ForEach(x =>
            {

                var item = new SyndicationItem(x.Title, x.Subtitle, new Uri($@"{url}/artiklar/{x.Slug}"),
                    x.Id.ToString(), x.Date);
                //item.ElementExtensions.Add("fooTag", String.Empty, "foo2");
                var r = new XElement("guid", new XAttribute("isPermaLink", "false"));
                r.Value = $@"{url}/artiklar/{x.Id.ToString()}";

                item.ElementExtensions.Add(r.CreateReader());
                item.ElementExtensions.Add("encoded", contentNs, "foo");


                //var el = new XmlElement("","","");

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


                    //xmlWriter.WriteAttributeString("xmlns", "gx", null, "http://www.google.com/kml/ext/2.2");
                    rssFormatter.WriteTo(xmlWriter);
                    //const string xsi = "http://www.w3.org/2001/XMLSchema-instance";
                    //xmlWriter.WriteAttributeString("xmlns", "xsi", "http://www.w3.org/2000/xmlns/", xsi);

                    xmlWriter.Flush();
                }
                return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
            }
        }
    }
}
