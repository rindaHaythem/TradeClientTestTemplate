using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class alterningAttributespropr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTrader_traders_accountTraderstraderId",
                table: "AccountTrader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTrader",
                table: "AccountTrader");

            migrationBuilder.DropIndex(
                name: "IX_AccountTrader_listOfAccountsaccountId",
                table: "AccountTrader");

            migrationBuilder.RenameColumn(
                name: "accountTraderstraderId",
                table: "AccountTrader",
                newName: "listOfTraderstraderId");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Order",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTrader",
                table: "AccountTrader",
                columns: new[] { "listOfAccountsaccountId", "listOfTraderstraderId" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTrader_listOfTraderstraderId",
                table: "AccountTrader",
                column: "listOfTraderstraderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTrader_traders_listOfTraderstraderId",
                table: "AccountTrader",
                column: "listOfTraderstraderId",
                principalTable: "traders",
                principalColumn: "traderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTrader_traders_listOfTraderstraderId",
                table: "AccountTrader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTrader",
                table: "AccountTrader");

            migrationBuilder.DropIndex(
                name: "IX_AccountTrader_listOfTraderstraderId",
                table: "AccountTrader");

            migrationBuilder.RenameColumn(
                name: "listOfTraderstraderId",
                table: "AccountTrader",
                newName: "accountTraderstraderId");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTrader",
                table: "AccountTrader",
                columns: new[] { "accountTraderstraderId", "listOfAccountsaccountId" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTrader_listOfAccountsaccountId",
                table: "AccountTrader",
                column: "listOfAccountsaccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTrader_traders_accountTraderstraderId",
                table: "AccountTrader",
                column: "accountTraderstraderId",
                principalTable: "traders",
                principalColumn: "traderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
