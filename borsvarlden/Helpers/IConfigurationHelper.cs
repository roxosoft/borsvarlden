using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Helpers
{
    public interface IConfigurationHelper
    {
        public int FirstBigBlockCount { get; }

        public int FirstSmallBlockCount { get; }

        public int SecondBigBlockCount { get; }

        public int SecondSmallBlockCount { get; }

        public int IndexNewsCount { get; }

        public int ListedNewsCount { get; }

        public int LatestNewsCount { get; }

        public int MostReadNewsCount { get; }

        public int SponsoredNewsCount { get; }

        public int RelatedNewsCount { get; }

        public int ReadMoreCount { get; }
    }
}
