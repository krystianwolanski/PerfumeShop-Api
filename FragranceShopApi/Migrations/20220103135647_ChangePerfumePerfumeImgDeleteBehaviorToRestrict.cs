using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangePerfumePerfumeImgDeleteBehaviorToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeImgs_Perfumes_PerfumeId",
                table: "PerfumeImgs");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeImgs_Perfumes_PerfumeId",
                table: "PerfumeImgs",
                column: "PerfumeId",
                principalTable: "Perfumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeImgs_Perfumes_PerfumeId",
                table: "PerfumeImgs");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeImgs_Perfumes_PerfumeId",
                table: "PerfumeImgs",
                column: "PerfumeId",
                principalTable: "Perfumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
