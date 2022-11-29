using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumidorReview_Lighters_LighterId",
                table: "HumidorReview");

            migrationBuilder.DropIndex(
                name: "IX_HumidorReview_LighterId",
                table: "HumidorReview");

            migrationBuilder.DropColumn(
                name: "LighterId",
                table: "HumidorReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ed2db7e-8ef8-4a32-87f2-aa20f8e2f61e", "AQAAAAEAACcQAAAAEL4XSuR7Oz1E35vIDdIP1MK2CxPV0/Xi5Afau7+Au3JV7yXC9XF+iPwtmzdSs0R+0w==", "f7448d08-38b1-4959-8cc9-be52e80c0ca4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d23bf0b5-0b84-4eac-8541-c5552a5aa886", "AQAAAAEAACcQAAAAEH+XDEPh9QOKpCSafKflKoj8aXacKj4/ERJ40/QpLfUIeelkZcZAF0UmOZPZY4kU9A==", "2730ea3c-a996-4f3c-8789-e34b4edbe587" });

            migrationBuilder.CreateIndex(
                name: "IX_LighterReview_LighterId",
                table: "LighterReview",
                column: "LighterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LighterReview_Lighters_LighterId",
                table: "LighterReview",
                column: "LighterId",
                principalTable: "Lighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LighterReview_Lighters_LighterId",
                table: "LighterReview");

            migrationBuilder.DropIndex(
                name: "IX_LighterReview_LighterId",
                table: "LighterReview");

            migrationBuilder.AddColumn<int>(
                name: "LighterId",
                table: "HumidorReview",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bde5bc3-8a64-4187-bdd0-9392363e7b74", "AQAAAAEAACcQAAAAEGpjZFR3+7hBzByQgO+HlEyvTJHMGQl2bL+g5qjM5Ek1JJRoP+uKCI1PPwRtfeqJ2w==", "a1994d2f-9b3b-4d97-8abc-146b5b6b1be3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39aa3104-89ed-49ed-a7f0-7a73173c1f3a", "AQAAAAEAACcQAAAAEG7YeV/0Qa8pUAcKQuUZ1TfKRm7/t6Q6hJRb4YLbA+iR4NZxhYPKlEbv+gqD/Bx0vg==", "e3a90a2b-a879-4d96-8aca-63b488f49b6e" });

            migrationBuilder.CreateIndex(
                name: "IX_HumidorReview_LighterId",
                table: "HumidorReview",
                column: "LighterId");

            migrationBuilder.AddForeignKey(
                name: "FK_HumidorReview_Lighters_LighterId",
                table: "HumidorReview",
                column: "LighterId",
                principalTable: "Lighters",
                principalColumn: "Id");
        }
    }
}
