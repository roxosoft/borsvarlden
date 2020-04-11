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

        public string Label { get; set; }

        public string NewsText { get; set; }

        public string ShortNewsText
        {
            get
            {
                List<string> splitedText = NewsText.Split(" ").ToList();
                string result = splitedText.Count > 20
                    ? string.Join(" ", splitedText.Take(20).Append("..."))
                    : NewsText;

                return result;
            }
        }
    }
}
