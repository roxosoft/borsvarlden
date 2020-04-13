using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using borsvarlden.Helpers;
using borsvarlden.Tests.UnitTests.Helpers;


namespace borsvarlden.Tests.UnitTests
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

        [TestCase("08", "FWM0042BB5.xml","healthcare")]
        public void TestSpecificFile(string subfolder, string fileName, string resultPattern)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            string path = UnitTestHelper.GetTestFilePath(subfolder, fileName);
            var data = UnitTestHelper.ParseNewsFile(path);
            var r= ImageHelper.GetImageData(data.SocialTags, data.Companies);
            Assert.IsTrue(r.ImageAbsoluteUrl.Contains(resultPattern));
        }

        [TestCase(1)]
        public void TestAllFiles(int dummy)
        {
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
                    var data = UnitTestHelper.ParseNewsFile(path);

                    if (data.Companies.Count > 1)
                        System.Threading.Thread.Sleep(0);
                }
            }
        }
    }
}
