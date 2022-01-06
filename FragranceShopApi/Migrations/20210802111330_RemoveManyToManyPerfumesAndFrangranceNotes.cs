using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class RemoveManyToManyPerfumesAndFrangranceNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FragranceNotePerfume");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FragranceNotePerfume",
                columns: table => new
                {
                    FragranceNotesId = table.Column<int>(type: "int", nullable: false),
                    PerfumesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragranceNotePerfume", x => new { x.FragranceNotesId, x.PerfumesId });
                    table.ForeignKey(
                        name: "FK_FragranceNotePerfume_FragranceNotes_FragranceNotesId",
                        column: x => x.FragranceNotesId,
                        principalTable: "FragranceNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FragranceNotePerfume_Perfumes_PerfumesId",
                        column: x => x.PerfumesId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotePerfume_PerfumesId",
                table: "FragranceNotePerfume",
                column: "PerfumesId");
        }
    }
}
