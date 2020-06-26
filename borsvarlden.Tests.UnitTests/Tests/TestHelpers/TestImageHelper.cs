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


namespace borsvarlden.Tests.UnitTests.Tests.TestHelpers
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

        [TestCase("99", "FWM004E170.xml", @"\company\tesla", "Fordon")]
        [TestCase("99", "FWM004E10F.xml", @"\company\tencent", "Teknik")]
        [TestCase("99", "FWM004E1D6.xml", @"\company\facebook", "Teknik")]
        [TestCase("99", "FWM004E1E4.xml", @"\company\tesla", "Fordon")]
        [TestCase("99", "FWM004E1CF.xml", @"\company\tesla", "Fordon")]

        //Companies="Kina, USA" Socialtags="agriculture, commodities, fx, macro, politics"
        //Use Socialtag=agriculture (from company describing group socialtag).
        [TestCase("07", "FWM0042A85.xml", @"\socialtag\agriculture", "Jordbruk")]

        //Companies="Iran, USA" Socialtags="commodities, energy, fx, macro, oil, politics"
        //Commodities is the first socialtag exists. Also subtag oil exists
        [TestCase("03", "FWM0042947.xml", @"\socialtag\commodities\socialtag\oil\", "Olja")]

        //Companies="USA" Socialtags="fx, macro"
        //Company "USA" is single but not exists. Socialtag=macro exists, found company subtag
        [TestCase("02", "FWM00427B3.xml", @"\socialtag\macro\company\usa", "Makro")]

        //Companies="Qliro" Socialtags="consumergoods, ecommerce, retail, tech"
        //Compny single and found
        [TestCase("02", "FWM0042867.xml", @"\socialtag\ecommerce||\socialtag\retail", "ecommerce||retail")]

        //Companies="Xiaomi" Socialtags="tech""
        //Compny single and found
        [TestCase("02", "FWM004281E.xml", @"\company\xiaomi",  "Teknik")]

        //Companies="Cantargia" Socialtags="biotech, healthcare, insider, lifescience"
        //Company single not found. Socialtag healthcare found.
        [TestCase("08", "FWM0042BB5.xml", @"\socialtag\healthcare", "Sjukvård")]

        //Companies="Atlas Copco, Electrolux, Getinge, H&M, Handelsbanken, Nordea, SEB, SSAB, Swedbank, Telia" Socialtags="commodities, steel"
        //Companies multiple, not found. Socialtags coomdities found, no subtag found
        [TestCase("02", "FWM00427C4.xml", @"\socialtag\commodities", "Råvaror")]

        //Companies="Kina, Storbritannien" Socialtags="financials, fx, ipo, macro, politics, stocks"
        //Company not found, found socialtag=ipo, no subs
        [TestCase("02", "FWM0042815.xml", @"\socialtag\ipo", "IPO")]

        //Companies="Finansiella nyckeltal" Socialtags="commodities, currencies, energy, fx, macro, oil, stocks"
        //Company not found, found socialtag=commodities and found sub socialtag=oil
        [TestCase("02", "FWM0042847.xml", @"\socialtag\commodities\socialtag\oil", "Olja")]
        public void TestSpecificFile(string subfolder, string fileName, string resultDirPattern, string resultLabelPattern)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            string path = UnitTestHelper.GetTestFilePath(subfolder, fileName);
            var data = UnitTestHelper.ParseNewsFile(path);
            var debugString = $"Companies=\"{data.Companies.ElementsToString()}\" Socialtags=\"{data.SocialTags.ElementsToString()}\"";
            var imageDat= ImageHelper.GetImageData(data.SocialTags, data.Companies);
            if (resultDirPattern.Contains("||"))
            {
                bool bRes = false;
                resultDirPattern.Split("||").ToList().ForEach(x => bRes = bRes || imageDat.ImageAbsoluteUrl.Contains(x));
                Assert.IsTrue(bRes);
            }
            else
                Assert.IsTrue(imageDat.ImageAbsoluteUrl.Contains(resultDirPattern));

            if (resultLabelPattern.Contains("||"))
            {
                var bRes = false;
                resultLabelPattern.Split("||").ToList().ForEach(x => bRes = bRes || imageDat.Label == x);
            }
            else
                Assert.AreEqual(imageDat.Label, resultLabelPattern);

        }

        [TestCase(1)]
        public void TestAllFiles(int dummy)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            var pathBase = $@"{UnitTestConfig.TestDataPath}\FinwireFiles";

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

        [TestCase(@"f:\cs_proj\roxosoft_borsvarlden\master\borsvarlden\borsvarlden\wwwroot\wwwroot\assets\images\finauto\socialtag\macro\bvfa-s-macro-0028.jpg",
                  @"assets/images/finauto/socialtag/macro/bvfa-s-macro-0028.jpg")]

        [TestCase(@"f:\cs_proj\roxosoft_borsvarlden\master\borsvarlden\borsvarlden\wwwroot\assets\images\finauto\socialtag\macro\bvfa-s-macro-0028.jpg",
            @"assets/images/finauto/socialtag/macro/bvfa-s-macro-0028.jpg")]
        public void AbsoluteUrlToRelativeUrl(string inputPath, string outputPath)
        {
            Assert.AreEqual(outputPath, ImageHelper.AbsoluteUrlToRelativeUrl(inputPath));
        }
    }
}
