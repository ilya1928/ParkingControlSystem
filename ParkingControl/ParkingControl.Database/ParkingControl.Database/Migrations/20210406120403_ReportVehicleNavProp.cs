using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class ReportVehicleNavProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportVehicles_Reports_ReportId",
                table: "ReportVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ReportVehicles_ReportId",
                table: "ReportVehicles");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ReportVehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportVehicleId",
                table: "Reports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportVehicleId",
                table: "Reports",
                column: "ReportVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportVehicles_ReportVehicleId",
                table: "Reports",
                column: "ReportVehicleId",
                principalTable: "ReportVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportVehicles_ReportVehicleId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportVehicleId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportVehicleId",
                table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "ReportVehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReportVehicles_ReportId",
                table: "ReportVehicles",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportVehicles_Reports_ReportId",
                table: "ReportVehicles",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
