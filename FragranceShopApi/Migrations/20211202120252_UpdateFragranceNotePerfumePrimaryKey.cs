using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdateFragranceNotePerfumePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes",
                columns: new[] { "FragranceNoteId", "FragranceNoteTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_PerfumeId",
                table: "FragranceNotesPerfumes",
                column: "PerfumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_PerfumeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes",
                columns: new[] { "PerfumeId", "FragranceNoteId" });

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteId");
        }
    }
}
