using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class MoreImproveJobAdverts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "JobAdverts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "JobAdverts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "JobAdverts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "JobAdverts");
        }
    }
}
