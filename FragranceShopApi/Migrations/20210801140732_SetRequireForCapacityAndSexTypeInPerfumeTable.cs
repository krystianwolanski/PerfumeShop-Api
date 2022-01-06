using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class SetRequireForCapacityAndSexTypeInPerfumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Perfumes",
                nullable: false
            );

            migrationBuilder.AlterColumn<int>(
                name: "SexType",
                table: "Perfumes",
                nullable: false
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Perfumes",
                nullable: true
            );

            migrationBuilder.AlterColumn<int>(
                name: "SexType",
                table: "Perfumes",
                nullable: true
            );
        }
    }
}
