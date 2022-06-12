using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class ProfileEdit : Migration
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

            migrationBuilder.DropColumn(
                name: "EvacuationCrewId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReportsHandlerId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ReportsHandlers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "ReportsHandlers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "EvacuationCrews",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportsHandlers_ApplicationUserId",
                table: "ReportsHandlers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationCrews_ApplicationUserId",
                table: "EvacuationCrews",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EvacuationCrews_AspNetUsers_ApplicationUserId",
                table: "EvacuationCrews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsHandlers_AspNetUsers_ApplicationUserId",
                table: "ReportsHandlers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvacuationCrews_AspNetUsers_ApplicationUserId",
                table: "EvacuationCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsHandlers_AspNetUsers_ApplicationUserId",
                table: "ReportsHandlers");

            migrationBuilder.DropIndex(
                name: "IX_ReportsHandlers_ApplicationUserId",
                table: "ReportsHandlers");

            migrationBuilder.DropIndex(
                name: "IX_EvacuationCrews_ApplicationUserId",
                table: "EvacuationCrews");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "ReportsHandlers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "ReportsHandlers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "EvacuationCrews",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EvacuationCrewId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReportsHandlerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
