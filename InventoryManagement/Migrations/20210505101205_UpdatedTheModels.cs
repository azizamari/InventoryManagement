using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class UpdatedTheModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryName",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CategoryName",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Brands",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CategoryName",
                table: "Brands",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryName",
                table: "Brands",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
