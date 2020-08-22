using System;
using System.Collections.Generic;

namespace borsvarlden.Models
{
    public class FinwireNew
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string PathRelative { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateModified { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string NewsText { get; set; }
        public string ImageRelativeUrl { get; set; }
        public string ImageLabel { get; set; }
        public int Order { get; set; }
        //todo with flags
        public bool IsAdvertising { get; set; } 
        public bool FinautoPassed { get; set;}
        public bool FinautoPublished { get; set; }
        public bool IsConvertedFromMySQL { get; set; }
        public int ReadCount { get; set; }
        public string Slug { get; set; }
        public bool IsFinwireNews { get; set; }
        public bool IsBorsvarldenArticle { get; set; } 
        public bool IsPublished { get; set; } 

        public string CompanyName { get; set; }
        public DateTime PrioDeadLine { get; set; }
        public DateTime ActualDeadLine { get; set; }
        public string Label { get; set; }
        public string ImageSource { get; set; }
        public bool Is15MinutesVideo { get; set; }

        public FinwireAgency FinwireAgency { get; set; }
        public FinwireXmlNews FinwireXmlNews { get; set; }

        public List<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTags { get; set; }
        public List<FinwireNew2FinwireCompany> FinwireNew2FinwireCompanies { get; set; }
    }
}
