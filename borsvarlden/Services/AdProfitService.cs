using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Services.AdProfitService
{
    public interface IAdProfitService
    {
        string GetTeaserId();
        string GetArticleId();
    }

    public class AdProfitService : IAdProfitService
    {
        public string GetTeaserId() => "eyJjIjoid3MyZmVESWZMUiIsImEiOiJjb20uYWR2aXNpYmxlLm5hdGl2ZS50ZWFzZXIiLCJpIjoiZmE1ODRkN2YtM2UzNC00NzhiLWJjNDEtMTk2OWVmYTE0YjljIn0%3D";
        public string GetArticleId() => "eyJjIjoid3MyZmVESWZMUiJ9";
    }
}
