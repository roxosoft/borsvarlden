using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileHeader",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileLink",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePassword",
                table: "FinwireNews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FileHeader",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FileLink",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FilePassword",
                table: "FinwireNews");
        }
    }
}
