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

        [TestCase("<p>Under kriser kan det som annars skulle vara omöjligt visa sig möjligt. Dessvärre har Kina och USA missat tillfället att återbygga den försämrade relationen och i stället fortsätter den att förvärras. Vissa bedömare hävdar till och med att relationen länderna emellan redan idag är den sämsta någonsin sedan de diplomatiska banden slöts år 1979.</p><p>Covid-19-krisen innebär att det står än mer på spel och de båda länderna använder samma taktik när de skyller interna problem på varandra. Kina upplever den första perioden med negativ tillväxt sedan Mao Zedongs kulturrevolution vilket sätter stor press på den auktoritära regimen. Det är historiskt mycket ovanligt att amerikanska presidenter blir omvalda när landet befinner sig i lågkonjunktur. Under de senaste veckorna har Trump-administrationen bland annat beskyllt Kina för att virusets ursprung är Wuhan Institute of Virology, utan att presentera några bevis.</p>")]
        public void TestSplitSubtitleAndNews(string input)
        {
            var res = input.SplitSubtitleAndNews();
        }
    }
}
