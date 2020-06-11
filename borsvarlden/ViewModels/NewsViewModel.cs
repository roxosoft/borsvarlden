using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace borsvarlden.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public string ImageLabel { get; set; }

        public string NewsText { get; set; }

        public string TittleSlug { get; set; }

        public string Subtitle { get; set;}

        public string Guid { get; set; }

        public bool IsFromXml { get; set; }

        public List <string> Companies { get; set; }

        public List <string> SocialTags { get; set;}

        public bool IsFinwireNews { get; set; }

        public bool IsAdvertising { get; set; }

        public string CompanyName { get; set; }

        public string CopyrightLabel { get; set; }

        public string Label { get; set; }

        public bool IsBigBlock { get; set; }
    }
}
