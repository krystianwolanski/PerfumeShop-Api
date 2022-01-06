using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdatePerfumeColumnNameGenderTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_GenderTypeId",
                table: "Perfumes");

            migrationBuilder.RenameColumn(
                name: "GenderTypeId",
                table: "Perfumes",
                newName: "PerfumeGenderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Perfumes_GenderTypeId",
                table: "Perfumes",
                newName: "IX_Perfumes_PerfumeGenderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_PerfumeGenderTypeId",
                table: "Perfumes",
                column: "PerfumeGenderTypeId",
                principalTable: "PerfumeGenderTypes",
                principalColumn: "PerfumeGenderTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_PerfumeGenderTypeId",
                table: "Perfumes");

            migrationBuilder.RenameColumn(
                name: "PerfumeGenderTypeId",
                table: "Perfumes",
                newName: "GenderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Perfumes_PerfumeGenderTypeId",
                table: "Perfumes",
                newName: "IX_Perfumes_GenderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_GenderTypeId",
                table: "Perfumes",
                column: "GenderTypeId",
                principalTable: "PerfumeGenderTypes",
                principalColumn: "PerfumeGenderTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
