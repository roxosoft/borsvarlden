using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using borsvarlden.Db;


namespace borsvarlden.Helpers
{
   
    public class FinwireFileParser
    {

        public FinWireData Parse(string pathToFile)
        {
            var content =  File.ReadAllText(pathToFile);

             var xmlDocument = new XmlDocument();
             xmlDocument.LoadXml(content);

             var item = xmlDocument.SelectSingleNode("item");
           

            var finWireDate = new FinWireData
            {
                Title = item.SelectSingleNode("type")?.InnerText,
                Guid = item.SelectSingleNode("guid")?.InnerText,
                Date = DateTime.Parse(item.SelectSingleNode("isoDate")?.InnerText, System.Globalization.CultureInfo.CurrentCulture,
                                        System.Globalization.DateTimeStyles.AdjustToUniversal),
                NewsText = item.SelectSingleNode("newstext")?.InnerText,
                Agency = item.SelectSingleNode("agency")?.InnerText
            };


            var socialTags = new List<string>();

            foreach (XmlElement el in item.SelectNodes("socialtags"))
                 socialTags.Add(el.InnerText);

            if (socialTags.Count > 0)
                 finWireDate.SocialTags = socialTags;

            var companies = new List<string>();

            foreach (XmlElement el in item.SelectNodes("companies"))
                 companies.Add(el.InnerText);

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
