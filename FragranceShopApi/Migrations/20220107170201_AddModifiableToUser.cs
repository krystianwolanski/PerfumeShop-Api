using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddModifiableToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastModifiedById",
                table: "Users",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_LastModifiedById",
                table: "Users",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_LastModifiedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LastModifiedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Users");
        }
    }
}
