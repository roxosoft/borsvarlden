using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using borsvarlden.Helpers;


namespace borsvarlden.Tests.UnitTests
{
    class TestImageHelper
    {
        [TestCase(1)]
        public void TestGetImage(int dummy)
        {
            ImageHelper.Init(UnitTestConfig.FinautoImagesPath);
            var res95 = ImageHelper.GetImageData(new List<string>() { "automotive"}, new List<string>());
            var res96 = ImageHelper.GetImageData(new List<string>() { "commodities", "oil"}, new List<string>());
            var res97 = ImageHelper.GetImageData(new List<string>() {"macro"}, new List<string>() { "usa" });
            var res98 = ImageHelper.GetImageData(new List<string>{"stockholmbullets"}, new List<string>());
            var res99 = ImageHelper.GetImageData(new List<string>(), new List<string> {"alibaba"}).ImageAbsoluteUrl;
        }
    }
}
