using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangePerfumeGenderTypeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 0,
                column: "Name",
                value: "Męski");

            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 1,
                column: "Name",
                value: "Damski");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 0,
                column: "Name",
                value: "ForMen");

            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 1,
                column: "Name",
                value: "ForWomen");
        }
    }
}
