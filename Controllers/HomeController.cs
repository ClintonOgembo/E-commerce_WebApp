using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;

namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _db.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.CreatedAt)
                .Take(6)
                .ToListAsync();

            var categories = await _db.Categories.ToListAsync();

            ViewBag.Categories = categories;
            return View(featuredProducts);
        }
    }
}
