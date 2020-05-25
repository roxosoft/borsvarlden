using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class NewsMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsMetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinwireNewId = table.Column<int>(nullable: false),
                    MetaKey = table.Column<string>(nullable: true),
                    MetaValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsMetas_FinwireNews_FinwireNewId",
                        column: x => x.FinwireNewId,
                        principalTable: "FinwireNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsMetas_FinwireNewId",
                table: "NewsMetas",
                column: "FinwireNewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsMetas");
        }
    }
}
