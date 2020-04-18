using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using borsvarlden.Extensions;

namespace borsvarlden.Tests.UnitTests.Tests.TestExtensions
{
    class TestStringExtensions
    {
        [TestCase("Papillys stressprogram – friskvård för tanken och ökat självledarskap", "papillys-stressprogram-friskvard-for-tanken-och-okat-sjalvledarskap")]
        public void TestToSlug(string inpString, string expectedString)
        {
            var res = inpString
                .ToSlug();
            Assert.IsTrue(res.Equals(expectedString));
        }
    }
}
