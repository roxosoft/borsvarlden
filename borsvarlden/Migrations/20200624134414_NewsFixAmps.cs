using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class NewsFixAmps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update [FinwireNews] set title = replace(title, '&amp;', '&') where title like '%&amp;%'");
            migrationBuilder.Sql("update [FinwireNews] set subtitle = replace(subtitle, '&amp;', '&') where subtitle like '%&amp;%'");
            migrationBuilder.Sql("update [FinwireNews] set newstext = replace(newstext, '&amp;', '&') where newstext like '%&amp;%'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update [FinwireNews] set title = replace(title, '&', '&amp;') where title like '%&%'");
            migrationBuilder.Sql("update [FinwireNews] set subtitle = replace(subtitle, '&', '&amp;') where subtitle like '%&%'");
            migrationBuilder.Sql("update [FinwireNews] set newstext = replace(newstext, '&', '&amp;') where newstext like '%&%'");
        }
    }
}
