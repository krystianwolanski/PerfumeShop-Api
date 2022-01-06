using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FragranceShopApi.Migrations
{
    public partial class RemoveDefaultValuesFromFragranceNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "CreatedById",
               table: "FragranceNotes",
               type: "int",
               nullable: false,
               defaultValue: null,
               oldDefaultValue: 0);


            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FragranceNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: null,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "CreatedById",
               table: "FragranceNotes",
               type: "int",
               nullable: false,
               defaultValue: 0,
               oldDefaultValue: null);

            migrationBuilder.AlterColumn<DateTime>(
              name: "DateCreated",
              table: "FragranceNotes",
              type: "datetime2",
              nullable: false,
              defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
              oldDefaultValue: null);
        }
    }
}
