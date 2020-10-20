using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class rollback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRestaurant_Reservation_ReservationIdFk",
                table: "ReservationRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRestaurant_Restaurant_RestaurantIdFk",
                table: "ReservationRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRestaurant_ReservationIdFk",
                table: "ReservationRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRestaurant_RestaurantIdFk",
                table: "ReservationRestaurant");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantIdFk",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RestaurantIdFk",
                table: "Reservation",
                column: "RestaurantIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Restaurant_RestaurantIdFk",
                table: "Reservation",
                column: "RestaurantIdFk",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Restaurant_RestaurantIdFk",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RestaurantIdFk",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "RestaurantIdFk",
                table: "Reservation");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRestaurant_ReservationIdFk",
                table: "ReservationRestaurant",
                column: "ReservationIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRestaurant_RestaurantIdFk",
                table: "ReservationRestaurant",
                column: "RestaurantIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRestaurant_Reservation_ReservationIdFk",
                table: "ReservationRestaurant",
                column: "ReservationIdFk",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRestaurant_Restaurant_RestaurantIdFk",
                table: "ReservationRestaurant",
                column: "RestaurantIdFk",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
