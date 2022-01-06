using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddAuditableToPerfumeBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "PerfumeBrands",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PerfumeBrands",
                type: "datetime2",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "PerfumeBrands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "PerfumeBrands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeBrands_LastModifiedById",
                table: "PerfumeBrands",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeBrands_Users_LastModifiedById",
                table: "PerfumeBrands",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeBrands_Users_LastModifiedById",
                table: "PerfumeBrands");

            migrationBuilder.DropIndex(
                name: "IX_PerfumeBrands_LastModifiedById",
                table: "PerfumeBrands");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PerfumeBrands");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "PerfumeBrands");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "PerfumeBrands");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "PerfumeBrands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
