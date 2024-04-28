using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class ConfigUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "USERS",
                newName: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "USERS",
                newName: "CartId");
        }
    }
}
