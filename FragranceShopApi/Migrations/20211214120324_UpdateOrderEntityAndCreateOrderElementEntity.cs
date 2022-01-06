using Microsoft.EntityFrameworkCore.Migrations;

namespace FragranceShopApi.Migrations
{
    public partial class UpdateOrderEntityAndCreateOrderElementEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Perfumes_PerfumeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PerfumeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PerfumeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfumeId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderElements_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderElements_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderElements_OrderId",
                table: "OrderElements",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderElements_PerfumeId",
                table: "OrderElements",
                column: "PerfumeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderElements");

            migrationBuilder.AddColumn<int>(
                name: "PerfumeId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PerfumeId",
                table: "Orders",
                column: "PerfumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Perfumes_PerfumeId",
                table: "Orders",
                column: "PerfumeId",
                principalTable: "Perfumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
