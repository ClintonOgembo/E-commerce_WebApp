using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 21, 3, 42, 509, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 3, 42, 509, DateTimeKind.Utc).AddTicks(2313), "/images/lazysofa.jpeg", "Lazy Sofa" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 3, 42, 509, DateTimeKind.Utc).AddTicks(2315), "/images/dispenser.jpeg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 20, 50, 32, 111, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2026, 6, 6, 20, 50, 32, 111, DateTimeKind.Utc).AddTicks(5353), "/images/placeholder.jpg", "Men's T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 6, 6, 20, 50, 32, 111, DateTimeKind.Utc).AddTicks(5355), "/wwwroot/images/Dispenser.jpeg" });
        }
    }
}
