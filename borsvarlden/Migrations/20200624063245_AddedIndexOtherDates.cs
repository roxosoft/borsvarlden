using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddedIndexOtherDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IndexActualDeadLine",
                table: "FinwireNews",
                column: "ActualDeadLine");

            migrationBuilder.CreateIndex(
                name: "IndexPrioDeadLine",
                table: "FinwireNews",
                column: "PrioDeadLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IndexActualDeadLine",
                table: "FinwireNews");

            migrationBuilder.DropIndex(
                name: "IndexPrioDeadLine",
                table: "FinwireNews");
        }
    }
}
