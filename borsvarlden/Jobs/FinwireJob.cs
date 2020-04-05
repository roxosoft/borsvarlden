using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using borsvarlden.Services.Entities;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Finwire
{
    public class FinwireJob
    {
        private IFinwireParserService _parser;
        private IFinwireNewsService _finwireNewsService;
      
        public FinwireJob(IFinwireNewsService finwireNewsService, IFinwireParserService parser)
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
