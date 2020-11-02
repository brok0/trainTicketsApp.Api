using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainTickets.Infrastructure.Migrations
{
    public partial class addSaltToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "salt",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "Person");
        }
    }
}
