using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class AddBasePortalModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EvacuationCrewId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReportsHandlerId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EvacuationCrews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvacuationCrews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReportedDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportsHandlers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsHandlers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TowTruckTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowTruckTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GovernmentNumber = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerPhoneNumber = table.Column<string>(nullable: true),
                    OwnerIdentificationNumber = table.Column<string>(nullable: true),
                    VehicleTypeName = table.Column<string>(nullable: true),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportVehicles_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TowTruckVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GovernmentNumber = table.Column<string>(nullable: true),
                    MaxAcceptableWeight = table.Column<int>(nullable: false),
                    MaxAcceptableLength = table.Column<int>(nullable: false),
                    TowTruckTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowTruckVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowTruckVehicles_TowTruckTypes_TowTruckTypeId",
                        column: x => x.TowTruckTypeId,
                        principalTable: "TowTruckTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EvacuationCrewId",
                table: "AspNetUsers",
                column: "EvacuationCrewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReportsHandlerId",
                table: "AspNetUsers",
                column: "ReportsHandlerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportVehicles_ReportId",
                table: "ReportVehicles",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TowTruckVehicles_TowTruckTypeId",
                table: "TowTruckVehicles",
                column: "TowTruckTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EvacuationCrews_EvacuationCrewId",
                table: "AspNetUsers",
                column: "EvacuationCrewId",
                principalTable: "EvacuationCrews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ReportsHandlers_ReportsHandlerId",
                table: "AspNetUsers",
                column: "ReportsHandlerId",
                principalTable: "ReportsHandlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EvacuationCrews_EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ReportsHandlers_ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EvacuationCrews");

            migrationBuilder.DropTable(
                name: "ReportsHandlers");

            migrationBuilder.DropTable(
                name: "ReportVehicles");

            migrationBuilder.DropTable(
                name: "TowTruckVehicles");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "TowTruckTypes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportsHandlerId",
                table: "AspNetUsers");
        }
    }
}
