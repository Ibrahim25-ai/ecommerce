using EStore.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Data.ViewModels
{
    public class CartNumbersViewComponent : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public CartNumbersViewComponent(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            ViewBag.CartItemCount = _shoppingCart.GetCartItemNumbers();
            
            return View();
        }
    }

}
