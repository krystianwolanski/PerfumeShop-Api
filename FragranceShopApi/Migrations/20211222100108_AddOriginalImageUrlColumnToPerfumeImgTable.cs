using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddOriginalImageUrlColumnToPerfumeImgTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalImageUrl",
                table: "PerfumeImgs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalImageUrl",
                table: "PerfumeImgs");
        }
    }
}
