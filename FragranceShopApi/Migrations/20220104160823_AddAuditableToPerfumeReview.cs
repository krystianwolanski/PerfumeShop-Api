using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class AddAuditableToPerfumeReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "PerfumeReviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "PerfumeReviews",
                type: "datetime2",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "PerfumeReviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "PerfumeReviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeReviews_LastModifiedById",
                table: "PerfumeReviews",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeReviews_Users_LastModifiedById",
                table: "PerfumeReviews",
                column: "LastModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeReviews_Users_LastModifiedById",
                table: "PerfumeReviews");

            migrationBuilder.DropIndex(
                name: "IX_PerfumeReviews_LastModifiedById",
                table: "PerfumeReviews");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "PerfumeReviews");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "PerfumeReviews");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "PerfumeReviews");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "PerfumeReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
