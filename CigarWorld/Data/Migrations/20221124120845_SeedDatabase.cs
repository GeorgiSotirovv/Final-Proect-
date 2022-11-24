using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1776847-99f3-45e1-9370-2939283a8227", "AQAAAAEAACcQAAAAEGgbpiYz4wdsH48kLzVQpbqQBEKKTkxL95GFhCk9A+mqsjd36zxXcQqhiznfpz+R/w==", "06b158cc-73ad-4803-b5d4-f38c4a6126d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88394fb9-7009-44cf-8685-b46507591872", "AQAAAAEAACcQAAAAEH9pSML8Lot52jgCIz77nflUnv7csjkm5KoE8JZWxH8ANNIq+xnJ/FepFXKMWFjQkw==", "e8ea7694-1d62-4573-92da-e7948fc6421b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68b73da6-db62-4dbe-9acb-9090a6169107", "AQAAAAEAACcQAAAAEPfOVr4LOEqvIEy1LQvawUBpjRhpxtotgPTAEfuQ3tHCCkRSK3LgLLWFs/fmkGci/Q==", "939082e7-dc15-44b9-9fa1-086a169d4142" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cabad5ec-7f81-4378-adc8-7779afecd7d3", "AQAAAAEAACcQAAAAEEtMy68jltDWW2VXuwjBNOVljREgQ3np+6nVlpqBpRPEtPu9wNP8NzmQ6l6Vz+ylpA==", "ed29b066-64c7-4ed0-95a6-d01bfc1d0c24" });
        }
    }
}
