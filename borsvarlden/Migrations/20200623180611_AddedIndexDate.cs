using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedIndexDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IndexDate",
                table: "FinwireNews",
                column: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IndexDate",
                table: "FinwireNews");
        }
    }
}
