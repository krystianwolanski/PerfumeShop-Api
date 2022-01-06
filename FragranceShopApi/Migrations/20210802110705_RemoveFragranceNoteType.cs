using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class RemoveFragranceNoteType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FragranceNoteType",
                table: "FragranceNotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FragranceNoteType",
                table: "FragranceNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
