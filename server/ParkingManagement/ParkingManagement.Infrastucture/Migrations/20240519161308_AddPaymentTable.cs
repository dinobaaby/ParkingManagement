using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingManagement.Infrastucture.Migrations
{
    
    public partial class AddPaymentTable : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleImage",
                table: "TICKETS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "TICKETS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PAYMENT",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PAYMENT_BILLS_BillId",
                        column: x => x.BillId,
                        principalTable: "BILLS",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BANKRANSFER",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANKRANSFER", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_BANKRANSFER_PAYMENT_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PAYMENT",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CASH",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    CashTendered = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASH", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_CASH_PAYMENT_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PAYMENT",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CREDIT",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CREDIT", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_CREDIT_PAYMENT_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "PAYMENT",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_BillId",
                table: "PAYMENT",
                column: "BillId",
                unique: true);
        }

       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANKRANSFER");

            migrationBuilder.DropTable(
                name: "CASH");

            migrationBuilder.DropTable(
                name: "CREDIT");

            migrationBuilder.DropTable(
                name: "PAYMENT");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleImage",
                table: "TICKETS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "TICKETS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
