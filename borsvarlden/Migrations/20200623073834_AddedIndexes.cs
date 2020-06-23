using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "FinwireNews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "FinwireNews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNews_Guid",
                table: "FinwireNews",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNews_Slug",
                table: "FinwireNews",
                column: "Slug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FinwireNews_Guid",
                table: "FinwireNews");

            migrationBuilder.DropIndex(
                name: "IX_FinwireNews_Slug",
                table: "FinwireNews");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "FinwireNews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "FinwireNews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
