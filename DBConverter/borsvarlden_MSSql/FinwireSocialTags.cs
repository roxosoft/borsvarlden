using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireSocialTags
    {
        public FinwireSocialTags()
        {
            FinwireNew2FirnwireSocialTag = new HashSet<FinwireNew2FirnwireSocialTag>();
        }

        public int Id { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTag { get; set; }
    }
}
