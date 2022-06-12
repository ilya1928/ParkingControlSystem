using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class RefactorCrews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvacuationCrews_AspNetUsers_ApplicationUserId",
                table: "EvacuationCrews");

            migrationBuilder.DropIndex(
                name: "IX_EvacuationCrews_ApplicationUserId",
                table: "EvacuationCrews");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "EvacuationCrews");

            migrationBuilder.CreateTable(
                name: "EvacuationCrewmates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ImageUri = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    EvacuationCrewId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvacuationCrewmates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvacuationCrewmates_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvacuationCrewmates_EvacuationCrews_EvacuationCrewId",
                        column: x => x.EvacuationCrewId,
                        principalTable: "EvacuationCrews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationCrewmates_ApplicationUserId",
                table: "EvacuationCrewmates",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EvacuationCrewmates_EvacuationCrewId",
                table: "EvacuationCrewmates",
                column: "EvacuationCrewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvacuationCrewmates");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "EvacuationCrews",
                type: "nvarchar(450)",
                nullable: true);

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
        }
    }
}
