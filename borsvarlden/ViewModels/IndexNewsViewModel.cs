using System.Collections.Generic;
using System.Linq;

namespace borsvarlden.ViewModels
{
    public class IndexNewsViewModel
    {
        public List<NewsViewModel> News { get; set; }

        public int FirstBigBlockCount { get; set; }

        public int FirstSmallBlockCount { get; set; }

        public int SecondBigBlockCount { get; set; }

        public int SecondSmallBlockCount { get; set; }

        public IndexNewsViewModel()
        {
            News = new List<NewsViewModel>();
        }
    }
}
