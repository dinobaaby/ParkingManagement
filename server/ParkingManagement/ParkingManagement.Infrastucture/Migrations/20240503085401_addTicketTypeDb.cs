using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class addTicketTypeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TICKETTYPE",
                columns: table => new
                {
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketTypePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKETTYPE", x => x.TicketTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TICKETTYPE");
        }
    }
}
