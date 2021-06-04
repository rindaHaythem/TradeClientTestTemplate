using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class brokerTablel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrokerSymbol",
                table: "brokers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrokerSymbol",
                table: "brokers");
        }
    }
}
