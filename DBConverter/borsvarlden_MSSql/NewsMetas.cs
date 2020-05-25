using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class NewsMetas
    {
        public int Id { get; set; }
        public int FinwireNewId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }

        public virtual FinwireNews FinwireNew { get; set; }
    }
}
