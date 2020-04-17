using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Helpers
{
    public static class PaginationHelper
    {
        public static void CalcutatePagerSize(int currentPage, int pageCount, out int first, out int last)
        {
            first = 1;
            last = pageCount < 5 ? pageCount : 5;

            if (currentPage >= 3 && currentPage <= pageCount - 2)
            {
                first = currentPage - 2;
                last = first + 4;
            }

            if (currentPage > pageCount - 2)
            {
                first = pageCount - 5;
                last = first + 4;
            }
        }
    }
}
