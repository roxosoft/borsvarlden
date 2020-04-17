using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.ViewModels
{
    public class PaggingResponseViewModel<T> where T : class
    {
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

        public PaggingResponseViewModel()
        {
            Data = new List<T>();
        }
    }
}
