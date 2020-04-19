using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ChangedShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountStaff",
                table: "Ships",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountStaff",
                table: "Ships");
        }
    }
}
