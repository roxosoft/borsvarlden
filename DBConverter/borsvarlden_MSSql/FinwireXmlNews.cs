using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireXmlNews
    {
        public FinwireXmlNews()
        {
            FinwireNews = new HashSet<FinwireNews>();
        }

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string FileName { get; set; }
        public string FileContent { get; set; }

        public virtual ICollection<FinwireNews> FinwireNews { get; set; }
    }
}
