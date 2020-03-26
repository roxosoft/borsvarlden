using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class CahngeDB_Structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FinwireNews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FinautoPassed",
                table: "FinwireNews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FinautoPublished",
                table: "FinwireNews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PathRelative",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinwireCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinwireSocialTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireSocialTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinwireNew2FinwireCompany",
                columns: table => new
                {
                    FinwireNewId = table.Column<int>(nullable: false),
                    FinwareCompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireNew2FinwireCompany", x => new { x.FinwireNewId, x.FinwareCompanyId });
                    table.ForeignKey(
                        name: "FK_FinwireNew2FinwireCompany_FinwireCompanies_FinwareCompanyId",
                        column: x => x.FinwareCompanyId,
                        principalTable: "FinwireCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinwireNew2FinwireCompany_FinwireNews_FinwareCompanyId",
                        column: x => x.FinwareCompanyId,
                        principalTable: "FinwireNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinwireNew2FirnwireSocialTag",
                columns: table => new
                {
                    FinwireNewId = table.Column<int>(nullable: false),
                    FinwireSocialTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireNew2FirnwireSocialTag", x => new { x.FinwireSocialTagId, x.FinwireNewId });
                    table.ForeignKey(
                        name: "FK_FinwireNew2FirnwireSocialTag_FinwireNews_FinwireNewId",
                        column: x => x.FinwireNewId,
                        principalTable: "FinwireNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinwireNew2FirnwireSocialTag_FinwireSocialTags_FinwireSocialTagId",
                        column: x => x.FinwireSocialTagId,
                        principalTable: "FinwireSocialTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNew2FinwireCompany_FinwareCompanyId",
                table: "FinwireNew2FinwireCompany",
                column: "FinwareCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNew2FirnwireSocialTag_FinwireNewId",
                table: "FinwireNew2FirnwireSocialTag",
                column: "FinwireNewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinwireNew2FinwireCompany");

            migrationBuilder.DropTable(
                name: "FinwireNew2FirnwireSocialTag");

            migrationBuilder.DropTable(
                name: "FinwireCompanies");

            migrationBuilder.DropTable(
                name: "FinwireSocialTags");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FinautoPassed",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FinautoPublished",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "PathRelative",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FinwireNews");
        }
    }
}
