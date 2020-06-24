using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddIndFinautoPassedIsBorsvArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IndexFinautoPassedIsBorsvarldenArticle",
                table: "FinwireNews",
                columns: new[] { "FinautoPassed", "IsBorsvarldenArticle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IndexFinautoPassedIsBorsvarldenArticle",
                table: "FinwireNews");
        }
    }
}
