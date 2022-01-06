using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddGenderTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SexType",
                table: "Perfumes",
                newName: "GenderTypeId");

            migrationBuilder.CreateTable(
                name: "PerfumeGenderTypes",
                columns: table => new
                {
                    PerfumeGenderTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeGenderTypes", x => x.PerfumeGenderTypeId);
                });

            migrationBuilder.InsertData(
                table: "PerfumeGenderTypes",
                columns: new[] { "PerfumeGenderTypeId", "Name" },
                values: new object[] { 0, "ForMen" });

            migrationBuilder.InsertData(
                table: "PerfumeGenderTypes",
                columns: new[] { "PerfumeGenderTypeId", "Name" },
                values: new object[] { 1, "ForWomen" });

            migrationBuilder.InsertData(
                table: "PerfumeGenderTypes",
                columns: new[] { "PerfumeGenderTypeId", "Name" },
                values: new object[] { 2, "Unisex" });

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_GenderTypeId",
                table: "Perfumes",
                column: "GenderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_GenderTypeId",
                table: "Perfumes",
                column: "GenderTypeId",
                principalTable: "PerfumeGenderTypes",
                principalColumn: "PerfumeGenderTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_PerfumeGenderTypes_GenderTypeId",
                table: "Perfumes");

            migrationBuilder.DropTable(
                name: "PerfumeGenderTypes");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_GenderTypeId",
                table: "Perfumes");

            migrationBuilder.RenameColumn(
                name: "GenderTypeId",
                table: "Perfumes",
                newName: "SexType");
        }
    }
}
