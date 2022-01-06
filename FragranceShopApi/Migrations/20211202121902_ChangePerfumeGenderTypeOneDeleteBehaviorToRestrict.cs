using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangePerfumeGenderTypeOneDeleteBehaviorToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_PerfumeGenderTypeId",
                table: "Perfumes");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_PerfumeGenderTypeId",
                table: "Perfumes",
                column: "PerfumeGenderTypeId",
                principalTable: "PerfumeGenderTypes",
                principalColumn: "PerfumeGenderTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_PerfumeGenderTypeId",
                table: "Perfumes");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_PerfumeGenderTypeId",
                table: "Perfumes",
                column: "PerfumeGenderTypeId",
                principalTable: "PerfumeGenderTypes",
                principalColumn: "PerfumeGenderTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
