using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdatePerfumeImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "PerfumeImgs");

            migrationBuilder.AddColumn<string>(
                name: "FullscreenImageUrl",
                table: "PerfumeImgs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImageUrl",
                table: "PerfumeImgs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullscreenImageUrl",
                table: "PerfumeImgs");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageUrl",
                table: "PerfumeImgs");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "PerfumeImgs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
