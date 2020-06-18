using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using borsvarlden.Tests.UnitTests.Config;
using DBConverter;
using DBConverter.Extensions;
using NUnit.Framework;

namespace borsvarlden.Tests.UnitTests.Tests.TestTools
{
    [TestFixture]
    class TestDBConverter
    {
        [TestCase("2018/04/bvfa-c-apple-0012.jpg")]
        public void TestToNewImageFilePath(string path)
        {
            var r = path.ToNewImageFilePath();
            path.ToNewImageFilePath();
        }

        [TestCase("2020/05/image0052-960x540.jpg")]
        public void TestImageSaver(string urlFragment)
        {
            ImageSaver.Save(urlFragment, @".\");
        }
        [TestCase("66056.html")]
        public void TestParseContent(string fileName)
        {
            var f = $@"{UnitTestConfig.TestDataPath}\ContentParse\{fileName}";
            var content = File.ReadAllText(f).ChangeImagePathInPost();
        }
    }
}
