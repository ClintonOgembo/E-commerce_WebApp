using System.Text.Json;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class CartService
    {
        private const string CartKey = "ShoppingCart";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext!.Session;

        public List<CartItem> GetCart()
        {
            var json = Session.GetString(CartKey);
            return json == null
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
        }

        public void SaveCart(List<CartItem> cart)
        {
            Session.SetString(CartKey, JsonSerializer.Serialize(cart));
        }

        public void AddToCart(Product product, int quantity = 1)
        {
            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.ProductId == product.Id);

            if (existing != null)
                existing.Quantity += quantity;
            else
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = quantity,
                    ImageUrl = product.ImageUrl
                });

            SaveCart(cart);
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                if (quantity <= 0)
                    cart.Remove(item);
                else
                    item.Quantity = quantity;
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            cart.RemoveAll(c => c.ProductId == productId);
            SaveCart(cart);
        }

        public void ClearCart() => Session.Remove(CartKey);

        public int GetItemCount() => GetCart().Sum(c => c.Quantity);

        public decimal GetTotal() => GetCart().Sum(c => c.Total);
    }
}
