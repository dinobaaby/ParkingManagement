using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class updatevhc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "VEHICLE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_TicketId",
                table: "VEHICLE",
                column: "TicketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICLE_TICKETS_TicketId",
                table: "VEHICLE",
                column: "TicketId",
                principalTable: "TICKETS",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "TICKETS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                principalTable: "VEHICLE",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
