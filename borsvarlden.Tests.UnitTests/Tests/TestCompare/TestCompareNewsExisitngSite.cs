using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using borsvarlden.Services.Entities;
using borsvarlden.Tests.UnitTests.Config;
using borsvarlden.Tests.UnitTests.Helpers;
using borsvarlden.Services.Finwire;
using NUnit.Framework;

namespace borsvarlden.Tests.UnitTests.Tests.TestCompare
{
    class TestCompareNewsExisitngSite
    {
        private FinwireFilterService _finwireFilterService = new FinwireFilterService(SetUp.ApplicationContext);

        [TestCase(1)]
        public void Compare(int dummy)
        {
            var pathBase = $@"{UnitTestConfig.TestDataPath}\Compare";
            var titlesSite = File.ReadAllLines($@"{pathBase}\existing_site_2020_05_28_29.txt").ToList();
            titlesSite.RemoveAll(x => x.StartsWith("Publicerad"));
            titlesSite.RemoveAll(x => string.IsNullOrEmpty(x));
            titlesSite.Reverse();

            var dataAll = new List<FinWireData>();
            var dataPassed = new List<FinWireData>();

            Directory.GetFiles($@"{pathBase}\files")
                .ToList()
                .ForEach(x =>
                    {
                        var data = UnitTestHelper.ParseNewsFile(x);
                        dataAll.Add(data);
                        if (_finwireFilterService.IsFilterPassed(data))
                        {
                            dataPassed.Add(data);
                        }
                    }
                );
            
            var dataSorted = dataPassed.OrderBy(x => x.Date);
            var p = dataSorted.Select(x => $"{x.Date} - {x.Title}");
            var titlesPassed = dataSorted.Select(x => x.Title).ToList();
            
            //data exists on site but not exists in titles that passed filtering
            var notContainsInTitlesPassed = new List<string>();
            titlesSite.ForEach(x =>
                {
                    if (!titlesPassed.Any(y => x.ReplaceSpecificChar() == y))
                    {
                        notContainsInTitlesPassed.Add(x.ReplaceSpecificChar());
                    }
                }
            ) ;

         var dataNotContainsInTitlesPassed = dataAll.Where(x => notContainsInTitlesPassed.Contains(x.Title)).ToList();

         dataNotContainsInTitlesPassed.ForEach(x =>
                _finwireFilterService.IsFilterPassed(x));

         var notContainsInSite = new List<string>();

         titlesPassed.ForEach(x =>
             {
                 if (!titlesSite.Any(y => x == y.ReplaceSpecificChar()))
                 {
                     notContainsInSite.Add(x);
                 }
             }
         );

         var dataNotContainsInSite = dataAll.Where(x => notContainsInSite.Contains(x.Title)).ToList();

         dataNotContainsInSite.ForEach(x =>
             _finwireFilterService.IsFilterPassed(x));
        }
    }

    public static class SpecificChars
    {
        public static string ReplaceSpecificChar(this string input)
        {
            return input.Replace('–', '-');
        }
    }

}
