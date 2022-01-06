using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdateImageColumnInFragranceNoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "FragranceNotes");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "FragranceNotes",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "FragranceNotes");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "FragranceNotes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
