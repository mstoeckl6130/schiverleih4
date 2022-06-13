using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schiverleih4.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriesCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryID",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesCategoryID",
                table: "Products",
                column: "CategoriesCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryID",
                table: "Products",
                column: "CategoriesCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }
    }
}
