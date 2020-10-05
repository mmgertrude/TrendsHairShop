using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TrendsHairShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "HairPieces",
                columns: table => new
                {
                    HairId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageThumbnailUrl = table.Column<string>(nullable: true),
                    InStock = table.Column<bool>(nullable: false),
                    IsHairOfTheWeek = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairPieces", x => x.HairId);
                    table.ForeignKey(
                        name: "FK_HairPieces_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HairId = table.Column<int>(nullable: true),
                    HairQty = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_HairPieces_HairId",
                        column: x => x.HairId,
                        principalTable: "HairPieces",
                        principalColumn: "HairId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Curly", "Hair with curles" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "straight", "straight hair" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "wavy", "Hair with waves" });

            migrationBuilder.InsertData(
                table: "HairPieces",
                columns: new[] { "HairId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsHairOfTheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[] { 1, 1, "https://www.styleinterest.com/wp-content/uploads/2016/02/4120416-crochet-braids-hairstyles-.png", "https://www.styleinterest.com/wp-content/uploads/2016/02/4120416-crochet-braids-hairstyles-.png", true, true, "The tight spiral curls in this look are perfect for a girl looking for a more polished look.Even better, you don’t have to deal with all the time it takes to curl hair in the morning!", "Afro Kinky tight curles", null, 12.95m, "Gives a kinky afro. Crotchet hair" });

            migrationBuilder.InsertData(
                table: "HairPieces",
                columns: new[] { "HairId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsHairOfTheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[] { 2, 2, "https://ae01.alicdn.com/kf/HTB1hnlBbaL7gK0jSZFBq6xZZpXau/Ali-Julia-Hair-Afro-Kinky-Straight-Hair-360-Lace-Front-Wig-Brazilian-Remy-Human-Hair-Wigs.jpg_q50.jpg", "https://ae01.alicdn.com/kf/HTB1hnlBbaL7gK0jSZFBq6xZZpXau/Ali-Julia-Hair-Afro-Kinky-Straight-Hair-360-Lace-Front-Wig-Brazilian-Remy-Human-Hair-Wigs.jpg_q50.jpg", true, true, "lovely straight kinky to mimic the look of a blown-out head full of natural hair", "Afro Kinky Straight", null, 18.95m, "You'll love it!" });

            migrationBuilder.InsertData(
                table: "HairPieces",
                columns: new[] { "HairId", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsHairOfTheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[] { 3, 3, "https://www.dhresource.com/0x0/f2/albu/g8/M00/0F/F5/rBVaV1xMFv6AScriAAKjDa1r1ro271.jpg/unice-kinky-curly-bulks-women-afro-loose.jpg", "https://www.dhresource.com/0x0/f2/albu/g8/M00/0F/F5/rBVaV1xMFv6AScriAAKjDa1r1ro271.jpg/unice-kinky-curly-bulks-women-afro-loose.jpg", true, false, "Loose Wave Hair Extensions Wavy Weave Wefts. fdfdfdsffdffdffdfdfdfdfdfdf sdjflkdjfkdfkdjfkd fdfdfdsffdffdffdfdfdfdfdfdf sdjflkdjfkdfkdjfkd fdfdfdsffdf sdjflkdjfkdfkdjfkd fdfdfdsffdf", "Angle waves", null, 18.95m, "beautiful wavy hair weave" });

            migrationBuilder.CreateIndex(
                name: "IX_HairPieces_CategoryId",
                table: "HairPieces",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_HairId",
                table: "ShoppingCartItems",
                column: "HairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "HairPieces");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
