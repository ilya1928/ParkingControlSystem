using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class FixHandlersDistricts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Districts_CityId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ReportsHandlers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ReportsHandlers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Districts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ReportsHandlers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReportsHandlerDistrict",
                columns: table => new
                {
                    ReportsHandlerId = table.Column<Guid>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsHandlerDistrict", x => new { x.ReportsHandlerId, x.DistrictId });
                    table.ForeignKey(
                        name: "FK_ReportsHandlerDistrict_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportsHandlerDistrict_ReportsHandlers_ReportsHandlerId",
                        column: x => x.ReportsHandlerId,
                        principalTable: "ReportsHandlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportsHandlerDistrict_DistrictId",
                table: "ReportsHandlerDistrict",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportsHandlerDistrict");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ReportsHandlers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ReportsHandlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ReportsHandlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Districts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
