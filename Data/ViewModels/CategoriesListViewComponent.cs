using EStore.Data.Cart;
using EStore.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Data.ViewModels
{
    public class CategoriesListViewComponent : ViewComponent
    {
        private readonly ICategoriesService _service;

        public CategoriesListViewComponent(ICategoriesService service)
        {
            _service = service;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allCategories = await _service.GetAllAsync();
            return View(allCategories);
        }
    }

}
