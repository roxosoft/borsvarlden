using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class ArticleAddNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "FinwireNews",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrioDeadLine",
                table: "FinwireNews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "PrioDeadLine",
                table: "FinwireNews");
        }
    }
}
