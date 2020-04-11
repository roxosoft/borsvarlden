using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace borsvarlden.Tests.UnitTests
{
    public static class UnitTestConfig
    {
        public static string TestDataPath => Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\..\..\..\TestData");
    }
}
