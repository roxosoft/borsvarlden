using System;
using System.Collections.Generic;
using System.Text;
using borsvarlden.Services.Finwire;
using borsvarlden.Tests.UnitTests.Config;

namespace borsvarlden.Tests.UnitTests.Helpers
{
    public static class UnitTestHelper
    { 
        public static string GetTestFilePath(string substring, string fileName) =>  $@"{UnitTestConfig.TestDataPath}\FinwireFiles\{substring}\{fileName}";
        public static FinWireData ParseNewsFile(string path) => new FinwireFileParserService().ParseFile(path).Result;
        public static FinWireData ParseNewsContent(string content) => new FinwireFileParserService().ParseXmlContent(content).Result;
    }
}
