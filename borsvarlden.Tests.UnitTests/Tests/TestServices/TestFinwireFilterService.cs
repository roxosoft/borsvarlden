using System;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text;
using borsvarlden.Db;
using borsvarlden.Services.Entities;
using borsvarlden.Services.Finwire;
using borsvarlden.Tests.UnitTests.Config;
using borsvarlden.Tests.UnitTests.Helpers;

namespace borsvarlden.Tests.UnitTests.Tests.TestServices
{
    [TestFixture]
    class TestFinwireFilterService
    {
        private FinwireFilterService _finwireFilterService = new FinwireFilterService(SetUp.ApplicationContext);

        [SetUp]
        public void Setup()
        {
         
        }

        [TestCase(0)]
        public void ProcessMultipleFiles(int dummy)
        {
            var pathBase = $@"{UnitTestConfig.TestDataPath}\FinwireFiles";
            var stMatched = "";

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}\{i.ToString("D2")}";
                foreach (var file in Directory.GetFiles(path))
                {
                    if  (_finwireFilterService.IsFilterPassed(UnitTestHelper.ParseNewsFile(file)))
                        stMatched += $"{file}\n" ;
                }
            }
        }

        [TestCase("A<br><br>BC<br><br><br><br>", false)]
        [TestCase("Under perioden 4 - 25 maj 2020 hade innehavare av teckningsoptioner av serie 2020 kunnat teckna aktier med stöd av teckningsoptioner.<br><br>Totalt nyttjades 3 097 892 teckningsoptioner av serie 2020, vilket motsvarar en nyttjandegrad om cirka 64 procent, motsvarande 774 473 aktier. <br><br> <br><br>",false)]
        [TestCase("ABC<br><br><br>", false)]
        public void TestContentFilterPassed(string content, bool expected)
        {
            //Esen Esports meddelar utfall för nyttjande av teckningsoptioner av serie 2020
            Assert.AreEqual(expected, _finwireFilterService.IsContentFilterPassed(content));
        }

        [TestCase(false, "02", "FWM00427AA.xml")]
        [TestCase(true,  "02", "FWM00427AC.xml")]
        [TestCase(true,  "02", "FWM004284C.xml")] //Title="Stockholm Bullets" Companies="Stockholm Bullets" SocialTags="calendar"
        public void TestIsPassedSingleFile(bool expectedResult, string subdir, string fileName)
        {
            string path = $@"{UnitTestConfig.TestDataPath}\FinwireFiles\{subdir}\{fileName}";
            var data = UnitTestHelper.ParseNewsFile(path);
            bool bResProcessed = _finwireFilterService.IsFilterPassed(data);
            Assert.AreEqual(expectedResult, bResProcessed);
        }

        [TestCaseSource("CountIsFilterPassedTest")]
        public void TestIsPassed (Tuple<bool, FinWireData> inputData)
        {
            Assert.AreEqual(inputData.Item1, _finwireFilterService.IsFilterPassed(inputData.Item2));
        }

        public static IEnumerable<Tuple<bool,FinWireData>> CountIsFilterPassedTest
        {
            get { yield return new Tuple<bool, FinWireData>(false, new FinWireData() {Title = "foo"}); }
        }

        [TestCase(1)]
        public  void TestSocialTags(int dummyForTest)
        {
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "analytics" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "Analytics" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "betting" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "biometrics" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "commodities" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "crowdfunding" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "cryptocurrency" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "dividend" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "funding" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "gaming" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "ipo" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "macro" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "share" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "stockholmbullets" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "tech" }));
            Assert.AreEqual(false, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "Analytics!" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "analytics", "automotive" }));
            Assert.AreEqual(true, _finwireFilterService.IsSocialTagsWhiteListFilterPassed(new List<string> { "analytics", "foo" }));
        }

        [TestCase(1)]
        public void TestSocialCompanies(int dummyForTest)
        {
            Assert.AreEqual(true, _finwireFilterService.IsCompaniesWhiteListPassed(new List<string> { "avanza" }));
            Assert.AreEqual(true, _finwireFilterService.IsCompaniesWhiteListPassed(new List<string> { "nordent" }));
            Assert.AreEqual(true, _finwireFilterService.IsCompaniesWhiteListPassed(new List<string> { "hm" }));
        }

        [TestCase("Dagens aktierekommendationer i översikt", true)]
        [TestCase("Dagens aktierekommendationer I översikt", true)]
        [TestCase("Stocks in Play", true)]
        [TestCase("Stockholm Bullets", true)]
        [TestCase("foo", false)]
        public void TestFilterTagWhiteList(string tag, bool expectedResult)
        {
            Assert.AreEqual(expectedResult,_finwireFilterService.IsTitleWhiteListPassed(tag) );
        }

        [TestCase("Mekonomen rapporterar förlust för första kvartalet (uppdatering)", true)]
        [TestCase("(uppdatering)", true)]
        [TestCase("(uppdaterad)", true)]
        [TestCase("(Oms)", true)]
        [TestCase("(forts)", true)]
        [TestCase("(omsändning)", true)]
        [TestCase("(r)", true)]
        [TestCase("(rättelse)", true)]
        [TestCase("foo", false)]
        public void TestFilterTitleBlackListNotPassed(string tag, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, _finwireFilterService.IsTitleBlackFilterNotPassed(tag));
        }

        [TestCase(true,  "99", "FWM004CDA4.xml")]
        [TestCase(true,  "29", "FWM004CF9F.xml")]
        [TestCase(false, "01", "FWM00427B9.xml")]
        [TestCase(true,  "02", "FWF0042896.xml")]
        [TestCase(true,  "08", "FWM0042B9E.xml")]
        public void TestSingleFileFilterContent(bool expectedResult,string subdir,  string fileName)
        {
            string path = $@"{UnitTestConfig.TestDataPath}\FinwireFiles\{subdir}\{fileName}";
         
            var contentParsed = UnitTestHelper.ParseNewsFile(path).HtmlText;
            bool bResProcessed = _finwireFilterService.IsContentFilterPassed(contentParsed);
            Assert.AreEqual(expectedResult, bResProcessed);
        }
    }
}
