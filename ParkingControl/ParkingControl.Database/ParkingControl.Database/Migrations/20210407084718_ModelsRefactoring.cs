using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class ModelsRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TowTruckVehicles");

            migrationBuilder.DropTable(
                name: "TowTruckTypes");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "EvacuationCrewId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Reports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportsHandlerId",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointedReports",
                table: "EvacuationCrews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportVehicleTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportVehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TowTrucks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GovernmentNumber = table.Column<string>(nullable: true),
                    MaxAcceptableWeight = table.Column<int>(nullable: false),
                    MaxAcceptableLength = table.Column<int>(nullable: false),
                    EvacuationCrewId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowTrucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TowTrucks_EvacuationCrews_EvacuationCrewId",
                        column: x => x.EvacuationCrewId,
                        principalTable: "EvacuationCrews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TowTruckReportVehicleTypes",
                columns: table => new
                {
                    TowTruckId = table.Column<Guid>(nullable: false),
                    ReportVehicleTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowTruckReportVehicleTypes", x => new { x.TowTruckId, x.ReportVehicleTypeId });
                    table.ForeignKey(
                        name: "FK_TowTruckReportVehicleTypes_ReportVehicleTypes_ReportVehicleTypeId",
                        column: x => x.ReportVehicleTypeId,
                        principalTable: "ReportVehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TowTruckReportVehicleTypes_TowTrucks_TowTruckId",
                        column: x => x.TowTruckId,
                        principalTable: "TowTrucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<Guid>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvacuationCrewDistricts",
                columns: table => new
                {
                    EvacuationCrewId = table.Column<Guid>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvacuationCrewDistricts", x => new { x.EvacuationCrewId, x.DistrictId });
                    table.ForeignKey(
                        name: "FK_EvacuationCrewDistricts_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvacuationCrewDistricts_EvacuationCrews_EvacuationCrewId",
                        column: x => x.EvacuationCrewId,
                        principalTable: "EvacuationCrews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EvacuationCrewId",
                table: "Reports",
                column: "EvacuationCrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_LocationId",
                table: "Reports",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportsHandlerId",
                table: "Reports",
                column: "ReportsHandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationCrewDistricts_DistrictId",
                table: "EvacuationCrewDistricts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TowTruckReportVehicleTypes_ReportVehicleTypeId",
                table: "TowTruckReportVehicleTypes",
                column: "ReportVehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TowTrucks_EvacuationCrewId",
                table: "TowTrucks",
                column: "EvacuationCrewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_EvacuationCrews_EvacuationCrewId",
                table: "Reports",
                column: "EvacuationCrewId",
                principalTable: "EvacuationCrews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Locations_LocationId",
                table: "Reports",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportsHandlers_ReportsHandlerId",
                table: "Reports",
                column: "ReportsHandlerId",
                principalTable: "ReportsHandlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_EvacuationCrews_EvacuationCrewId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Locations_LocationId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportsHandlers_ReportsHandlerId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "EvacuationCrewDistricts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "TowTruckReportVehicleTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ReportVehicleTypes");

            migrationBuilder.DropTable(
                name: "TowTrucks");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Reports_EvacuationCrewId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_LocationId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportsHandlerId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "EvacuationCrewId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportsHandlerId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AppointedReports",
                table: "EvacuationCrews");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TowTruckTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowTruckTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TowTruckVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GovernmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxAcceptableLength = table.Column<int>(type: "int", nullable: false),
                    MaxAcceptableWeight = table.Column<int>(type: "int", nullable: false),
                    TowTruckTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_TowTruckVehicles_TowTruckTypeId",
                table: "TowTruckVehicles",
                column: "TowTruckTypeId");
        }
    }
}
