using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class ChangeValie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AshtrayReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afc9df9b-a1b9-41ef-98de-166b820382a8", "AQAAAAEAACcQAAAAEMAPz0BH16/zNVA8RIXY20A6e1PO79HgbrgauA9B2bG/3OmdF1RGL0gtN3+CwZY7Qg==", "02aca9b9-273d-4c68-9882-f726a4d16e5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5635a572-5b45-4eb4-bebb-2d476f1f06f6", "AQAAAAEAACcQAAAAEBWtQLuHLdsvOVEO8cqIS3UxMn0Bpo2bRrAUJzLpS2sCz8VU0fa/yIHq2YhAVkpnmw==", "c9fb9464-57d4-4a9a-9b4c-2cd3d3234e8e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AshtrayReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf368f9b-5c5b-49cd-9e8b-6a68294fe532", "AQAAAAEAACcQAAAAECMi3OgbhTPMdZMd0QfcXTh+2cCAMFoekWb9u8TvF31e9hHohlr5rHLXEXVyol8aaQ==", "68e5bd6f-4b03-448e-a2ad-23aa65d483fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15f2079d-bde9-4f3c-ae25-97d30170dcae", "AQAAAAEAACcQAAAAENsG1luQQY+KmNMN1x7gdicH9UWOUjqhMp/Z0xkfnF6TPoQB6etlaAQKvwciH4+PGA==", "877ba333-2c3e-441c-a52f-d45b361ccc8d" });
        }
    }
}
