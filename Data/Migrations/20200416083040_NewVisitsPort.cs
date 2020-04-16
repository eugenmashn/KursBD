using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NewVisitsPort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PortId",
                table: "Visits",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PortId",
                table: "Visits",
                column: "PortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Ports_PortId",
                table: "Visits",
                column: "PortId",
                principalTable: "Ports",
                principalColumn: "PortId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Ports_PortId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PortId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PortId",
                table: "Visits");
        }
    }
}
