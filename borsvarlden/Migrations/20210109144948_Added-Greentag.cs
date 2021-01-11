using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedGreentag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GreenTag",
                table: "FinwireNews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GreenTag",
                table: "FinwireCompanies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreenTag",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "GreenTag",
                table: "FinwireCompanies");
        }
    }
}
