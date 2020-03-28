using System.Collections.Generic;
using NUnit.Framework;
using borsvarlden.Helpers;
using System.IO;

namespace borsvarlden.Tests.UnitTests
{
    [TestFixture]
    public class TestsFinwireFileParser
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void TestParseAllFiles()
        { 
            //TODO use realative path 
            var pathBase = @"f:\cs_proj\roxosoft_borsvarlden\finwire_files\test\";

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}{i.ToString("D2")}";
                var res = TestOneFile(Directory.GetFiles(path)[0]);
                Assert.IsTrue(res.IsValid);
                Assert.IsNotNull(res.Guid);
            }
        }

        public FinWireData TestOneFile(string file)
        {
            var p = new FinwireFileParser();
            return p.Parse(file);
        }
    }
}