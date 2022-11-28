using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16310d5c-f8e7-4d4e-8a76-ed61a9c3f7ad", "AQAAAAEAACcQAAAAEBUL5Xfqo0o+KKQ7/uXOfedsPL6y6rNqZdxEJJmxtw315yR1LFykg3AJ3DteIhR4ww==", "39516a1c-42ce-48c1-8f6f-7b160d85ca14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f84552e6-01d7-4a96-855d-432bba31341e", "AQAAAAEAACcQAAAAEF77VF5Ms5CcG/aGyQOqgG404yhs209yUvpIXkr5K8y4BPatVpWSikE6WzhcR6fo8g==", "0215a267-5413-47a6-b838-52e42101ae68" });

            migrationBuilder.CreateIndex(
                name: "IX_AshtrayReview_AshtrayId",
                table: "AshtrayReview",
                column: "AshtrayId");

            migrationBuilder.AddForeignKey(
                name: "FK_AshtrayReview_Ashtrays_AshtrayId",
                table: "AshtrayReview",
                column: "AshtrayId",
                principalTable: "Ashtrays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AshtrayReview_Ashtrays_AshtrayId",
                table: "AshtrayReview");

            migrationBuilder.DropIndex(
                name: "IX_AshtrayReview_AshtrayId",
                table: "AshtrayReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d8566cc-a3f7-4bfd-b472-fc97a99e048e", "AQAAAAEAACcQAAAAEMczLPbwoYHJ+58PrrFWp3Depw71Yebd+ax4MLaK1ZkdIoM2qRNnn5judDrlWDq/6A==", "cceb39e6-ac5b-402e-b732-ca9dd2247645" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5c82a07-dcb1-4b3d-8d64-29c0f23056ae", "AQAAAAEAACcQAAAAEKPtk//lRCSeG1D9ufn0SXIPoVx74HENVKxE/ksSWuud4sXCo9vgIkb1VEt9lqXIGQ==", "fd30d8fe-a08e-47e4-9ccf-afe8b23b0215" });
        }
    }
}
