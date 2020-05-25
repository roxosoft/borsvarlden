using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden
{
    public partial class WpUsermeta
    {
        public long UmetaId { get; set; }
        public long UserId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
