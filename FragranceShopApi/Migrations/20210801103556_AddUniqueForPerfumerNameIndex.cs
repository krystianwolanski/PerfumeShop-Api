using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddUniqueForPerfumerNameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfumers_Name",
                table: "Perfumers");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumers_Name",
                table: "Perfumers",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfumers_Name",
                table: "Perfumers");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumers_Name",
                table: "Perfumers",
                column: "Name");
        }
    }
}
