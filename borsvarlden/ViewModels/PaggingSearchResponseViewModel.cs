using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.ViewModels
{
    public class PaggingSearchResponseViewModel<T> where T : class
    {
        public string SearchText { get; set; }

        public List<T> Data { get; set; }

        public int CurrentPage { get; set; }

        public int ItemsOnPageCount { get; set; }

        public int TotalCount { get; set; }

        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Decimal.Divide(TotalCount, ItemsOnPageCount));
            }
        }

        public PaggingSearchResponseViewModel()
        {
            Data = new List<T>();
        }
    }
}
