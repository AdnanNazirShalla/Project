using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_Id",
                table: "Transactions");

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_userId",
                table: "Transactions",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_userId",
                table: "Transactions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_userId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_userId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_Id",
                table: "Transactions",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
