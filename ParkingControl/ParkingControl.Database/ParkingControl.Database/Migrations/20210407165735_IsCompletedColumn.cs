using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingControl.Database.Migrations
{
    public partial class IsCompletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointedReports",
                table: "EvacuationCrews");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Reports",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "AppointedReports",
                table: "EvacuationCrews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
