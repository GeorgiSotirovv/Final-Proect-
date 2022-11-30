using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class Erorrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLighters_AspNetUsers_ApplicationUserId",
                table: "UserLighters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLighters_Lighters_LighterId",
                table: "UserLighters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLighters",
                table: "UserLighters");

            migrationBuilder.RenameTable(
                name: "UserLighters",
                newName: "UserLighter");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighters_LighterId",
                table: "UserLighter",
                newName: "IX_UserLighter_LighterId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighters_ApplicationUserId",
                table: "UserLighter",
                newName: "IX_UserLighter_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserLighter",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLighter",
                table: "UserLighter",
                columns: new[] { "UserId", "LighterId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcaf6a62-3800-4beb-9014-39dd06c10df8", "AQAAAAEAACcQAAAAEHQ2l9q34/Hx5nTKsPIj9Dn4rwkUonZKQ4r2Y/+mB90d2oOVCp3AdtEndt92ASUNJQ==", "278ecc34-f1b1-4753-bf9a-63fa52b2991e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5414ea38-38f7-429d-a393-10d3764266aa", "AQAAAAEAACcQAAAAEC3lgksgROmI7eacg5xj60EBfdwE2VvvYoYevN8aDgtExnj93SM7X88aGY0Xq/TTKQ==", "18fd032f-f067-43ff-9fa5-4c620dbd889f" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLighter_AspNetUsers_ApplicationUserId",
                table: "UserLighter",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLighter_Lighters_LighterId",
                table: "UserLighter",
                column: "LighterId",
                principalTable: "Lighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLighter_AspNetUsers_ApplicationUserId",
                table: "UserLighter");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLighter_Lighters_LighterId",
                table: "UserLighter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLighter",
                table: "UserLighter");

            migrationBuilder.RenameTable(
                name: "UserLighter",
                newName: "UserLighters");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighter_LighterId",
                table: "UserLighters",
                newName: "IX_UserLighters_LighterId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighter_ApplicationUserId",
                table: "UserLighters",
                newName: "IX_UserLighters_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserLighters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLighters",
                table: "UserLighters",
                columns: new[] { "UserId", "LighterId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a8d528b-b1fb-4819-a51f-edc93e008471", "AQAAAAEAACcQAAAAECde03TPm7RCkNpCp32l0IZLu3V1Op6vn3qlbD/vacr+jGNiXbkopUigTjMrD8e1Cg==", "39223118-2f76-4298-8ed6-b9940075ba33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd739cc1-9bd7-44f5-ac20-99da4a4c4a6a", "AQAAAAEAACcQAAAAEIJxg4ixEIAed3UxRRM29gLrZzn4RTKZs4V0ct9wRbt+x1PBFwWEJPmQQL8eJvp5fg==", "c37f9f94-78b1-4558-93a6-6032283f63fb" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLighters_AspNetUsers_ApplicationUserId",
                table: "UserLighters",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLighters_Lighters_LighterId",
                table: "UserLighters",
                column: "LighterId",
                principalTable: "Lighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
