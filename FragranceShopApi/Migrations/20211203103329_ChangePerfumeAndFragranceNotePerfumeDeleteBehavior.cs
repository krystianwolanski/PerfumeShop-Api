using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangePerfumeAndFragranceNotePerfumeDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNotes_FragranceNoteId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeBrands_PerfumeBrandId",
                table: "Perfumes");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNotes_FragranceNoteId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteId",
                principalTable: "FragranceNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeBrands_PerfumeBrandId",
                table: "Perfumes",
                column: "PerfumeBrandId",
                principalTable: "PerfumeBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNotes_FragranceNoteId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeBrands_PerfumeBrandId",
                table: "Perfumes");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNotes_FragranceNoteId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteId",
                principalTable: "FragranceNotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeBrands_PerfumeBrandId",
                table: "Perfumes",
                column: "PerfumeBrandId",
                principalTable: "PerfumeBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
