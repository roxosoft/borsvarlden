using System;
using System.Collections.Generic;
using System.Text;
using DBConverter;
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
    }
}
