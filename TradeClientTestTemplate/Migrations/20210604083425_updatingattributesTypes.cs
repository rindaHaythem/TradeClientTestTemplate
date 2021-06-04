using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class updatingattributesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Placement");

            migrationBuilder.DropColumn(
                name: "Side",
                table: "Placement");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Placement");

            migrationBuilder.RenameColumn(
                name: "TransactTime",
                table: "Placement",
                newName: "SendingTime");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Placement",
                newName: "DestinationID");

            migrationBuilder.AlterColumn<decimal>(
                name: "AvgPrice",
                table: "Placement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SendingTime",
                table: "Placement",
                newName: "TransactTime");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "Placement",
                newName: "Destination");

            migrationBuilder.AlterColumn<string>(
                name: "AvgPrice",
                table: "Placement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Placement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Side",
                table: "Placement",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Placement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
