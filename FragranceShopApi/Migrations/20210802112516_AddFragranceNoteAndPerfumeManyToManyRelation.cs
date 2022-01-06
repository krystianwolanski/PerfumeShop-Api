using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddFragranceNoteAndPerfumeManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FragranceNotesPerfumes",
                columns: table => new
                {
                    PerfumeId = table.Column<int>(type: "int", nullable: false),
                    FragranceNoteId = table.Column<int>(type: "int", nullable: false),
                    FragranceNoteType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragranceNotesPerfumes", x => new { x.PerfumeId, x.FragranceNoteId });
                    table.ForeignKey(
                        name: "FK_FragranceNotesPerfumes_FragranceNotes_FragranceNoteId",
                        column: x => x.FragranceNoteId,
                        principalTable: "FragranceNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FragranceNotesPerfumes_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteId",
                table: "FragranceNotesPerfumes",
                column: "FragranceNoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FragranceNotesPerfumes");
        }
    }
}
