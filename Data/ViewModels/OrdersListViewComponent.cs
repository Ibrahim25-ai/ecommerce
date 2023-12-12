using EStore.Data.Cart;
using EStore.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EStore.Data.ViewModels
{
    public class OrdersListViewComponent : ViewComponent
    {
        private readonly IProductsService _ProductsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersListViewComponent(IProductsService ProductsService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _ProductsService = ProductsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

       

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userId = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
    }

}
