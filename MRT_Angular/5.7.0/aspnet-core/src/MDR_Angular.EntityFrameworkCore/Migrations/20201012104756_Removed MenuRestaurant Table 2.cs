using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class RemovedMenuRestaurantTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRestaurant_Menu_MenuIdFk",
                table: "MenuRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRestaurant_MenuItem_MenuItemIdFk",
                table: "MenuRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRestaurant_Restaurant_RestaurantIdFk",
                table: "MenuRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_MenuRestaurant_MenuIdFk",
                table: "MenuRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_MenuRestaurant_MenuItemIdFk",
                table: "MenuRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_MenuRestaurant_RestaurantIdFk",
                table: "MenuRestaurant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_MenuIdFk",
                table: "MenuRestaurant",
                column: "MenuIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_MenuItemIdFk",
                table: "MenuRestaurant",
                column: "MenuItemIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_RestaurantIdFk",
                table: "MenuRestaurant",
                column: "RestaurantIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRestaurant_Menu_MenuIdFk",
                table: "MenuRestaurant",
                column: "MenuIdFk",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRestaurant_MenuItem_MenuItemIdFk",
                table: "MenuRestaurant",
                column: "MenuItemIdFk",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRestaurant_Restaurant_RestaurantIdFk",
                table: "MenuRestaurant",
                column: "RestaurantIdFk",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
