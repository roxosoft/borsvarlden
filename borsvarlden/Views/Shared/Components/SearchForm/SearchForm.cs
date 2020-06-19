using System.Threading.Tasks;
using borsvarlden.Services.Entities;
using borsvarlden.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace borsvarlden.Views.Shared.Components.SearchForm
{
    public class SearchForm : ViewComponent
    {
        private readonly IFinwireNewsService _finwireNewsService;

        public SearchForm(IFinwireNewsService finwireNewsService)
        {
            _finwireNewsService = finwireNewsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SearchFormViewModel();
            
            return View("SearchForm", model);
        }
    }
}