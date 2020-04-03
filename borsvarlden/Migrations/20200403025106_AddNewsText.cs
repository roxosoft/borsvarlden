using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddNewsText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinwireNew2FinwireCompany_FinwireNews_FinwareCompanyId",
                table: "FinwireNew2FinwireCompany");

            migrationBuilder.AddColumn<string>(
                name: "Agency",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsText",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FinwireNew2FinwireCompany_FinwireNews_FinwireNewId",
                table: "FinwireNew2FinwireCompany",
                column: "FinwireNewId",
                principalTable: "FinwireNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinwireNew2FinwireCompany_FinwireNews_FinwireNewId",
                table: "FinwireNew2FinwireCompany");

            migrationBuilder.DropColumn(
                name: "Agency",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "NewsText",
                table: "FinwireNews");

            migrationBuilder.AddForeignKey(
                name: "FK_FinwireNew2FinwireCompany_FinwireNews_FinwareCompanyId",
                table: "FinwireNew2FinwireCompany",
                column: "FinwareCompanyId",
                principalTable: "FinwireNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
