using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace borsvarlden.Services.Finwire
{
    public interface IFinwireParserService
    {
        FinWireData Parse(string path);
    }

    public class FinwireFileParserService : IFinwireParserService
    {
        public FinwireFileParserService()
        {

        }

        public FinWireData Parse(string pathToFile)
        {
            var content = File.ReadAllText(pathToFile);

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(content);

            var item = xmlDocument.SelectSingleNode("item");

            var finWireDate = new FinWireData
            {
                Title = item.SelectSingleNode("title")?.InnerText,
                Guid = item.SelectSingleNode("guid")?.InnerText,
                Date = DateTime.Parse(item.SelectSingleNode("isoDate")?.InnerText, System.Globalization.CultureInfo.CurrentCulture,
                                        System.Globalization.DateTimeStyles.AdjustToUniversal),
                NewsText = item.SelectSingleNode("newstext")?.InnerText,
                Agency = item.SelectSingleNode("agency")?.InnerText
            };

            //todo Concat these all to methods with the delegate
            var socialTagsList = new List<string>();

            foreach (XmlElement el in item.SelectNodes("socialtags"))
                foreach (var singleSocialTag in el.SelectNodes("socialtag"))
                    socialTagsList.Add(((XmlNode)singleSocialTag).InnerText);

            if (socialTagsList.Count > 0)
                finWireDate.SocialTags = socialTagsList;

            var companies = new List<string>();

            foreach (XmlElement el in item.SelectNodes("companies"))
                foreach (var singleCompany in el.SelectNodes("company"))
                    companies.Add(((XmlElement)singleCompany).GetAttribute("name"));

            if (companies.Count > 0)
                finWireDate.Companies = companies;

            return finWireDate;
        }
    }

    public class FinWireData
    {
        public string Title { get; set; }
        public string Guid { get; set; }
        public DateTime Date { get; set; }
        public string NewsText { get; set; }
        public string Agency { get; set; }
        public List<string> SocialTags { get; set; }
        public List<string> Companies { get; set; }
        public bool IsValid => !String.IsNullOrEmpty(Guid);
    }
}
