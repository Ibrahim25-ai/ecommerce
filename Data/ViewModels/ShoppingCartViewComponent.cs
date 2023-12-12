using EStore.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Data.ViewModels
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartViewComponent(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var viewModel = new ShoppingCartVM
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                // Set other necessary properties of ShoppingCartVM
            };
            return View(viewModel);
        }
    }

}
