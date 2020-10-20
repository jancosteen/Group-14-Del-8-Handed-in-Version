using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class fixedadvertisementtablelinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAdvertisement_Advertisement_AdvertisementIdFk",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAdvertisement_Restaurant_RestaurantIdFk",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantAdvertisement_AdvertisementIdFk",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantAdvertisement_RestaurantIdFk",
                table: "RestaurantAdvertisement");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantAdvertisement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAdvertisement_RestaurantId",
                table: "RestaurantAdvertisement",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAdvertisement_Restaurant_RestaurantId",
                table: "RestaurantAdvertisement",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAdvertisement_Restaurant_RestaurantId",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantAdvertisement_RestaurantId",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantAdvertisement");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAdvertisement_AdvertisementIdFk",
                table: "RestaurantAdvertisement",
                column: "AdvertisementIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAdvertisement_RestaurantIdFk",
                table: "RestaurantAdvertisement",
                column: "RestaurantIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAdvertisement_Advertisement_AdvertisementIdFk",
                table: "RestaurantAdvertisement",
                column: "AdvertisementIdFk",
                principalTable: "Advertisement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAdvertisement_Restaurant_RestaurantIdFk",
                table: "RestaurantAdvertisement",
                column: "RestaurantIdFk",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
