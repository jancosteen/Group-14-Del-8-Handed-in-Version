using Microsoft.EntityFrameworkCore.Migrations;

namespace MDR_Angular.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "TotalSalesByDayOfWeekReport",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "TotalSalesByMenuItemReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuIteMane = table.Column<string>(nullable: true),
                    MenuItemPrice1 = table.Column<double>(nullable: false),
                    TotalSalesAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalSalesByMenuItemReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TotalSalesByMenuItemReport");

            migrationBuilder.AlterColumn<float>(
                name: "TotalAmount",
                table: "TotalSalesByDayOfWeekReport",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
