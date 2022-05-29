using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initialMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "transaction",
                table: "BankTransaction");

            migrationBuilder.AddColumn<double>(
                name: "Credit",
                table: "BankTransaction",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Debit",
                table: "BankTransaction",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "BankTransaction");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "BankTransaction");

            migrationBuilder.AddColumn<byte>(
                name: "transaction",
                table: "BankTransaction",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
