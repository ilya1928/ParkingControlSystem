using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class FixHandlerDistricts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportsHandlerDistrict_Districts_DistrictId",
                table: "ReportsHandlerDistrict");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsHandlerDistrict_ReportsHandlers_ReportsHandlerId",
                table: "ReportsHandlerDistrict");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportsHandlerDistrict",
                table: "ReportsHandlerDistrict");

            migrationBuilder.RenameTable(
                name: "ReportsHandlerDistrict",
                newName: "ReportsHandlerDistricts");

            migrationBuilder.RenameIndex(
                name: "IX_ReportsHandlerDistrict_DistrictId",
                table: "ReportsHandlerDistricts",
                newName: "IX_ReportsHandlerDistricts_DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportsHandlerDistricts",
                table: "ReportsHandlerDistricts",
                columns: new[] { "ReportsHandlerId", "DistrictId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsHandlerDistricts_Districts_DistrictId",
                table: "ReportsHandlerDistricts",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsHandlerDistricts_ReportsHandlers_ReportsHandlerId",
                table: "ReportsHandlerDistricts",
                column: "ReportsHandlerId",
                principalTable: "ReportsHandlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportsHandlerDistricts_Districts_DistrictId",
                table: "ReportsHandlerDistricts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsHandlerDistricts_ReportsHandlers_ReportsHandlerId",
                table: "ReportsHandlerDistricts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportsHandlerDistricts",
                table: "ReportsHandlerDistricts");

            migrationBuilder.RenameTable(
                name: "ReportsHandlerDistricts",
                newName: "ReportsHandlerDistrict");

            migrationBuilder.RenameIndex(
                name: "IX_ReportsHandlerDistricts_DistrictId",
                table: "ReportsHandlerDistrict",
                newName: "IX_ReportsHandlerDistrict_DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportsHandlerDistrict",
                table: "ReportsHandlerDistrict",
                columns: new[] { "ReportsHandlerId", "DistrictId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsHandlerDistrict_Districts_DistrictId",
                table: "ReportsHandlerDistrict",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsHandlerDistrict_ReportsHandlers_ReportsHandlerId",
                table: "ReportsHandlerDistrict",
                column: "ReportsHandlerId",
                principalTable: "ReportsHandlers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
