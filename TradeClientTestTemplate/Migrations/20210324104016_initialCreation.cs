using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class initialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClOrdId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    limitPrice = table.Column<float>(type: "real", nullable: false),
                    stopPrice = table.Column<float>(type: "real", nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TimeInForce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.LocalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
