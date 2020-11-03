using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ReservationDateCreated",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "MenuItemPrice",
                table: "MenuItem");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantPostalCode",
                table: "Restaurant",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantAdvertisement",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantPostalCode",
                table: "Restaurant",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservationDateCreated",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "MenuItemPrice",
                table: "MenuItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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
    }
}
