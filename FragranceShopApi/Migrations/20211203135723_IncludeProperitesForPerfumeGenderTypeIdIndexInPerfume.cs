using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class IncludeProperitesForPerfumeGenderTypeIdIndexInPerfume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfumes_PerfumeGenderTypeId",
                table: "Perfumes");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeGenderTypeId",
                table: "Perfumes",
                column: "PerfumeGenderTypeId")
                .Annotation("SqlServer:Clustered", false)
                .Annotation("SqlServer:Include", new[] { "Quantity", "Price", "BasePrice", "Capacity", "PerfumeBrandId", "PerfumerId", "Year", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perfumes_PerfumeGenderTypeId",
                table: "Perfumes");

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_PerfumeGenderTypeId",
                table: "Perfumes",
                column: "PerfumeGenderTypeId");
        }
    }
}
