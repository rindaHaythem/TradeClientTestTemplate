using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    accountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    accountSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.accountId);
                });

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
                    limitPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stopPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TimeInForce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ordered = table.Column<int>(type: "int", nullable: false),
                    uncommited = table.Column<int>(type: "int", nullable: false),
                    placed = table.Column<int>(type: "int", nullable: false),
                    filled = table.Column<int>(type: "int", nullable: false),
                    leaves = table.Column<int>(type: "int", nullable: false),
                    account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquityFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateGTD = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.portfolioManagerId);
                });

            migrationBuilder.CreateTable(
                name: "traders",
                columns: table => new
                {
                    traderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    traderSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traderFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traders", x => x.traderId);
                });

            migrationBuilder.CreateTable(
                name: "TradersAccounts",
                columns: table => new
                {
                    TraderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradersAccounts", x => new { x.AccountID, x.TraderID });
                    table.ForeignKey(
                        name: "FK_TradersAccounts_accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "accounts",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradersAccounts_traders_TraderID",
                        column: x => x.TraderID,
                        principalTable: "traders",
                        principalColumn: "traderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradersAccounts_TraderID",
                table: "TradersAccounts",
                column: "TraderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquitiesSymbols");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "TradersAccounts");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "traders");
        }
    }
}
