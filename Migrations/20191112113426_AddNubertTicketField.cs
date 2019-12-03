using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfkomManagement.Migrations
{
    public partial class AddNubertTicketField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Faculties_FacultyID",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "FacultyID",
                table: "Members",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_FacultyID",
                table: "Members",
                newName: "IX_Members_FacultyId");

            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "Members",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Faculties_FacultyId",
                table: "Members",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Faculties_FacultyId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Members",
                newName: "FacultyID");

            migrationBuilder.RenameIndex(
                name: "IX_Members_FacultyId",
                table: "Members",
                newName: "IX_Members_FacultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Faculties_FacultyID",
                table: "Members",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
