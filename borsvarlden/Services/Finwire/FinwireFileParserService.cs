using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using borsvarlden.Helpers;
using borsvarlden.Extensions;


namespace borsvarlden.Services.Finwire
{
    public interface IFinwireParserService
    {
        Task<FinWireData> ParseFile(string pathToFile);
        Task<FinWireData> ParseXmlContent(string xmlContent);
    }

    public class FinwireFileParserService : IFinwireParserService
    {

        public FinwireFileParserService()
        {
            
        }

        public async Task<FinWireData> ParseFile(string pathToFile)
        {
            var content = await File.ReadAllTextAsync(pathToFile);
            return await ParseXmlContent(content);
        }

        public async Task <FinWireData> ParseXmlContent(string xmlContent)
        {
            return await Task.Run<FinWireData>(() =>
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);

                var item = xmlDocument.SelectSingleNode("item");

                var finWireData = new FinWireData
                {
                    Title = item.SelectSingleNode("title")?.InnerText,
                    Guid = item.SelectSingleNode("guid")?.InnerText,
                    Date = DateTime.Parse(item.SelectSingleNode("isoDate")?.InnerText,
                        System.Globalization.CultureInfo.CurrentCulture,
                        System.Globalization.DateTimeStyles.AdjustToUniversal),
                    NewsText = item.SelectSingleNode("newstext")?.InnerText?.Trim(),
                    SubTitle = item.SelectSingleNode("newstext")?.InnerText.FistParagraph(),
                    HtmlText = item.SelectSingleNode("htmltext")?.InnerText?.Trim(),
                    Agency = item.SelectSingleNode("agency")?.InnerText,
                    TittleSlug = item.SelectSingleNode("title")?.InnerText.ToSlug()
                }.BuildSubtitle();

                //todo Concat these all to methods with the delegate
                var socialTagsList = new List<string>();

                foreach (XmlElement el in item.SelectNodes("socialtags"))
                foreach (var singleSocialTag in el.SelectNodes("socialtag"))
                    socialTagsList.Add(((XmlNode) singleSocialTag).InnerText);

                if (socialTagsList.Count > 0)
                    finWireData.SocialTags = socialTagsList;

                var companies = new List<string>();

                foreach (XmlElement el in item.SelectNodes("companies"))
                foreach (var singleCompany in el.SelectNodes("company"))
                    companies.Add(((XmlElement) singleCompany).GetAttribute("name"));

                if (companies.Count > 0)
                    finWireData.Companies = companies;

                return finWireData;
            });
        }

    }

    public class FinWireData
    {
        public string Title { get; set; }
        public string Guid { get; set; }
        public DateTime Date { get; set; }
        public string NewsText { get; set; }
        public string HtmlText { get; set; }
        public string SubTitle { get; set; }
        public string Agency { get; set; }
        public string TittleSlug { get; set;}
        public List<string> SocialTags { get; set; }
        public List<string> Companies { get; set; }
        public bool IsValid => !String.IsNullOrEmpty(Guid);
    }
}
