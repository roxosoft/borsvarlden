using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;
using borsvarlden.Services.Finwire;
using borsvarlden.Tests.UnitTests.Config;
using borsvarlden.Tests.UnitTests.Helpers;

namespace borsvarlden.Tests.UnitTests.Mocks
{
    public class FinwireFeedMock
    {
        private static readonly bool _useWanAddress = false;
        private static readonly string ServerNameLocal = "localhost";
        private static readonly string ServerNameWan = "borsvarlden.azurewebsites.net"; //"borsvarlden.conveyor.cloud";
        private static readonly int PortLocal = 5001;
        private static readonly string ServerName = _useWanAddress ? ServerNameWan : ServerNameLocal  ;
        private static readonly string PortSuffix = _useWanAddress ? "" : $":{PortLocal}";
        
        private static readonly string _endPointUrl = $"https://{ServerName}{PortSuffix}/api/updatenews";

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("08", "FWM0042BB5.xml")]
        public void TestSingleRequest(string subfolder, string fileName)
        {
            string path = UnitTestHelper.GetTestFilePath(subfolder, fileName);
            var xmlContent = File.ReadAllText(path);
            var guid = UnitTestHelper.ParseNewsContent(xmlContent).Guid;

            var postData = $"xml={System.Web.HttpUtility.UrlEncode(xmlContent)}&uid={ System.Web.HttpUtility.UrlEncode(guid)}";
            var res = RestConnector.GetData(_endPointUrl, "POST", postData);
            Assert.AreEqual("OK", res);
        }

        [TestCase("1")]
        public void TestMultipleRequest(int dummy)
        {
            var pathBase = $@"{UnitTestConfig.TestDataPath}\FinwireFiles";

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;
                var subfolder = i.ToString("D2");
                var path = $@"{pathBase}\{i.ToString("D2")}";

                foreach (var file in Directory.GetFiles(path))
                {
                    var fileName = Path.GetFileName(file);
                    TestSingleRequest(subfolder, fileName);
                }

            }
        }
    }
}