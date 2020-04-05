using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using borsvarlden.Models;
using borsvarlden.Helpers;
using borsvarlden.Services.Entities;
using borsvarlden.Finwire;
using borsvarlden.Db;

namespace borsvarlden.Finwire
{
    public class FinwireUpdater 
    {
        private IFinwireParser _parser;
        private IFinwireNewsService _finwireNewsService;
      
        public FinwireUpdater(IFinwireNewsService finwireNewsService, IFinwireParser parser)
        { 
            _finwireNewsService = finwireNewsService;
            _parser = parser;
        }

        public  void Execute()
        {
            var pathBase = Path.GetFullPath($@"{Directory.GetCurrentDirectory()}\..\TestData\FinwireFiles");

            for (int i = 1; i <= 8; i++)
            {
                //there is no data
                if (i == 4 || i == 5)
                    continue;

                var path = $@"{pathBase}{i.ToString("D2")}";
                var finwireData = _parser.Parse(Directory.GetFiles(path)[0]);
                UpdateSingleNews(finwireData);
               
                var path = $@"{pathBase}\{i.ToString("D2")}";

                foreach (var file in Directory.GetFiles(path))
                {
                    var finwireData = _parser.Parse(file);
                    _finwireNewsService.AddSingleNews(finwireData);
                }
            }
        }

    }
}
