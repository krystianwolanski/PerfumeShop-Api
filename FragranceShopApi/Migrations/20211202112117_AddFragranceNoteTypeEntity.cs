using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddFragranceNoteTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FragranceNoteType",
                table: "FragranceNotesPerfumes",
                newName: "FragranceNoteTypeId");

            migrationBuilder.AddColumn<int>(
                name: "FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FragranceNoteType",
                columns: table => new
                {
                    FragranceNoteTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragranceNoteType", x => x.FragranceNoteTypeId);
                });

            migrationBuilder.InsertData(
                table: "FragranceNoteType",
                columns: new[] { "FragranceNoteTypeId", "Name" },
                values: new object[] { 1, "Nuty głowy" });

            migrationBuilder.InsertData(
                table: "FragranceNoteType",
                columns: new[] { "FragranceNoteTypeId", "Name" },
                values: new object[] { 2, "Nuty serca" });

            migrationBuilder.InsertData(
                table: "FragranceNoteType",
                columns: new[] { "FragranceNoteTypeId", "Name" },
                values: new object[] { 3, "Nuty bazy" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotesPerfumes_FragranceNoteType_FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropTable(
                name: "FragranceNoteType");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotesPerfumes_FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes");

            migrationBuilder.DropColumn(
                name: "FragranceNoteTypeId1",
                table: "FragranceNotesPerfumes");

            migrationBuilder.RenameColumn(
                name: "FragranceNoteTypeId",
                table: "FragranceNotesPerfumes",
                newName: "FragranceNoteType");
        }
    }
}
