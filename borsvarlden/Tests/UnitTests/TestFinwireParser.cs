using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using borsvarlden.Helpers;

namespace borsvarlden.Tests.UnitTests
{
    [TestFixture]
    public class TestFinwireParser
    {
        [TestCase()]
        public void TestParseAllFiles()
        {
            //TODO use realative
            //var path = @"f:\cs_proj\roxosoft_borsvarlden\finwire_files\test\";
            var file = @"f:\cs_proj\roxosoft_borsvarlden\finwire_files\test\FWM00427B9.xml";
            TestOneFile(file);
        }

        public void TestOneFile(string file)
        {
            var p = new FinwireFileParser();
            p.Parse(file);
        }

    }
}
