using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddAuditableToPerfume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Perfumes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Perfumes",
                type: "datetime2",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Perfumes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Perfumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_LastModifiedById",
                table: "Perfumes",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_Users_LastModifiedById",
                table: "Perfumes",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_Users_LastModifiedById",
                table: "Perfumes");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_LastModifiedById",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Perfumes");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Perfumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
