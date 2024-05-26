using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class updateticketal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Loại bỏ khóa ngoại và chỉ mục
            migrationBuilder.DropForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS");

            migrationBuilder.DropIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS");

            // Thay đổi cột để cho phép null
            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "TICKETS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Tạo lại chỉ mục và khóa ngoại với cột cho phép null
            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS",
                column: "VehicleId",
                principalTable: "VEHICLE",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Loại bỏ khóa ngoại và chỉ mục
            migrationBuilder.DropForeignKey(
                name: "FK_TICKETS_VEHICLE_VehicleId",
                table: "TICKETS");

            migrationBuilder.DropIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS");

            // Thay đổi cột trở lại không cho phép null
            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "TICKETS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            // Tạo lại chỉ mục và khóa ngoại với cột không cho phép null
            migrationBuilder.CreateIndex(
                name: "IX_TICKETS_VehicleId",
                table: "TICKETS",
                column: "VehicleId");

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