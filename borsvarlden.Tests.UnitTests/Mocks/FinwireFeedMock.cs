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
        private static readonly string ServerName = "localhost";
        private static readonly int Port = 5001;

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("08", "FWM0042BB5.xml")]
        public void TestSingleRequest(string subfolder, string fileName)
        {
            var endPointUrl = $"https://{ServerName}:{Port}/api/updatenews";

            string path = UnitTestHelper.GetTestFilePath(subfolder, fileName);
            var xmlContent = File.ReadAllText(path);
            var guid = UnitTestHelper.ParseNewsContent(xmlContent).Guid;

            var postData = $"xml={System.Web.HttpUtility.UrlEncode(xmlContent)}&uid={ System.Web.HttpUtility.UrlEncode(guid)}";
           // postData = System.Web.HttpUtility.UrlEncode(postData);
            var res = RestConnector.GetData(endPointUrl, "POST", postData);
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