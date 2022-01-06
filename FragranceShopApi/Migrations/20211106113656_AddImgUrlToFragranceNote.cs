using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddImgUrlToFragranceNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "FragranceNotes",
                type: "nvarchar(max)",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "FragranceNotes");
        }
    }
}
