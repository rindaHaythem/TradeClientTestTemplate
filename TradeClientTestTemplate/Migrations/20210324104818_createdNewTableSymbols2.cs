using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class createdNewTableSymbols2 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquitiesSymbols");
        }
    }
}
