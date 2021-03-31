using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class addingTradersandAccountsTables : Migration
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
                name: "AccountTrader",
                columns: table => new
                {
                    accountTraderstraderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    listOfAccountsaccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTrader", x => new { x.accountTraderstraderId, x.listOfAccountsaccountId });
                    table.ForeignKey(
                        name: "FK_AccountTrader_accounts_listOfAccountsaccountId",
                        column: x => x.listOfAccountsaccountId,
                        principalTable: "accounts",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTrader_traders_accountTraderstraderId",
                        column: x => x.accountTraderstraderId,
                        principalTable: "traders",
                        principalColumn: "traderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTrader_listOfAccountsaccountId",
                table: "AccountTrader",
                column: "listOfAccountsaccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTrader");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "traders");
        }
    }
}
