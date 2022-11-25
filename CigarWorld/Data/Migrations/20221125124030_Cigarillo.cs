using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class Cigarillo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cigarillos_FilterTypes_FiterId",
                table: "Cigarillos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarillo_Cigarillos_CigarilloId",
                table: "UserCigarillo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cigarillos",
                table: "Cigarillos");

            migrationBuilder.RenameTable(
                name: "Cigarillos",
                newName: "Cigarillo");

            migrationBuilder.RenameIndex(
                name: "IX_Cigarillos_FiterId",
                table: "Cigarillo",
                newName: "IX_Cigarillo_FiterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cigarillo",
                table: "Cigarillo",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16393f5c-dc17-4647-9328-bfc52a499e6e", "AQAAAAEAACcQAAAAELv53+cwgvkiWXotUlGy2uJTuzog/ri8Hfi436shELxgYY5aDZzTwvC5dA4LOkBumA==", "bdf225ab-ff84-4ed7-8fbe-2c4a82363cbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a01360-1c42-420f-b84c-a1a97c06815a", "AQAAAAEAACcQAAAAEAN22hjmglrHrK71EZ4hGfrbunWPYtcwjM3Wt1bJYFbqtQdas+K8XmZ4sUjlx72IlQ==", "126cf993-61ad-4f2d-a06b-32c5bbe4e28b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cigarillo_FilterTypes_FiterId",
                table: "Cigarillo",
                column: "FiterId",
                principalTable: "FilterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarillo_Cigarillo_CigarilloId",
                table: "UserCigarillo",
                column: "CigarilloId",
                principalTable: "Cigarillo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cigarillo_FilterTypes_FiterId",
                table: "Cigarillo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarillo_Cigarillo_CigarilloId",
                table: "UserCigarillo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cigarillo",
                table: "Cigarillo");

            migrationBuilder.RenameTable(
                name: "Cigarillo",
                newName: "Cigarillos");

            migrationBuilder.RenameIndex(
                name: "IX_Cigarillo_FiterId",
                table: "Cigarillos",
                newName: "IX_Cigarillos_FiterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cigarillos",
                table: "Cigarillos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a28a4808-dacb-4de5-9eb1-b21f6adb0d23", "AQAAAAEAACcQAAAAEIwk0moeu2k7UWkv2LVNFbZE6T5W3uIWib6CF8QNrGyTuJOSRaUVtUPnApEEbGgXsQ==", "d1007353-c4be-4ad5-b2ec-d94c869cef74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5986e200-70fd-428a-ac45-f0f5bee44a06", "AQAAAAEAACcQAAAAEOOJM/ebcn3LV0u12UWuoQxFVU0Z+nd6JUMV8rOBDHw8M8TOEZmxhYV7pxZhG32g/Q==", "ac6afd2f-1438-46ad-9051-a30281a9bf22" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cigarillos_FilterTypes_FiterId",
                table: "Cigarillos",
                column: "FiterId",
                principalTable: "FilterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarillo_Cigarillos_CigarilloId",
                table: "UserCigarillo",
                column: "CigarilloId",
                principalTable: "Cigarillos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
