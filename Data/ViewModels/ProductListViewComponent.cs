using EStore.Data.Cart;
using EStore.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Data.ViewModels
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly IProductsService _service;

        public ProductListViewComponent(IProductsService service)
        {
            _service = service;
        }

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allProducts = await _service.GetAllAsync(n => n.Company);
            return View(allProducts);
        }
    }

}
