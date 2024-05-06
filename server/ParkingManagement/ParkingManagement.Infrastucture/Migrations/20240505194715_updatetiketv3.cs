using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class updatetiketv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS");

            migrationBuilder.DropIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "TICKETS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS");

            migrationBuilder.DropIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "TICKETS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                principalTable: "VEHICLE",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
