using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class StaticPageSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StaticPages",
                columns: new[] { "Id", "StaticPageType", "Text" },
                values: new object[] { 1, 1, "Put Your text here" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaticPages",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
