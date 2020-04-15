using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountPort = table.Column<int>(nullable: false),
                    Capital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsPort = table.Column<bool>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    PortId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TypePort = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    CountPrichal = table.Column<int>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.PortId);
                    table.ForeignKey(
                        name: "FK_Ports_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ShipId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TypeShip = table.Column<string>(nullable: true),
                    Lenght = table.Column<int>(nullable: false),
                    Witch = table.Column<int>(nullable: false),
                    PortId = table.Column<Guid>(nullable: false),
                    color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.ShipId);
                    table.ForeignKey(
                        name: "FK_Ships_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<int>(nullable: false),
                    HeightWave = table.Column<int>(nullable: false),
                    WindSpeed = table.Column<int>(nullable: false),
                    PortId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_Weathers_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffPeople",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirstDay = table.Column<DateTime>(nullable: false),
                    stat = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    ShipId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPeople", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_StaffPeople_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffPeople_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitsId = table.Column<Guid>(nullable: false),
                    DateArrival = table.Column<DateTime>(nullable: false),
                    DateDeparture = table.Column<DateTime>(nullable: false),
                    ShipId = table.Column<Guid>(nullable: false),
                    NumberPrich = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitsId);
                    table.ForeignKey(
                        name: "FK_Visits_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_CityId",
                table: "Ports",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PortId",
                table: "Ships",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPeople_CityId",
                table: "StaffPeople",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPeople_ShipId",
                table: "StaffPeople",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ShipId",
                table: "Visits",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_PortId",
                table: "Weathers",
                column: "PortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffPeople");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
