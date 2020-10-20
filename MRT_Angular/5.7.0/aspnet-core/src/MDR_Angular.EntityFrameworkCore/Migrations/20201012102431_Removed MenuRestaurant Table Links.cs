using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class RemovedMenuRestaurantTableLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuIdFk",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantIdFk",
                table: "Menu",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuIdFk",
                table: "MenuItem",
                column: "MenuIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_RestaurantIdFk",
                table: "Menu",
                column: "RestaurantIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Restaurant_RestaurantIdFk",
                table: "Menu",
                column: "RestaurantIdFk",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Menu_MenuIdFk",
                table: "MenuItem",
                column: "MenuIdFk",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Restaurant_RestaurantIdFk",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Menu_MenuIdFk",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuIdFk",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_Menu_RestaurantIdFk",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuIdFk",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "RestaurantIdFk",
                table: "Menu");
        }
    }
}
