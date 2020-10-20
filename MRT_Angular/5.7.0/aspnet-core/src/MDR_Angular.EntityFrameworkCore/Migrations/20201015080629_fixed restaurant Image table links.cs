using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class fixedrestaurantImagetablelinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantRestaurantImage_Restaurant_RestaurantIdFk",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantRestaurantImage_RestaurantImage_RestaurantImageIdFk",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantRestaurantImage_RestaurantIdFk",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantRestaurantImage_RestaurantImageIdFk",
                table: "RestaurantRestaurantImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RestaurantRestaurantImage_RestaurantIdFk",
                table: "RestaurantRestaurantImage",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantRestaurantImage_RestaurantImageIdFk",
                table: "RestaurantRestaurantImage",
                column: "RestaurantImageIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantRestaurantImage_Restaurant_RestaurantIdFk",
                table: "RestaurantRestaurantImage",
                column: "RestaurantIdFk",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantRestaurantImage_RestaurantImage_RestaurantImageIdFk",
                table: "RestaurantRestaurantImage",
                column: "RestaurantImageIdFk",
                principalTable: "RestaurantImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
