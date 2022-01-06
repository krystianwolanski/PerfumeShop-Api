using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AdditionalColumnsToPerfumeAndNewTabelOfBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerfumeBrandId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexType",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PerfumeBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeBrands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeBrandId",
                table: "Perfumes",
                column: "PerfumeBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeBrands_Name",
                table: "PerfumeBrands",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeBrands_PerfumeBrandId",
                table: "Perfumes",
                column: "PerfumeBrandId",
                principalTable: "PerfumeBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeBrands_PerfumeBrandId",
                table: "Perfumes");

            migrationBuilder.DropTable(
                name: "PerfumeBrands");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_PerfumeBrandId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "PerfumeBrandId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "SexType",
                table: "Perfumes");
        }
    }
}
