using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.Models
{
    public enum EnumFinwireFilterTypes : sbyte
    {
        _01_TitleWhitelist               = 1,
        _02_TitleBlackList               = 2,
        _03_TitleSocialTags              = 3,
        _04_FilterComplanies             = 4,
        _05_TitleWhitelistPublishAsDraft = 5
    }
}
