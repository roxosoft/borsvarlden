using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class AddFinwireAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agency",
                table: "FinwireNews");

            migrationBuilder.AddColumn<int>(
                name: "FinwireAgencyId",
                table: "FinwireNews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinwireAgencyId",
                table: "FinwireCompanies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinwireAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinwireAgencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinwireNews_FinwireAgencyId",
                table: "FinwireNews",
                column: "FinwireAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FinwireCompanies_FinwireAgencyId",
                table: "FinwireCompanies",
                column: "FinwireAgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinwireCompanies_FinwireAgencies_FinwireAgencyId",
                table: "FinwireCompanies",
                column: "FinwireAgencyId",
                principalTable: "FinwireAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinwireNews_FinwireAgencies_FinwireAgencyId",
                table: "FinwireNews",
                column: "FinwireAgencyId",
                principalTable: "FinwireAgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinwireCompanies_FinwireAgencies_FinwireAgencyId",
                table: "FinwireCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_FinwireNews_FinwireAgencies_FinwireAgencyId",
                table: "FinwireNews");

            migrationBuilder.DropTable(
                name: "FinwireAgencies");

            migrationBuilder.DropIndex(
                name: "IX_FinwireNews_FinwireAgencyId",
                table: "FinwireNews");

            migrationBuilder.DropIndex(
                name: "IX_FinwireCompanies_FinwireAgencyId",
                table: "FinwireCompanies");

            migrationBuilder.DropColumn(
                name: "FinwireAgencyId",
                table: "FinwireNews");

            migrationBuilder.DropColumn(
                name: "FinwireAgencyId",
                table: "FinwireCompanies");

            migrationBuilder.AddColumn<string>(
                name: "Agency",
                table: "FinwireNews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
