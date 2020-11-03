using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class updatedcountryprovincecitylinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "CountryIdFk",
                table: "Province",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceIdFk",
                table: "City",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceIdFkNavigationId",
                table: "City",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryIdFk",
                table: "Province",
                column: "CountryIdFk");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Province_Country_CountryIdFk",
                table: "Province",
                column: "CountryIdFk",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_ProvinceIdFkNavigationId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Province_Country_CountryIdFk",
                table: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Province_CountryIdFk",
                table: "Province");

            migrationBuilder.DropIndex(
                name: "IX_City_ProvinceIdFkNavigationId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountryIdFk",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "ProvinceIdFk",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ProvinceIdFkNavigationId",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "CityIdFk",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceIdFk",
                table: "Restaurant",
                type: "int",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_CityIdFk",
                table: "Restaurant",
                column: "CityIdFk",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Province_ProvinceIdFk",
                table: "Restaurant",
                column: "ProvinceIdFk",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
