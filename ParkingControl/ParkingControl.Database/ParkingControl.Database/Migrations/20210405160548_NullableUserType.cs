using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class NullableUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EvacuationCrews_EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ReportsHandlers_ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ReportsHandlers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "EvacuationCrews",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReportsHandlerId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EvacuationCrewId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EvacuationCrewId",
                table: "AspNetUsers",
                column: "EvacuationCrewId",
                unique: true,
                filter: "[EvacuationCrewId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReportsHandlerId",
                table: "AspNetUsers",
                column: "ReportsHandlerId",
                unique: true,
                filter: "[ReportsHandlerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EvacuationCrews_EvacuationCrewId",
                table: "AspNetUsers",
                column: "EvacuationCrewId",
                principalTable: "EvacuationCrews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ReportsHandlers_ReportsHandlerId",
                table: "AspNetUsers",
                column: "ReportsHandlerId",
                principalTable: "ReportsHandlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EvacuationCrews_EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ReportsHandlers_ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ReportsHandlers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "EvacuationCrews",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReportsHandlerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EvacuationCrewId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
    }
}
