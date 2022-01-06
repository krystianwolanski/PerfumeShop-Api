using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddAuditableToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastModifiedById",
                table: "Orders",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_LastModifiedById",
                table: "Orders",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_LastModifiedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LastModifiedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
