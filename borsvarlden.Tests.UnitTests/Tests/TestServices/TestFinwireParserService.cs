﻿using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using borsvarlden.Services.Finwire;
using borsvarlden.Tests.UnitTests.Config;
using borsvarlden.Tests.UnitTests.Helpers;

namespace borsvarlden.Tests.UnitTests.Tests.TestServices
{
    [TestFixture]
    public class TestsFinwireFileParser
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1)]
        public void TestParseAllFiles(int dummy)
        {
            var pathBase = $@"{UnitTestConfig.TestDataPath}\FinwireFiles";

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}\{i.ToString("D2")}";

                foreach (var file in Directory.GetFiles(path))
                {
                    var res = TestOneFile(file);
                    Assert.IsTrue(res.IsValid);
                    Assert.IsNotNull(res.Guid);
                    Assert.IsFalse(string.IsNullOrEmpty(res.SubTitle));
                }
            }
        }

        [TestCase("99", "FWM004E1B1.xml")]
        [TestCase("29", "FWS004CF9A.xml")]
        [TestCase("08", "FWM0042BB5.xml")]
        public void TestSpecificFile(string subfolder, string fileName)
        {
            string path = UnitTestHelper.GetTestFilePath(subfolder, fileName);
            TestOneFile(path);
        }

        public FinWireData TestOneFile(string file)
        {
            return UnitTestHelper.ParseNewsFile(file);
        }
                                            
        [TestCase("FWM004CDF7.xml", "Torsdagens aktierekommendationer i översikt")]
        public void ParseStockRecommendationsDayOfWeek(string filename, string expectedTitle)
        {
            var pathfile = $@"{UnitTestConfig.TestDataPath}\Specific\{filename}";
            var data = UnitTestHelper.ParseNewsFile(pathfile);
            Assert.AreEqual(expectedTitle, data.Title);
        }
    }
}