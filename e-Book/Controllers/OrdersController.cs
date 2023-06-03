using e_Book.Data;
using e_Book.Data.Cart;
using e_Book.Data.Services;
using e_Book.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace e_Book.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IbookService _bookService;
        private readonly ShopingCart _shopingCart;
        private readonly IOrdersServices _ordersServices;
        public OrdersController(IbookService bookService, ShopingCart shopingCart, IOrdersServices ordersServices)
        {
            _bookService = bookService;
            _shopingCart = shopingCart;
            _ordersServices= ordersServices;
        }
       
        public async Task< IActionResult> GetOrders()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders =await _ordersServices.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return View(orders);

        }
        public IActionResult Index()
        {
            
            var items=_shopingCart.GetShopinCartItems();
            _shopingCart.ShopinCartItems = items;
            var response = new ShopingCartVM()
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShoppingCartTotal()

            };
            return View(response);
        }
    
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _bookService.GetBookByIdAsync(id);
            if (item != null)
            {
                _shopingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _bookService.GetBookByIdAsync(id);
            if (item != null)
            {
                _shopingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shopingCart.GetShopinCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersServices.StoreOrderAsync(items, userId, userEmailAddress);
            await _shopingCart.clearShppinCartAsync();
            return View("OrderCompleter");
;        }
    }
}
