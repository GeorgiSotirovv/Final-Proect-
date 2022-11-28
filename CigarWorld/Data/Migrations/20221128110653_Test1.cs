using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AshtrayReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a881dc3d-fcdd-4c30-8519-e7d21cbb46a0", "AQAAAAEAACcQAAAAEAfmlrULruGcgVx9qDLHE1u1OTL5Uo0rxCHEeiO4HPIBKsyzMOvwddbDp7aZj5Ft4g==", "d273da85-e068-4c7f-86bf-bd66dac8cf34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f34db8e-535d-419f-8169-e4bb09b9e9cb", "AQAAAAEAACcQAAAAEP5z+ho6C6cD/9nXYDgp86ycvxaC32KCXBZdqgiSIV+64uFxwMWyMXwTQbBv/AEUMw==", "81b4f7f0-726b-44b8-8341-a5a28a46ad27" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AshtrayReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AshtrayId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AshtrayReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AshtrayReview_Ashtrays_AshtrayId",
                        column: x => x.AshtrayId,
                        principalTable: "Ashtrays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16310d5c-f8e7-4d4e-8a76-ed61a9c3f7ad", "AQAAAAEAACcQAAAAEBUL5Xfqo0o+KKQ7/uXOfedsPL6y6rNqZdxEJJmxtw315yR1LFykg3AJ3DteIhR4ww==", "39516a1c-42ce-48c1-8f6f-7b160d85ca14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f84552e6-01d7-4a96-855d-432bba31341e", "AQAAAAEAACcQAAAAEF77VF5Ms5CcG/aGyQOqgG404yhs209yUvpIXkr5K8y4BPatVpWSikE6WzhcR6fo8g==", "0215a267-5413-47a6-b838-52e42101ae68" });

            migrationBuilder.CreateIndex(
                name: "IX_AshtrayReview_AshtrayId",
                table: "AshtrayReview",
                column: "AshtrayId");
        }
    }
}
