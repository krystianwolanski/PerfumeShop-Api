using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddCreatedByIdToAnotherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Perfumers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "PerfumeBrands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "FragranceNotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumers_CreatedById",
                table: "Perfumers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeBrands_CreatedById",
                table: "PerfumeBrands",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotes_CreatedById",
                table: "FragranceNotes",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotes_Users_CreatedById",
                table: "FragranceNotes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeBrands_Users_CreatedById",
                table: "PerfumeBrands",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumers_Users_CreatedById",
                table: "Perfumers",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotes_Users_CreatedById",
                table: "FragranceNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeBrands_Users_CreatedById",
                table: "PerfumeBrands");

            migrationBuilder.DropForeignKey(
                name: "FK_Perfumers_Users_CreatedById",
                table: "Perfumers");

            migrationBuilder.DropIndex(
                name: "IX_Perfumers_CreatedById",
                table: "Perfumers");

            migrationBuilder.DropIndex(
                name: "IX_PerfumeBrands_CreatedById",
                table: "PerfumeBrands");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotes_CreatedById",
                table: "FragranceNotes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Perfumers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PerfumeBrands");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "FragranceNotes");
        }
    }
}
