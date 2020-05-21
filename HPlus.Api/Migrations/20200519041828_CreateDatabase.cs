using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HPlus.Api.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active Wear - Men" },
                    { 2, "Active Wear - Women" },
                    { 3, "Mineral Water" },
                    { 4, "Publications" },
                    { 5, "Supplements" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email" },
                values: new object[,]
                {
                    { 1, "adam@example.com" },
                    { 2, "barbara@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "IsAvailable", "Name", "OrderId", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, 1, true, "Grunge Skater Jeans", null, 68m, "AWMGSJ" },
                    { 31, 5, true, "Vitamin B-Complex (100 caplets)", null, 12.99m, "SVB" },
                    { 30, 5, true, "Vitamin A 10,000 IU (125 caplets)", null, 11.99m, "SVA" },
                    { 29, 5, true, "Multi-Vitamin (90 capsules)", null, 9.99m, "SMV" },
                    { 28, 5, true, "Magnesium 250 mg (100 tablets)", null, 12.49m, "SM250" },
                    { 27, 5, true, "Iron 65 mg (150 caplets)", null, 13.99m, "SI65" },
                    { 26, 5, true, "Flaxseed Oil 100 mg (90 capsules)", null, 12.49m, "SFO100" },
                    { 25, 5, true, "Calcium 400 IU (150 tablets)", null, 9.99m, "SC400" },
                    { 24, 4, true, "In the Kitchen with H+ Sport", null, 24.99m, "PITK" },
                    { 23, 3, true, "Strawberry Mineral Water", null, 2.8m, "MWS" },
                    { 22, 3, true, "Raspberry Mineral Water", null, 2.8m, "MWR" },
                    { 21, 3, true, "Peach Mineral Water", null, 2.8m, "MWP" },
                    { 20, 3, true, "Orange Mineral Water", null, 2.8m, "MWO" },
                    { 19, 3, true, "Lemon-Lime Mineral Water", null, 2.8m, "MWLL" },
                    { 18, 3, true, "Blueberry Mineral Water", null, 2.8m, "MWB" },
                    { 32, 5, true, "Vitamin C 1000 mg (100 tablets)", null, 9.99m, "SVC" },
                    { 17, 2, true, "V-Next T-Shirt", null, 17m, "AWWVNT" },
                    { 15, 2, true, "Ultra-Soft Tank Top", null, 22m, "AWWUTT" },
                    { 14, 2, true, "Stretchy Dance Pants", null, 55m, "AWWSDP" },
                    { 13, 2, true, "Slicker Jacket", null, 125m, "AWWSJ" },
                    { 12, 2, true, "Grunge Skater Jeans", null, 68m, "AWWGSJ" },
                    { 11, 2, false, "Cross-Back Training Tank", null, 0m, "AWWCTT" },
                    { 10, 2, true, "Bamboo Thermal Ski Coat", null, 99m, "AWWBTSC" },
                    { 9, 1, true, "V-Neck T-Shirt", null, 17m, "AWMVNT" },
                    { 8, 1, true, "V-Neck Sweater", null, 65m, "AWMVNS" },
                    { 7, 1, true, "V-Neck Pullover", null, 65m, "AWMVNP" },
                    { 6, 1, true, "Unisex Thermal Vest", null, 95m, "AWMUTV" },
                    { 5, 1, true, "Thermal Fleece Jacket", null, 60m, "AWMTFJ" },
                    { 4, 1, true, "Slicker Jacket", null, 125m, "AWMSJ" },
                    { 3, 1, true, "Skater Graphic T-Shirt", null, 33m, "AWMSGT" },
                    { 2, 1, true, "Polo Shirt", null, 35m, "AWMPS" },
                    { 16, 2, true, "Unisex Thermal Vest", null, 95m, "AWWUTV" },
                    { 33, 5, true, "Vitamin D3 1000 IU (100 tablets)", null, 12.49m, "SVD3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
