using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainTickets.Infrastructure.Migrations
{
    public partial class addRelationPersonTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PersonID",
                table: "Tickets",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Person_PersonID",
                table: "Tickets",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Person_PersonID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PersonID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Tickets");
        }
    }
}
