using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6427), 4500.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Price" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6435), "Inflatable sofa seat with foot stool and manual pump now available in colour grey, beige, blue, green, red, pink, purple.", 2700.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Price" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6437), "Ailyons bottom load water dispenser now available hot and cold. Model; AFK 8848.", 9700.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 4, 2, new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6438), "Portable inflatable car back seat bed. Comes with a pump powered through the cigar lighter socket. 3 colours available; blue, grey, beige, black.", "/images/carmart.jpeg", true, "Car back seat bed", 3000.00m, 30 },
                    { 5, 2, new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6440), "2 Curtains 1.5m each, 1 Sheer 3m, height 2.5m.", "/images/curtains.jpeg", true, "3Pc Curtains", 3300.00m, 30 },
                    { 6, 3, new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6442), "High quality non stick 6in1 cake mould/ baking tins now available. Size: 28,26,24,22,18", "/images/nonstick-sufurias.jpeg", true, "Non stick sufuria", 1550.00m, 30 },
                    { 7, 3, new DateTime(2026, 6, 6, 21, 39, 7, 834, DateTimeKind.Utc).AddTicks(6443), "Rectangular 5in1 metallic bathroom shelf organizer shower caddy set now available.", "/images/wallhangers.jpeg", true, "Wall hangers", 1800.00m, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 3, 42, 509, DateTimeKind.Utc).AddTicks(2305), 4999.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Price" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 3, 42, 509, DateTimeKind.Utc).AddTicks(2313), "100% cotton casual t-shirt, available in multiple colours.", 799.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Price" },
                values: new object[] { new DateTime(2026, 6, 6, 21, 3, 42, 509, DateTimeKind.Utc).AddTicks(2315), "Automatic drip coffee maker with 12-cup capacity.", 3499.00m });
        }
    }
}
