using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddAuditableToPerfumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Perfumers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Perfumers",
                type: "datetime2",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Perfumers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Perfumers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumers_LastModifiedById",
                table: "Perfumers",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumers_Users_LastModifiedById",
                table: "Perfumers",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumers_Users_LastModifiedById",
                table: "Perfumers");

            migrationBuilder.DropIndex(
                name: "IX_Perfumers_LastModifiedById",
                table: "Perfumers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Perfumers");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Perfumers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Perfumers");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Perfumers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
