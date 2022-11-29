using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class SeedReviewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AshtrayReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AshtrayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AshtrayReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarilloReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CigarilloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarilloReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarPocketCaseReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CigarPocketCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarPocketCaseReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CigarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CutterReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CutterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CutterReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HumidorReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HumidorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumidorReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LighterReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LighterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LighterReview", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AshtrayReview",
                columns: new[] { "Id", "AshtrayId", "Review" },
                values: new object[] { 1, 1, "Very nice and colorfull ashtray." });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e02c17f3-9469-4f86-bc33-5c09dbcb8790", "AQAAAAEAACcQAAAAEF9o6tch3YoNUSXmVAdKlumWa+gQARBeacNsrKbl3cHPA/GSpd7PvpPlE35FEAL4lg==", "eac0ef9d-10bc-4869-8ea1-4da36f5beb66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67a80450-10cc-49d7-9245-b31cca08adaf", "AQAAAAEAACcQAAAAENX9rtIl7HF/4rX+mYd9no/HJ2jPrctVT6T1foPDravvlaBu7OLgl0WmNLz8UzaANg==", "d74ce4a7-721e-45ab-8f5d-8f5ef0be46fb" });

            migrationBuilder.InsertData(
                table: "CigarPocketCaseReview",
                columns: new[] { "Id", "CigarPocketCaseId", "Review" },
                values: new object[] { 1, 1, " The Crafting is very good." });

            migrationBuilder.InsertData(
                table: "CigarReview",
                columns: new[] { "Id", "CigarId", "Review" },
                values: new object[] { 1, 1, "This cigar is perfect for evenings." });

            migrationBuilder.InsertData(
                table: "CigarilloReviews",
                columns: new[] { "Id", "CigarilloId", "Review" },
                values: new object[] { 1, 1, "This Cigarillos are very good." });

            migrationBuilder.InsertData(
                table: "CutterReview",
                columns: new[] { "Id", "CutterId", "Review" },
                values: new object[] { 1, 1, "This is very nice and sharp cutter." });

            migrationBuilder.InsertData(
                table: "HumidorReview",
                columns: new[] { "Id", "HumidorId", "Review" },
                values: new object[] { 1, 1, "Very solid humidor with good crafting." });

            migrationBuilder.InsertData(
                table: "LighterReview",
                columns: new[] { "Id", "LighterId", "Review" },
                values: new object[] { 1, 1, "This lighter is different from the rest because the flame is more stronger than the ordinary lighter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AshtrayReview");

            migrationBuilder.DropTable(
                name: "CigarilloReviews");

            migrationBuilder.DropTable(
                name: "CigarPocketCaseReview");

            migrationBuilder.DropTable(
                name: "CigarReview");

            migrationBuilder.DropTable(
                name: "CutterReview");

            migrationBuilder.DropTable(
                name: "HumidorReview");

            migrationBuilder.DropTable(
                name: "LighterReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d44e4e50-7a4e-47f4-b02d-407eb50bc502", "AQAAAAEAACcQAAAAEONpaXeKi8u6LDPKIJlSH1dpFvHBcouJ2mBGiEf/3hVovDgiizMfDoPYqompjr3ySw==", "6af87779-c19b-46ca-88d9-76987b787187" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e0f7769-3b79-4d48-9124-f6f7b6190385", "AQAAAAEAACcQAAAAEGRSH23rOVhlzBhpdPW1owaRBi5cvYKj8RnWkuRCzDDn+wxUVw1fnp89tcrNy68Ywg==", "5f557079-67ea-4a2e-bebf-1c1b887bd963" });
        }
    }
}
