using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Introduction", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138", 0, "711b9efa-f008-40be-b82b-1e19a5e2838f", "admin@mail.com", false, "I am Admin", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEBzgJrVK7EhJRN0N8YwLlnxLOMutvuTzt2/AM9iNd+cUqy0IOokTIZ5zVTFSZ5+X1Q==", null, false, "Empty", "d413702e-dd0d-4cf1-bbd7-3233c43b1234", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Introduction", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e", 0, "36bcef0e-5555-42d0-b115-c7a5669fcf84", "guest@mail.com", false, "I am guest", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEAH7HcJ+ZhhCwmaN6dtla5r4hmRD66AVxe1ikvXkyFhsyzRNlszFtV34bAH8uzEkuQ==", null, false, "Empty", "037a4b57-e100-492c-9a5e-21d2544418fd", false, "Guest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e");
        }
    }
}
