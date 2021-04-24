using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class ChangeOrderTypeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Order",
                table: "FinwireNews",
                type: "decimal(11,4)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "FinwireNews",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,4)");
        }
    }
}
