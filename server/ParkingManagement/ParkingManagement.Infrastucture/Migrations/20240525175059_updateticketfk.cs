using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class updateticketfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS");

            migrationBuilder.AddForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                principalTable: "VEHICLE",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS");

            migrationBuilder.AddForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                principalTable: "VEHICLE",
                principalColumn: "VehicleId");
        }
    }
}
