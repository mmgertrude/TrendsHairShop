using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TrendsHairShop.Migrations
{
    public partial class ordering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    HairId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_HairPieces_HairId",
                        column: x => x.HairId,
                        principalTable: "HairPieces",
                        principalColumn: "HairId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HairPieces",
                keyColumn: "HairId",
                keyValue: 1,
                columns: new[] { "InStock", "IsHairOfTheWeek" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "HairPieces",
                keyColumn: "HairId",
                keyValue: 2,
                columns: new[] { "InStock", "IsHairOfTheWeek" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "HairPieces",
                keyColumn: "HairId",
                keyValue: 3,
                columns: new[] { "InStock", "IsHairOfTheWeek" },
                values: new object[] { true, false });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_HairId",
                table: "OrderDetails",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "HairPieces",
                keyColumn: "HairId",
                keyValue: 1,
                columns: new[] { "InStock", "IsHairOfTheWeek" },
                values: new object[] { (short)1, (short)1 });

            migrationBuilder.UpdateData(
                table: "HairPieces",
                keyColumn: "HairId",
                keyValue: 2,
                columns: new[] { "InStock", "IsHairOfTheWeek" },
                values: new object[] { (short)1, (short)1 });

            migrationBuilder.UpdateData(
                table: "HairPieces",
                keyColumn: "HairId",
                keyValue: 3,
                columns: new[] { "InStock", "IsHairOfTheWeek" },
                values: new object[] { (short)1, (short)0 });
        }
    }
}
