using Microsoft.AspNetCore.Mvc;
using ShopApp.Services;

namespace ShopApp.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cart;

        public CartController(CartService cart) => _cart = cart;

        // GET: /Cart
        public IActionResult Index()
        {
            var items = _cart.GetCart();
            ViewBag.Total = _cart.GetTotal();
            return View(items);
        }

        // POST: /Cart/Update
        [HttpPost]
        public IActionResult Update(int productId, int quantity)
        {
            _cart.UpdateQuantity(productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Remove
        [HttpPost]
        public IActionResult Remove(int productId)
        {
            _cart.RemoveFromCart(productId);
            TempData["Info"] = "Item removed from cart.";
            return RedirectToAction(nameof(Index));
        }

        // GET: cart item count (for AJAX badge update)
        [HttpGet]
        public IActionResult Count() => Json(_cart.GetItemCount());
    }
}
