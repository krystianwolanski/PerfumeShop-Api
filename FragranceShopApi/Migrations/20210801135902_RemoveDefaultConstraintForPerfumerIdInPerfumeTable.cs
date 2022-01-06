using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class RemoveDefaultConstraintForPerfumerIdInPerfumeTable : Migration
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
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
