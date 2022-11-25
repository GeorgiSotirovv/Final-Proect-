using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class Error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b5dd532-65a3-47ac-b404-a80b3d3a6f15", "AQAAAAEAACcQAAAAEPJCYBkh/GHs594lDagY9mlZmTF0HdTCCRchF22++jNEZ0z/JWf/nFHUpXtz4Hu6HQ==", "d9853640-def5-440e-9f77-558a263639f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8bd1ba6-6914-4e81-92e6-40a3b0e4303b", "AQAAAAEAACcQAAAAEJx+XQfN+H0IKOXZR2SJaWcfZ5ZshLiXHGJRfFsMS8ZJOQ6MNKovBmBotF9wh2OH6A==", "0ce2ad4f-2084-4ab9-bccd-c76b35bbd633" });
        }
    }
}
