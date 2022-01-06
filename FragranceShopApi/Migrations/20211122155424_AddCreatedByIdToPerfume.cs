using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddCreatedByIdToPerfume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Perfumes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_CreatedById",
                table: "Perfumes",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_Users_CreatedById",
                table: "Perfumes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_Users_CreatedById",
                table: "Perfumes");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_CreatedById",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Perfumes");
        }
    }
}
