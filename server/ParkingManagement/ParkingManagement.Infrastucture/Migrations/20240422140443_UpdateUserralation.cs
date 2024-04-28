using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserralation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REFRESHTOKE_USERS_UserId",
                table: "REFRESHTOKE");

            migrationBuilder.AddForeignKey(
                name: "FK_REFRESHTOKE_USERS_UserId",
                table: "REFRESHTOKE",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REFRESHTOKE_USERS_UserId",
                table: "REFRESHTOKE");

            migrationBuilder.AddForeignKey(
                name: "FK_REFRESHTOKE_USERS_UserId",
                table: "REFRESHTOKE",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "Id");
        }
    }
}
