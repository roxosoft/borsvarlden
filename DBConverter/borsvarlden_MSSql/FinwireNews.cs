using System;
using System.Collections.Generic;

namespace DBConverter.borsvarlden_MSSql
{
    public partial class FinwireNews
    {
        public FinwireNews()
        {
            FinwireNew2FinwireCompany = new HashSet<FinwireNew2FinwireCompany>();
            FinwireNew2FirnwireSocialTag = new HashSet<FinwireNew2FirnwireSocialTag>();
            NewsMetas = new HashSet<NewsMetas>();
        }

        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime Date { get; set; }
        public bool? FinautoPassed { get; set; }
        public bool? FinautoPublished { get; set; }
        public string PathRelative { get; set; }
        public string Title { get; set; }
        public string NewsText { get; set; }
        public int? FinwireAgencyId { get; set; }
        public string ImageLabel { get; set; }
        public string ImageRelativeUrl { get; set; }
        public string Subtitle { get; set; }
        public DateTime DateModified { get; set; }
        public bool? IsAdvertising { get; set; }
        public int Order { get; set; }
        public string Slug { get; set; }
        public bool? IsConvertedFromMySql { get; set; }
        public int? FinwireXmlNewsId { get; set; }
        public int ReadCount { get; set; }
        public bool? IsBorsvarldenArticle { get; set; }
        public bool? IsFinwireNews { get; set; }
        public string CompanyName { get; set; }
        public bool? IsPublished { get; set; }
        public string Label { get; set; }
        public DateTime PrioDeadLine { get; set; }
        public DateTime ActualDeadLine { get; set; }

        public virtual FinwireAgencies FinwireAgency { get; set; }
        public virtual FinwireXmlNews FinwireXmlNews { get; set; }
        public virtual ICollection<FinwireNew2FinwireCompany> FinwireNew2FinwireCompany { get; set; }
        public virtual ICollection<FinwireNew2FirnwireSocialTag> FinwireNew2FirnwireSocialTag { get; set; }
        public virtual ICollection<NewsMetas> NewsMetas { get; set; }
    }
}
