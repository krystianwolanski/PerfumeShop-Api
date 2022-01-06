using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangeFragranceNotePerfumeDeleteBehaviorToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteTypeId",
                principalTable: "FragranceNoteType",
                principalColumn: "FragranceNoteTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteTypeId",
                principalTable: "FragranceNoteType",
                principalColumn: "FragranceNoteTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
