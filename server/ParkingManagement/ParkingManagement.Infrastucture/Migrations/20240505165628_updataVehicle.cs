using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class updataVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleImage",
                table: "VEHICLE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleImage",
                table: "VEHICLE");
        }
    }
}
