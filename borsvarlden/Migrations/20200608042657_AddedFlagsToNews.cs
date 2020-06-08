using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedFlagsToNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBorsvarldenArticle",
                table: "FinwireNews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinwireNews",
                table: "FinwireNews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBorsvarldenArticle",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "IsFinwireNews",
                table: "FinwireNews");
        }
    }
}
