using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedFinwireXmlNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinwireXmlNewsId",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinwireXmlNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireXmlNews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNews_FinwireXmlNewsId",
                table: "FinwireNews",
                column: "FinwireXmlNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinwireNews_FinwireXmlNews_FinwireXmlNewsId",
                table: "FinwireNews",
                column: "FinwireXmlNewsId",
                principalTable: "FinwireXmlNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinwireNews_FinwireXmlNews_FinwireXmlNewsId",
                table: "FinwireNews");

            migrationBuilder.DropTable(
                name: "FinwireXmlNews");

            migrationBuilder.DropIndex(
                name: "IX_FinwireNews_FinwireXmlNewsId",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FinwireXmlNewsId",
                table: "FinwireNews");
        }
    }
}
