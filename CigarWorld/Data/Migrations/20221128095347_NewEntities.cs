using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class NewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90dc5361-4fe5-4e6a-890e-53aafadc6d09", "AQAAAAEAACcQAAAAECdUOG+/Lt7uVU9Lvy26QUrB1fOjh4k+hTD0H5bN18fMeItrXb5AvEQVi2YYtRJ/QA==", "1e0ce813-9003-4e88-b23c-6861be3e3ff9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4830ce43-2f18-4ede-9918-424e959edf90", "AQAAAAEAACcQAAAAEMdBqJGkx0/Rtv0Yw/BiDn4KLrBvuU/JL5GxRiqUWCiXpxEpDcB9APKlfy3Ty3sqsw==", "7a673356-a19b-4fac-ac54-0e7d74da3a91" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
