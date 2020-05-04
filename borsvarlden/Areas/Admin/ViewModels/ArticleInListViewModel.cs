using System;

namespace borsvarlden.Areas.Admin.ViewModels
{
    public class ArticleInListViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime Date { get; set; }
        
        public string ImageUrl { get; set; }
    }
}