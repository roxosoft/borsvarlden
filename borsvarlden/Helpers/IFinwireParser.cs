using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Helpers
{
    public interface IFinwireParser
    {
        FinWireData Parse(string path);
    }
}
