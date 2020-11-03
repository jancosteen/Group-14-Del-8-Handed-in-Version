using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class updatedcountryprovincecitylinks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_ProvinceIdFkNavigationId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_ProvinceIdFkNavigationId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "OrderDateCreated",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProvinceIdFkNavigationId",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "CityIdFk",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceIdFk",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CityIdFk",
                table: "Restaurant",
                column: "CityIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ProvinceIdFk",
                table: "Restaurant",
                column: "ProvinceIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceIdFk",
                table: "City",
                column: "ProvinceIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Province_ProvinceIdFk",
                table: "City",
                column: "ProvinceIdFk",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_CityIdFk",
                table: "Restaurant",
                column: "CityIdFk",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Province_ProvinceIdFk",
                table: "Restaurant",
                column: "ProvinceIdFk",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_ProvinceIdFk",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_City_CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Province_ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_City_ProvinceIdFk",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDateCreated",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProvinceIdFkNavigationId",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceIdFkNavigationId",
                table: "City",
                column: "ProvinceIdFkNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Province_ProvinceIdFkNavigationId",
                table: "City",
                column: "ProvinceIdFkNavigationId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
