using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdatePerfumeGenderTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 0);

            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 1,
                column: "Name",
                value: "Męski");

            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 2,
                column: "Name",
                value: "Damski");

            migrationBuilder.InsertData(
                table: "PerfumeGenderTypes",
                columns: new[] { "PerfumeGenderTypeId", "Name" },
                values: new object[] { 3, "Unisex" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 1,
                column: "Name",
                value: "Damski");

            migrationBuilder.UpdateData(
                table: "PerfumeGenderTypes",
                keyColumn: "PerfumeGenderTypeId",
                keyValue: 2,
                column: "Name",
                value: "Unisex");

            migrationBuilder.InsertData(
                table: "PerfumeGenderTypes",
                columns: new[] { "PerfumeGenderTypeId", "Name" },
                values: new object[] { 0, "Męski" });
        }
    }
}
