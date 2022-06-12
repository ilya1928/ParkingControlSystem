using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowTrucks_EvacuationCrews_EvacuationCrewId",
                table: "TowTrucks");

            migrationBuilder.DropIndex(
                name: "IX_TowTrucks_EvacuationCrewId",
                table: "TowTrucks");

            migrationBuilder.DropColumn(
                name: "EvacuationCrewId",
                table: "TowTrucks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TowTrucks",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TowTruckId",
                table: "EvacuationCrews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationCrews_TowTruckId",
                table: "EvacuationCrews",
                column: "TowTruckId",
                unique: true,
                filter: "[TowTruckId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EvacuationCrews_TowTrucks_TowTruckId",
                table: "EvacuationCrews",
                column: "TowTruckId",
                principalTable: "TowTrucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvacuationCrews_TowTrucks_TowTruckId",
                table: "EvacuationCrews");

            migrationBuilder.DropIndex(
                name: "IX_EvacuationCrews_TowTruckId",
                table: "EvacuationCrews");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TowTrucks");

            migrationBuilder.DropColumn(
                name: "TowTruckId",
                table: "EvacuationCrews");

            migrationBuilder.AddColumn<Guid>(
                name: "EvacuationCrewId",
                table: "TowTrucks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TowTrucks_EvacuationCrewId",
                table: "TowTrucks",
                column: "EvacuationCrewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TowTrucks_EvacuationCrews_EvacuationCrewId",
                table: "TowTrucks",
                column: "EvacuationCrewId",
                principalTable: "EvacuationCrews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
