
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class RemoveDefaultConstraintsForPerfumes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PerfumerId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Perfumes",
                type: "real",
                nullable: false,
                defaultValue: null);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PerfumerId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Perfumes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
