using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class ChangePerfumeGenderTypeNameOfId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerfumeGenderTypeId",
                table: "PerfumeGenderTypes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PerfumeGenderTypes",
                newName: "PerfumeGenderTypeId");
        }
    }
}
