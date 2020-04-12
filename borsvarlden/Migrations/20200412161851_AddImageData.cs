using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddImageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLabel",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageRelativeUrl",
                table: "FinwireNews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLabel",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "ImageRelativeUrl",
                table: "FinwireNews");
        }
    }
}
