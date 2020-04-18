using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using borsvarlden.Helpers;
using borsvarlden.Extensions;
using borsvarlden.Tests.UnitTests.Config;
using borsvarlden.Tests.UnitTests.Helpers;


namespace borsvarlden.Tests.UnitTests.Tests
{
    class TestImageHelper
    {
        [TestCase(1)]
        public void TestGetImage(int dummy)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            var res95 = ImageHelper.GetImageData(new List<string>() {"automotive"}, new List<string>());
            var res96 = ImageHelper.GetImageData(new List<string>() {"commodities", "oil"}, new List<string>());
            var res97 = ImageHelper.GetImageData(new List<string>() {"macro"}, new List<string>() {"usa"});
            var res98 = ImageHelper.GetImageData(new List<string> {"stockholmbullets"}, new List<string>());
            var res99 = ImageHelper.GetImageData(new List<string>(), new List<string> {"alibaba"}).ImageAbsoluteUrl;
        }

        //Companies="Kina, USA" Socialtags="agriculture, commodities, fx, macro, politics"
        //Use Socialtag=agriculture (from company describing group socialtag).
        [TestCase("07", "FWM0042A85.xml", @"\socialtag\agriculture")]

        //Companies="Iran, USA" Socialtags="commodities, energy, fx, macro, oil, politics"
        //Commodities is the first socialtag exists. Also subtag oil exists
        [TestCase("03", "FWM0042947.xml", @"\socialtag\commodities\socialtag\oil\")]

        //Companies="USA" Socialtags="fx, macro"
        //Company "USA" is single but not exists. Socialtag=macro exists, found company subtag
        [TestCase("02", "FWM00427B3.xml", @"\socialtag\macro\company\usa")]

        //Companies="Qliro" Socialtags="consumergoods, ecommerce, retail, tech"
        //Compny single and found
        [TestCase("02", "FWM0042867.xml", @"\socialtag\ecommerce||\socialtag\retail")]

        //Companies="Xiaomi" Socialtags="tech""
        //Compny single and found
        [TestCase("02", "FWM004281E.xml", @"\company\xiaomi")]

        //Companies="Cantargia" Socialtags="biotech, healthcare, insider, lifescience"
        //Company single not found. Socialtag healthcare found.
        [TestCase("08", "FWM0042BB5.xml", @"\socialtag\healthcare")]

        //Companies="Atlas Copco, Electrolux, Getinge, H&M, Handelsbanken, Nordea, SEB, SSAB, Swedbank, Telia" Socialtags="commodities, steel"
        //Companies multiple, not found. Socialtags coomdities found, no subtag found
        [TestCase("02", "FWM00427C4.xml", @"\socialtag\commodities")]

        //Companies="Kina, Storbritannien" Socialtags="financials, fx, ipo, macro, politics, stocks"
        //Company not found, found socialtag=ipo, no subs
        [TestCase("02", "FWM0042815.xml", @"\socialtag\ipo")]

        //Companies="Finansiella nyckeltal" Socialtags="commodities, currencies, energy, fx, macro, oil, stocks"
        //Company not found, found socialtag=commodities and found sub socialtag=oil
        [TestCase("02", "FWM0042847.xml", @"\socialtag\commodities\socialtag\oil")]
        public void TestSpecificFile(string subfolder, string fileName, string resultPattern)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            string path = UnitTestHelper.GetTestFilePath(subfolder, fileName);
            var data = UnitTestHelper.ParseNewsFile(path);
            var debugString = $"Companies=\"{data.Companies.ElementsToString()}\" Socialtags=\"{data.SocialTags.ElementsToString()}\"";
            var imageDat= ImageHelper.GetImageData(data.SocialTags, data.Companies);
            if (resultPattern.Contains("||"))
            {
                bool bRes = false;
                resultPattern.Split("||").ToList().ForEach(x => bRes = bRes || imageDat.ImageAbsoluteUrl.Contains(x));
                Assert.IsTrue(bRes);
            }
            else
                Assert.IsTrue(imageDat.ImageAbsoluteUrl.Contains(resultPattern));
        }

        [TestCase(1)]
        public void TestAllFiles(int dummy)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            var pathBase = $@"{UnitTestConfig.TestDataPath}\FinwireFiles";
            string st = "";

            var occurenceInFiles = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}\{i.ToString("D2")}";

                Dictionary<string, int> patternOccurence = new Dictionary<string, int>();
                //patterns.ForEach(pattern => patternOccurence[pattern] = 0);

                foreach (var file in Directory.GetFiles(path))
                {
                    var data = UnitTestHelper.ParseNewsFile(file);
                    if (data.SocialTags == null || data.Companies == null)
                        continue;

                    var imageDat = ImageHelper.GetImageData(data.SocialTags, data.Companies);
                    //if (data.Companies?.Count > 10)
                    //  System.Threading.Thread.Sleep(0);
                    //if (data.SocialTags?.Count > 5)
                    //  System.Threading.Thread.Sleep(0);

                    if (data.Companies?.Count == 1)
                      {
                         
                      }
                }
            }
        }
    }
}
