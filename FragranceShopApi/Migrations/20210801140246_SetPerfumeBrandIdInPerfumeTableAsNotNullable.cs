using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class SetPerfumeBrandIdInPerfumeTableAsNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_Perfumes_PerfumeBrandId", "Perfumes");

            migrationBuilder.AlterColumn<int>(
                name: "PerfumeBrandId",
                table: "Perfumes",
                type: "int",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeBrandId",
                table: "Perfumes",
                column: "PerfumeBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_Perfumes_PerfumeBrandId", "Perfumes");

            migrationBuilder.AlterColumn<int>(
                name: "PerfumeBrandId",
                table: "Perfumes",
                type: "int",
                nullable: true,
                oldDefaultValue: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeBrandId",
                table: "Perfumes",
                column: "PerfumeBrandId");
        }
    }
}
