# ShopApp – ASP.NET Core E-Commerce

A full e-commerce web application built with **ASP.NET Core 8**, **Entity Framework Core**, **SQL Server**, and **Stripe** payments.

---

## Features

- Product catalog with categories, search & filtering
- Session-based shopping cart
- User registration & login (ASP.NET Core Identity)
- Checkout with Stripe payment integration
- Order history per user
- Seeded sample products & categories
- Auto-migrates database on startup

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express / LocalDB)
- A [Stripe account](https://stripe.com) (free test account works)

---

## Setup

### 1. Clone / copy the project

```
ShopApp/
```

### 2. Configure the database connection

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ShopAppDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Change `Server=localhost` to your SQL Server instance name if needed  
(e.g. `Server=.\SQLEXPRESS` for SQL Server Express).

### 3. Add your Stripe keys

In `appsettings.json`:

```json
"Stripe": {
  "PublicKey": "pk_test_YOUR_KEY_HERE",
  "SecretKey": "sk_test_YOUR_KEY_HERE"
}
```

Get your test keys from: https://dashboard.stripe.com/test/apikeys

### 4. Run EF Core migrations

```bash
cd ShopApp
dotnet ef migrations add InitialCreate
dotnet ef database update
```

> The app also auto-applies migrations on startup via `db.Database.Migrate()`.

### 5. Run the app

```bash
dotnet run
```

Open https://localhost:5001 in your browser.

---

## Project Structure

```
ShopApp/
├── Controllers/
│   ├── HomeController.cs        # Landing page
│   ├── ProductsController.cs    # Catalog, detail, add-to-cart
│   ├── CartController.cs        # View/update/remove cart items
│   ├── CheckoutController.cs    # Checkout + Stripe payment
│   └── OrdersController.cs      # Order history
├── Models/
│   ├── ApplicationUser.cs       # Extended Identity user
│   ├── Product.cs
│   ├── Order.cs                 # Order, OrderItem, CartItem, Category
├── Data/
│   └── AppDbContext.cs          # EF Core DbContext + seed data
├── Services/
│   └── CartService.cs           # Session-based cart management
├── Views/
│   ├── Home/                    # Homepage with hero + featured products
│   ├── Products/                # List and detail pages
│   ├── Cart/                    # Cart page
│   ├── Checkout/                # Checkout form + order confirmation
│   ├── Orders/                  # Order history + details
│   └── Shared/_Layout.cshtml   # Navigation, alerts, footer
├── wwwroot/                     # Static assets (CSS, JS)
├── appsettings.json
└── Program.cs
```

---

## Adding Products (Admin)

Currently products are added via EF Core seed data in `AppDbContext.cs`.  
To add more products, update the `HasData` section and run a new migration:

```bash
dotnet ef migrations add AddMoreProducts
dotnet ef database update
```

A full admin panel can be added in future iterations.

---

## Payment Testing (Stripe)

Use Stripe's test card numbers:
- **Success:** `4242 4242 4242 4242`
- **Decline:** `4000 0000 0000 0002`
- Expiry: any future date | CVV: any 3 digits

---

## Next Steps

- [ ] Admin panel for product/order management
- [ ] Product image upload
- [ ] M-Pesa integration (for Kenya)
- [ ] Email order confirmation (SendGrid / SMTP)
- [ ] Product reviews & ratings
- [ ] Discount/coupon codes
