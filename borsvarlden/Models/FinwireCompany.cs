using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace borsvarlden.Models
{
    public class FinwireCompany
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public bool GreenTag { get; set; }

        [DefaultValue(true)]
        public bool IsVisibleFromCompanyList { get; set; }

        public List<FinwireNew2FinwireCompany> FinwireNew2FinwireCompanies { get; set; }
    }
}
