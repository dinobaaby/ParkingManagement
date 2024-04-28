using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class updaterfr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_REFRESHTOKE_UserId",
                table: "REFRESHTOKE");

            migrationBuilder.CreateIndex(
                name: "IX_REFRESHTOKE_UserId",
                table: "REFRESHTOKE",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_REFRESHTOKE_UserId",
                table: "REFRESHTOKE");

            migrationBuilder.CreateIndex(
                name: "IX_REFRESHTOKE_UserId",
                table: "REFRESHTOKE",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
