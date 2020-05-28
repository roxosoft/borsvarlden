using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireNew2FirnwireSocialTag
    {
        public int FinwireNewId { get; set; }
        public int FinwireSocialTagId { get; set; }

        public virtual FinwireNews FinwireNew { get; set; }
        public virtual FinwireSocialTags FinwireSocialTag { get; set; }
    }
}
