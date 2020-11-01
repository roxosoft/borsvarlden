using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public class CompanyCommon
    {
        public int Id { get; set; }

        public string Company { get; set; }
    }

    public class CompanyCommonComparer : IEqualityComparer<CompanyCommon>
    {
        public int GetHashCode(CompanyCommon co)
        {
            if (co == null)
            {
                return 0;
            }
            return co.Id.GetHashCode();
        }

        public bool Equals(CompanyCommon x1, CompanyCommon x2)
        {
            if (object.ReferenceEquals(x1, x2))
            {
                return true;
            }
            if (object.ReferenceEquals(x1, null) ||
                object.ReferenceEquals(x2, null))
            {
                return false;
            }
            return x1.Id == x2.Id;//&& x1.Company == x2.Company;
        }
    }
}
