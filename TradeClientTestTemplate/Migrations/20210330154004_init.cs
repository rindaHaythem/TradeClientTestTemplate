using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquitiesSymbols",
                columns: table => new
                {
                    SymbolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquitiesSymbols", x => x.SymbolId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    portfolioManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClOrdId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    limitPrice = table.Column<float>(type: "real", nullable: false),
                    stopPrice = table.Column<float>(type: "real", nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TimeInForce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ordered = table.Column<int>(type: "int", nullable: false),
                    uncommited = table.Column<int>(type: "int", nullable: false),
                    placed = table.Column<int>(type: "int", nullable: false),
                    filled = table.Column<int>(type: "int", nullable: false),
                    leaves = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.portfolioManagerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquitiesSymbols");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
