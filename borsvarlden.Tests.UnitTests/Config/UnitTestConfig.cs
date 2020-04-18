using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace borsvarlden.Tests.UnitTests.Config
{
    public static class UnitTestConfig
    {
        public static string TestDataPath => Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\TestData");

        public static string FinautoImagesPath =>
            Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\borsvarlden\wwwroot\assets\images\finauto");
    }
}
