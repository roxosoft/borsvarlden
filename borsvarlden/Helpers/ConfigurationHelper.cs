using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Helpers
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        public int FirstBigBlockCount { get; private set; }

        public int FirstSmallBlockCount { get; private set; }

        public int SecondBigBlockCount { get; private set; }

        public int SecondSmallBlockCount { get; private set; }

        public int IndexNewsCount { get; private set; }

        public int ListedNewsCount { get; private set; }

        public int LatestNewsCount { get; private set; }

        public int MostReadNewsCount { get; private set; }

        public int SponsoredNewsCount { get; private set; }

        public int RelatedNewsCount { get; private set; }

        public int ReadMoreCount { get; private set; }

        public ConfigurationHelper(IConfiguration configuration)
        {
            FirstBigBlockCount = configuration.GetValue<int>("ApplicationSettings:FirstBigBlockCount");
            FirstSmallBlockCount = configuration.GetValue<int>("ApplicationSettings:FirstSmallBlockCount");
            SecondBigBlockCount = configuration.GetValue<int>("ApplicationSettings:SecondBigBlockCount");
            SecondSmallBlockCount = configuration.GetValue<int>("ApplicationSettings:SecondSmallBlockCount");

            IndexNewsCount = configuration.GetValue<int>("ApplicationSettings:IndexNewsCount");
            ListedNewsCount = configuration.GetValue<int>("ApplicationSettings:ListedNewsCount");
            LatestNewsCount = configuration.GetValue<int>("ApplicationSettings:LatestNewsCount");
            MostReadNewsCount = configuration.GetValue<int>("ApplicationSettings:MostReadNewsCount");
            SponsoredNewsCount = configuration.GetValue<int>("ApplicationSettings:SponsoredNewsCount");
            RelatedNewsCount = configuration.GetValue<int>("ApplicationSettings:RelatedNewsCount");
            ReadMoreCount = configuration.GetValue<int>("ApplicationSettings:ReadMoreCount");
        }
    }
}
