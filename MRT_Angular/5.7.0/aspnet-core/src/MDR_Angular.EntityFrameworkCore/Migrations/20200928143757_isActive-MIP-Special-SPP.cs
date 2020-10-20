using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class isActiveMIPSpecialSPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuItemPriceStatus",
                table: "MenuItemPrice");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "SpecialPrice",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Special",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "MenuItemPrice",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "MenuItemPrice");

            migrationBuilder.AddColumn<string>(
                name: "MenuItemPriceStatus",
                table: "MenuItemPrice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
