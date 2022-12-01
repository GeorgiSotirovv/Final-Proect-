using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class AddCommentator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "LighterReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "HumidorReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "CutterReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "CigarReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "CigarPocketCaseReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "CigarilloReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Commenter",
                table: "AshtrayReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "CigarPocketCaseReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.UpdateData(
                table: "CigarReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.UpdateData(
                table: "CigarilloReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.UpdateData(
                table: "CutterReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.UpdateData(
                table: "HumidorReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");

            migrationBuilder.UpdateData(
                table: "LighterReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Commenter",
                value: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "LighterReviews");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "HumidorReviews");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "CutterReviews");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "CigarReviews");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "CigarPocketCaseReviews");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "CigarilloReviews");

            migrationBuilder.DropColumn(
                name: "Commenter",
                table: "AshtrayReviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0148d12d-a64a-400b-b843-65a645649fe9", "AQAAAAEAACcQAAAAEH0oD7PHS+ptr4LX+Yw92CxZgud4UytkoDxBUxe5mfAe8gGlz/5jNIa/JnxdJ/QO/A==", "c22dcfdf-9519-4617-8daf-eeea45e51300" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de4431ed-f8b7-479c-aa1d-4f900753bc82", "AQAAAAEAACcQAAAAEHpwTduGbYdDxgPHSRSz1e7rQoww+1PqWkdW/fX1UD5YTADEMXYIngbFoPb+3FppMw==", "ac575cfa-1ab2-441a-85c3-dcc9a06008bd" });
        }
    }
}
