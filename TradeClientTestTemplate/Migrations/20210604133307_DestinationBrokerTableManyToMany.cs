using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeClientTestTemplate.Migrations
{
    public partial class DestinationBrokerTableManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinationBrokers",
                columns: table => new
                {
                    BrokerID = table.Column<int>(type: "int", nullable: false),
                    DestinationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationBrokers", x => new { x.BrokerID, x.DestinationID });
                    table.ForeignKey(
                        name: "FK_DestinationBrokers_brokers_BrokerID",
                        column: x => x.BrokerID,
                        principalTable: "brokers",
                        principalColumn: "BrokerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationBrokers_destinations_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "destinations",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationBrokers_DestinationID",
                table: "DestinationBrokers",
                column: "DestinationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationBrokers");
        }
    }
}
