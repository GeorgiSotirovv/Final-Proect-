using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class LighterUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc2ed1a-d6e8-414b-957f-cce15f332091", "AQAAAAEAACcQAAAAEB8mkJhyBHobKddJYBL83ruKK3yy3OLCffNfMMr0HkmgyPIoXRt+pEAHWqo0+aSRUg==", "e773f879-5c51-4bb3-911e-324a179362d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "837198d6-986d-4e05-8982-dfbbb065c375", "AQAAAAEAACcQAAAAEGRFgVgZNZRmyZLTxEUu3mR4YVBThPmlgB+eP3ZgMHkba2Wapt9XfsaKkGaenBopbg==", "4f946b08-e021-450c-b804-fe7cf1441dce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
