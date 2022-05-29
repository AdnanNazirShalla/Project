using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class cghasg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankTransaction_Users_Id",
                table: "BankTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankTransaction",
                table: "BankTransaction");

            migrationBuilder.RenameTable(
                name: "BankTransaction",
                newName: "Transactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_Id",
                table: "Transactions",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_Id",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "BankTransaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankTransaction",
                table: "BankTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankTransaction_Users_Id",
                table: "BankTransaction",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
