using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdateFragranceNoteTypeIdAndPerfumeGenderTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropColumn(
                name: "FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteTypeId",
                principalTable: "FragranceNoteType",
                principalColumn: "FragranceNoteTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteTypeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddColumn<int>(
                name: "FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteTypeId1",
                principalTable: "FragranceNoteType",
                principalColumn: "FragranceNoteTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
