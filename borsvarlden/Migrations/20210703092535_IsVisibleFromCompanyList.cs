using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class IsVisibleFromCompanyList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisibleFromCompanyList",
                table: "FinwireCompanies",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisibleFromCompanyList",
                table: "FinwireCompanies");
        }
    }
}
