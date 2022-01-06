using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class RemoveDefaultConstraintsForNewPerfumeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Perfumes",
                type: "int",
                nullable: true,
                oldDefaultValue: true,
                defaultValue: null);

            migrationBuilder.AlterColumn<int>(
                name: "PerfumeBrandId",
                table: "Perfumes",
                type: "int",
                nullable: true,
                oldDefaultValue: true,
                defaultValue: null);

            migrationBuilder.AlterColumn<int>(
                name: "SexType",
                table: "Perfumes",
                type: "int",
                nullable: true,
                oldDefaultValue: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PerfumeBrandId",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SexType",
                table: "Perfumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
