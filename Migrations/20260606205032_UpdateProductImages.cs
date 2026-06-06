using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 6, 6, 20, 50, 32, 111, DateTimeKind.Utc).AddTicks(5345), "/images/headphones.jpeg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 20, 50, 32, 111, DateTimeKind.Utc).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2026, 6, 6, 20, 50, 32, 111, DateTimeKind.Utc).AddTicks(5355), "/wwwroot/images/Dispenser.jpeg", "Water Dispenser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2026, 6, 2, 21, 55, 2, 408, DateTimeKind.Utc).AddTicks(369), "/images/placeholder.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 6, 2, 21, 55, 2, 408, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2026, 6, 2, 21, 55, 2, 408, DateTimeKind.Utc).AddTicks(378), "/images/placeholder.jpg", "Coffee Maker" });
        }
    }
}
