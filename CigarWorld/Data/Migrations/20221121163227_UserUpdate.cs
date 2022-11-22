using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_CigarPocketCases_AshtrayId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_CigarPocketCaseId",
                table: "User",
                column: "CigarPocketCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_CigarPocketCases_CigarPocketCaseId",
                table: "User",
                column: "CigarPocketCaseId",
                principalTable: "CigarPocketCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_CigarPocketCases_CigarPocketCaseId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CigarPocketCaseId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_CigarPocketCases_AshtrayId",
                table: "User",
                column: "AshtrayId",
                principalTable: "CigarPocketCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
