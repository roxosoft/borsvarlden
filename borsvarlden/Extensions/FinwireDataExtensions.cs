using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using borsvarlden.Services.Finwire;

namespace borsvarlden.Extensions
{
    public static class FinwireDataExtensions
    {
        public static FinWireData BuildSubtitle(this FinWireData finwireData)
        {
            var paragraphDelimeter = "<br/><br/>";
            var splitedEls = finwireData.NewsText.Split(paragraphDelimeter);

            finwireData.SubTitle = splitedEls[0];
            //if single paragraph do nothing
            if (splitedEls.Length > 1)
            {
                finwireData.NewsText = finwireData.NewsText.Remove(0, splitedEls[0].Length+ paragraphDelimeter.Length);
            }

            return finwireData;
        }
    }
}
