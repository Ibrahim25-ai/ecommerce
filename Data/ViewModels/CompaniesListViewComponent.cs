using EStore.Data.Cart;
using EStore.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Data.ViewModels
{
    public class CompaniesListViewComponent : ViewComponent
    {
        private readonly ICompaniesService _service;

        public CompaniesListViewComponent(ICompaniesService service)
        {
            _service = service;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allCompanies = await _service.GetAllAsync();
            return View(allCompanies);
        }
    }

}
