using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class ReportsRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Locations_LocationId",
                table: "Reports");

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
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ReportVehicles_ReportId",
                table: "ReportVehicles",
                column: "ReportId",
                unique: true,
                filter: "[ReportId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Locations_LocationId",
                table: "Reports",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportVehicles_Reports_ReportId",
                table: "ReportVehicles",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Locations_LocationId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportVehicles_Reports_ReportId",
                table: "ReportVehicles");

            migrationBuilder.DropIndex(
                name: "IX_ReportVehicles_ReportId",
                table: "ReportVehicles");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ReportVehicles");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportVehicleId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportVehicleId",
                table: "Reports",
                column: "ReportVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Locations_LocationId",
                table: "Reports",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportVehicles_ReportVehicleId",
                table: "Reports",
                column: "ReportVehicleId",
                principalTable: "ReportVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
