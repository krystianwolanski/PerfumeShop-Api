using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddFragranceNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FragranceNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FragranceNoteType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragranceNotes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FragranceNotePerfume");

            migrationBuilder.DropTable(
                name: "FragranceNotes");
        }
    }
}
