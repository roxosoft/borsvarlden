using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class FiltersSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FinwireFilters",
                columns: new[] { "Id", "FinwireFilterType", "Value" },
                values: new object[,]
                {
                    { 1, (short)1, "Stockholm Bullets" },
                    { 26, (short)4, "avanza" },
                    { 25, (short)3, "tech" },
                    { 24, (short)3, "stockholmbullets" },
                    { 23, (short)3, "share" },
                    { 22, (short)3, "macro" },
                    { 21, (short)3, "ipo" },
                    { 20, (short)3, "gaming" },
                    { 19, (short)3, "funding" },
                    { 18, (short)3, "dividend" },
                    { 17, (short)3, "cryptocurrency" },
                    { 16, (short)3, "crowdfunding" },
                    { 15, (short)3, "commodities" },
                    { 14, (short)3, "biometrics" },
                    { 13, (short)3, "betting" },
                    { 12, (short)3, "automotive" },
                    { 11, (short)3, "analytics" },
                    { 10, (short)2, "(rättelse)" },
                    { 9, (short)2, "(r)" },
                    { 8, (short)2, "(omsändning)" },
                    { 7, (short)2, "(forts)" },
                    { 6, (short)2, "(Oms)" },
                    { 5, (short)2, "(uppdaterad)" },
                    { 4, (short)2, "(uppdatering)" },
                    { 3, (short)1, "Dagens aktierekommendationer i översikt" },
                    { 2, (short)1, "Stocks in Play" },
                    { 27, (short)4, "nordent" },
                    { 28, (short)4, "hm" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FinwireFilters",
                keyColumn: "Id",
                keyValue: 28);
        }
    }
}
