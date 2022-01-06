using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangeFragranceNotePerfumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FragranceNotesPerfumes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteId_FragranceNoteTypeId_PerfumeId",
                table: "FragranceNotesPerfumes",
                columns: new[] { "FragranceNoteId", "FragranceNoteTypeId", "PerfumeId" },
                unique: true);

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
                name: "IX_FragranceNotesPerfumes_FragranceNoteId_FragranceNoteTypeId_PerfumeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_PerfumeId",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FragranceNotesPerfumes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FragranceNotesPerfumes",
                table: "FragranceNotesPerfumes",
                columns: new[] { "PerfumeId", "FragranceNoteId", "FragranceNoteTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteId");
        }
    }
}
