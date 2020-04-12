using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using borsvarlden.Helpers;

namespace borsvarlden.Tests.UnitTests
{
    [TestFixture]
    class TestHtmlHelper
    {
        private static string HtmlHelperInputPath => $@"{UnitTestConfig.TestDataPath}\HtmlHelper\Input";
        private static string HtmlHelperOuputPath => $@"{UnitTestConfig.TestDataPath}\HtmlHelper\Output";

      
        [TestCase("TestDataWpAutoP_01.txt")]
        [TestCase("TestDataWpAutoP_02.txt")]
        public void TestWpAutoP(string testDataFile)
        {
            var orininalText = File.ReadAllText($@"{HtmlHelperInputPath}\{testDataFile}");
            var expectedText = File.ReadAllText($@"{HtmlHelperOuputPath}\{testDataFile}");
            var processedText = HtmlHelper.WpAutoP(orininalText,true);
            Assert.Equals(expectedText, processedText);
        }

        [TestCase("TestDataFilterContent_01.txt")]
        public void TestFilterContent(string testFilterContent)
        {
            var originalText = File.ReadAllText($@"{HtmlHelperInputPath}\{testFilterContent}");
            var processedText = HtmlHelper.FilterContent(originalText);
        }
    }
}
