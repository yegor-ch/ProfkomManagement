using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfkomManagement.Migrations
{
    public partial class RenameFieldNumberOfTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketNumber",
                table: "Members",
                newName: "NumberOfTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfTicket",
                table: "Members",
                newName: "TicketNumber");
        }
    }
}
