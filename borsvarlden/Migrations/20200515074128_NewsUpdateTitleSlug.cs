using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class NewsUpdateTitleSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "FinwireNews",
                nullable: true);
            
            migrationBuilder.Sql("UPDATE news SET news.[Slug] = ts.[Slug] FROM [dbo].[FinwireNews] AS news INNER JOIN [dbo].[TittleSlugs] AS ts ON news.Id = ts.Id");
            
            migrationBuilder.DropForeignKey(
                name: "FK_FinwireNews_TittleSlugs_TittleSlugId",
                table: "FinwireNews");

            migrationBuilder.DropTable(
                name: "TittleSlugs");

            migrationBuilder.DropIndex(
                name: "IX_FinwireNews_TittleSlugId",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "TittleSlugId",
                table: "FinwireNews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TittleSlugId",
                table: "FinwireNews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TittleSlugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TittleSlugs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNews_TittleSlugId",
                table: "FinwireNews",
                column: "TittleSlugId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinwireNews_TittleSlugs_TittleSlugId",
                table: "FinwireNews",
                column: "TittleSlugId",
                principalTable: "TittleSlugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.Sql("INSERT INTO [dbo].[TittleSlugs] (Id, Slug) SELECT Id, Slug FROM [dbo].[FinwireNews]");
            
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "FinwireNews");
        }
    }
}
