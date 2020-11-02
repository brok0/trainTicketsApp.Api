using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainTickets.Infrastructure.Migrations
{
    public partial class addTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    To = table.Column<string>(maxLength: 200, nullable: false),
                    From = table.Column<string>(maxLength: 200, nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    TrainNumber = table.Column<string>(nullable: true),
                    TrainType = table.Column<string>(maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
