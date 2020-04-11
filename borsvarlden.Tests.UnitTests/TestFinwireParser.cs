using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Tests.UnitTests
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
                }
            }
        }

        [TestCase]
        public void TestSpecificFile()
        {
            TestOneFile(@"f:\cs_proj\roxosoft_borsvarlden\finwire_files\test\08\FWM0042BB5.xml");
        }

        public FinWireData TestOneFile(string file)
        {
            var p = new FinwireFileParserService();
            return p.Parse(file);
        }
    }
}