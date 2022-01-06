using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ModificationTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_Perfumers_PerfumerId",
                table: "Perfumes");

            migrationBuilder.DropTable(
                name: "PerfumesWarehouse");

            migrationBuilder.AlterColumn<int>(
                name: "PerfumerId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Perfumes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_Perfumers_PerfumerId",
                table: "Perfumes",
                column: "PerfumerId",
                principalTable: "Perfumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_Perfumers_PerfumerId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Perfumes");

            migrationBuilder.AlterColumn<int>(
                name: "PerfumerId",
                table: "Perfumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PerfumesWarehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfumeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumesWarehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfumesWarehouse_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfumesWarehouse_PerfumeId",
                table: "PerfumesWarehouse",
                column: "PerfumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_Perfumers_PerfumerId",
                table: "Perfumes",
                column: "PerfumerId",
                principalTable: "Perfumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
