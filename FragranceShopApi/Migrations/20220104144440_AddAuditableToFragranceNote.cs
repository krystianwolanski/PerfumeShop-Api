using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddAuditableToFragranceNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceNotes_Users_CreatedById",
                table: "FragranceNotes");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "FragranceNotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "FragranceNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "FragranceNotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "FragranceNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FragranceNotes_LastModifiedById",
                table: "FragranceNotes",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotes_Users_CreatedById",
                table: "FragranceNotes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotes_Users_LastModifiedById",
                table: "FragranceNotes",
                column: "LastModifiedById",
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
                name: "FK_FragranceNotes_Users_LastModifiedById",
                table: "FragranceNotes");

            migrationBuilder.DropIndex(
                name: "IX_FragranceNotes_LastModifiedById",
                table: "FragranceNotes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "FragranceNotes");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "FragranceNotes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "FragranceNotes");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "FragranceNotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceNotes_Users_CreatedById",
                table: "FragranceNotes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
