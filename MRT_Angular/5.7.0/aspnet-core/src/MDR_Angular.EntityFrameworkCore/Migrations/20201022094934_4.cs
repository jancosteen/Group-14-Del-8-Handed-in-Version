using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AdvertisementDate_AdvertisementDateIdFk",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AdvertisementPrice_AdvertisementPriceIdFk",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_MenuItemPrice_MenuItemPriceIdFk",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuItemPriceIdFk",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_AdvertisementDateIdFk",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_AdvertisementPriceIdFk",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "RestaurantCity",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantCountry",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantDateCreated",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantProvince",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "MenuItemPriceIdFk",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "MenuDateCreated",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "AdvertisementDateIdFk",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "AdvertisementPriceIdFk",
                table: "Advertisement");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantPostalCode",
                table: "Restaurant",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityIdFk",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryIdFk",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceIdFk",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "QrCodeFile",
                table: "QrCodeSeating",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MenuItemPrice",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdvertisementDateActiveTo",
                table: "Advertisement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AdvertisementDateAcvtiveFrom",
                table: "Advertisement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "AdvertisementPrice",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantIdFK",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProvinceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CityIdFk",
                table: "Restaurant",
                column: "CityIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CountryIdFk",
                table: "Restaurant",
                column: "CountryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ProvinceIdFk",
                table: "Restaurant",
                column: "ProvinceIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_RestaurantIdFK",
                table: "Advertisement",
                column: "RestaurantIdFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Restaurant_RestaurantIdFK",
                table: "Advertisement",
                column: "RestaurantIdFK",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_City_CityIdFk",
                table: "Restaurant",
                column: "CityIdFk",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Country_CountryIdFk",
                table: "Restaurant",
                column: "CountryIdFk",
                principalTable: "Country",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Restaurant_RestaurantIdFK",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_City_CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Country_CountryIdFk",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Province_ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_CountryIdFk",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_RestaurantIdFK",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "CityIdFk",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "CountryIdFk",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ProvinceIdFk",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "QrCodeFile",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "MenuItemPrice",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "AdvertisementDateActiveTo",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "AdvertisementDateAcvtiveFrom",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "AdvertisementPrice",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "RestaurantIdFK",
                table: "Advertisement");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantPostalCode",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "RestaurantCity",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantCountry",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestaurantDateCreated",
                table: "Restaurant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantProvince",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuItemPriceIdFk",
                table: "MenuItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MenuDateCreated",
                table: "Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementDateIdFk",
                table: "Advertisement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementPriceIdFk",
                table: "Advertisement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuItemPriceIdFk",
                table: "MenuItem",
                column: "MenuItemPriceIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AdvertisementDateIdFk",
                table: "Advertisement",
                column: "AdvertisementDateIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AdvertisementPriceIdFk",
                table: "Advertisement",
                column: "AdvertisementPriceIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AdvertisementDate_AdvertisementDateIdFk",
                table: "Advertisement",
                column: "AdvertisementDateIdFk",
                principalTable: "AdvertisementDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AdvertisementPrice_AdvertisementPriceIdFk",
                table: "Advertisement",
                column: "AdvertisementPriceIdFk",
                principalTable: "AdvertisementPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_MenuItemPrice_MenuItemPriceIdFk",
                table: "MenuItem",
                column: "MenuItemPriceIdFk",
                principalTable: "MenuItemPrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
