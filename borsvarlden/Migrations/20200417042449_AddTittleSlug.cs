using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddTittleSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TittleSlugId",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TittleSlugs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
