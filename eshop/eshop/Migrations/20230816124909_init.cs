using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eshop.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kırtasiye" },
                    { 2, "Bilgisayar" },
                    { 3, "Astronomi Araçları" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Beyaz Tahta :)", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Beyaz Tahta", 570m },
                    { 2, 2, "....", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Asus Rock", 25000m },
                    { 3, 3, "Ucuz teleskop", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Amatör Teleskop", 7000m },
                    { 4, 2, "Beyaz Tahta :)", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Beyaz Tahta 1", 570m },
                    { 5, 3, "Beyaz Tahta :)", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Beyaz Tahta 2", 570m },
                    { 6, 1, "Beyaz Tahta :)", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Beyaz Tahta 3", 570m },
                    { 7, 1, "Beyaz Tahta :)", 0.20m, "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg", "Beyaz Tahta 4", 570m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
