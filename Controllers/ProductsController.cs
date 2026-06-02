using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Services;

namespace ShopApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly CartService _cart;

        public ProductsController(AppDbContext db, CartService cart)
        {
            _db = db;
            _cart = cart;
        }

        // GET: /Products
        public async Task<IActionResult> Index(int? categoryId, string? search, string? sort)
        {
            var query = _db.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search) || p.Description.Contains(search));

            query = sort switch
            {
                "price_asc"  => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "newest"     => query.OrderByDescending(p => p.CreatedAt),
                _            => query.OrderBy(p => p.Name)
            };

            ViewBag.Categories = await _db.Categories.ToListAsync();
            ViewBag.CurrentCategory = categoryId;
            ViewBag.Search = search;
            ViewBag.Sort = sort;

            return View(await query.ToListAsync());
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (product == null) return NotFound();

            var related = await _db.Products
                .Where(p => p.CategoryId == product.CategoryId && p.Id != id && p.IsActive)
                .Take(4)
                .ToListAsync();

            ViewBag.RelatedProducts = related;
            return View(product);
        }

        // POST: /Products/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product == null) return NotFound();

            _cart.AddToCart(product, quantity);

            TempData["Success"] = $"'{product.Name}' added to cart!";
            return RedirectToAction(nameof(Details), new { id = productId });
        }
    }
}
