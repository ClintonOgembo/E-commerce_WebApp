using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Data;
using ShopApp.Models;
using ShopApp.Services;
using Stripe;

namespace ShopApp.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _db;
        private readonly CartService _cart;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public CheckoutController(
            AppDbContext db,
            CartService cart,
            UserManager<ApplicationUser> userManager,
            IConfiguration config)
        {
            _db = db;
            _cart = cart;
            _userManager = userManager;
            _config = config;
        }

        // GET: /Checkout
        public async Task<IActionResult> Index()
        {
            var items = _cart.GetCart();
            if (!items.Any()) return RedirectToAction("Index", "Cart");

            var user = await _userManager.GetUserAsync(User);
            ViewBag.CartItems = items;
            ViewBag.Total = _cart.GetTotal();
            ViewBag.StripePublicKey = _config["Stripe:PublicKey"];
            return View(user);
        }

        // POST: /Checkout/PlaceOrder
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(
            string shippingAddress,
            string shippingCity,
            string shippingCountry,
            string stripeToken)
        {
            var items = _cart.GetCart();
            if (!items.Any()) return RedirectToAction("Index", "Cart");

            var user = await _userManager.GetUserAsync(User);
            var total = _cart.GetTotal();

            // Stripe charge
            string? paymentIntentId = null;
            try
            {
                StripeConfiguration.ApiKey = _config["Stripe:SecretKey"];
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(total * 100), // cents
                    Currency = "kes",
                    Description = $"Order for {user!.Email}",
                    Source = stripeToken
                };
                var service = new ChargeService();
                var charge = await service.CreateAsync(options);
                paymentIntentId = charge.Id;
            }
            catch (StripeException ex)
            {
                TempData["Error"] = $"Payment failed: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }

            // Create order
            var order = new Order
            {
                UserId = user!.Id,
                TotalAmount = total,
                ShippingAddress = shippingAddress,
                ShippingCity = shippingCity,
                ShippingCountry = shippingCountry,
                Status = OrderStatus.Processing,
                StripePaymentIntentId = paymentIntentId,
                Items = items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            // Decrease stock
            foreach (var item in items)
            {
                var product = await _db.Products.FindAsync(item.ProductId);
                if (product != null)
                    product.Stock = Math.Max(0, product.Stock - item.Quantity);
            }

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            _cart.ClearCart();

            return RedirectToAction(nameof(Confirmation), new { id = order.Id });
        }

        // GET: /Checkout/Confirmation/5
        public async Task<IActionResult> Confirmation(int id)
        {
            var order = await _db.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }
    }
}
