using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class zcz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_userId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_userId",
                table: "Transactions",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_userId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_userId",
                table: "Transactions",
                column: "userId",
                unique: true);
        }
    }
}
