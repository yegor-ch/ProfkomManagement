using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfkomManagement.Migrations
{
    public partial class AddContributionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Contribution",
                table: "Members",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contribution",
                table: "Members");
        }
    }
}
