using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Migrations
{
    public partial class UserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAshtray_Ashtrays_AshtrayId",
                table: "UserAshtray");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAshtray_AspNetUsers_ApplicationUserId",
                table: "UserAshtray");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigar_AspNetUsers_ApplicationUserId",
                table: "UserCigar");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigar_Cigars_CigarId",
                table: "UserCigar");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarillo_AspNetUsers_ApplicationUserId",
                table: "UserCigarillo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarillo_Cigarillo_CigarilloId",
                table: "UserCigarillo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarPocketCase_AspNetUsers_ApplicationUserId",
                table: "UserCigarPocketCase");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarPocketCase_CigarPocketCases_CigarPocketCaseId",
                table: "UserCigarPocketCase");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCutter_AspNetUsers_ApplicationUserId",
                table: "UserCutter");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCutter_Cutters_CutterId",
                table: "UserCutter");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHumidor_AspNetUsers_ApplicationUserId",
                table: "UserHumidor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHumidor_Humidors_HumidorId",
                table: "UserHumidor");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLighter_AspNetUsers_ApplicationUserId",
                table: "UserLighter");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLighter_Lighters_LighterId",
                table: "UserLighter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLighter",
                table: "UserLighter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHumidor",
                table: "UserHumidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCutter",
                table: "UserCutter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCigarPocketCase",
                table: "UserCigarPocketCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCigarillo",
                table: "UserCigarillo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCigar",
                table: "UserCigar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAshtray",
                table: "UserAshtray");

            migrationBuilder.RenameTable(
                name: "UserLighter",
                newName: "UserLighters");

            migrationBuilder.RenameTable(
                name: "UserHumidor",
                newName: "UserHumidors");

            migrationBuilder.RenameTable(
                name: "UserCutter",
                newName: "UserCutters");

            migrationBuilder.RenameTable(
                name: "UserCigarPocketCase",
                newName: "UserCigarPocketCases");

            migrationBuilder.RenameTable(
                name: "UserCigarillo",
                newName: "UserCigarillos");

            migrationBuilder.RenameTable(
                name: "UserCigar",
                newName: "UserCigars");

            migrationBuilder.RenameTable(
                name: "UserAshtray",
                newName: "UserAshtrays");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighter_LighterId",
                table: "UserLighters",
                newName: "IX_UserLighters_LighterId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighter_ApplicationUserId",
                table: "UserLighters",
                newName: "IX_UserLighters_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHumidor_HumidorId",
                table: "UserHumidors",
                newName: "IX_UserHumidors_HumidorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHumidor_ApplicationUserId",
                table: "UserHumidors",
                newName: "IX_UserHumidors_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCutter_CutterId",
                table: "UserCutters",
                newName: "IX_UserCutters_CutterId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCutter_ApplicationUserId",
                table: "UserCutters",
                newName: "IX_UserCutters_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarPocketCase_CigarPocketCaseId",
                table: "UserCigarPocketCases",
                newName: "IX_UserCigarPocketCases_CigarPocketCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarPocketCase_ApplicationUserId",
                table: "UserCigarPocketCases",
                newName: "IX_UserCigarPocketCases_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarillo_CigarilloId",
                table: "UserCigarillos",
                newName: "IX_UserCigarillos_CigarilloId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarillo_ApplicationUserId",
                table: "UserCigarillos",
                newName: "IX_UserCigarillos_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigar_CigarId",
                table: "UserCigars",
                newName: "IX_UserCigars_CigarId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigar_ApplicationUserId",
                table: "UserCigars",
                newName: "IX_UserCigars_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAshtray_AshtrayId",
                table: "UserAshtrays",
                newName: "IX_UserAshtrays_AshtrayId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAshtray_ApplicationUserId",
                table: "UserAshtrays",
                newName: "IX_UserAshtrays_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserLighters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserHumidors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCutters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCigarPocketCases",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCigarillos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCigars",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserAshtrays",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLighters",
                table: "UserLighters",
                columns: new[] { "UserId", "LighterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHumidors",
                table: "UserHumidors",
                columns: new[] { "UserId", "HumidorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCutters",
                table: "UserCutters",
                columns: new[] { "UserId", "CutterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCigarPocketCases",
                table: "UserCigarPocketCases",
                columns: new[] { "UserId", "CigarPocketCaseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCigarillos",
                table: "UserCigarillos",
                columns: new[] { "UserId", "CigarilloId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCigars",
                table: "UserCigars",
                columns: new[] { "UserId", "CigarId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAshtrays",
                table: "UserAshtrays",
                columns: new[] { "UserId", "AshtrayId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cecaebd-568b-4ae0-a1c8-8da3c98a3d9c", "AQAAAAEAACcQAAAAEO4IQ1lu4KrjQkxMvqJ1Qd4ZZA+RLVNoDo9Pni2/BJYXLlStZMaicOYa2EUgv4wCnA==", "f5038cef-646b-43ac-ae76-0706289c504d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f188bf2e-7235-4520-8203-b8ccc42229d1", "AQAAAAEAACcQAAAAEBnjJX3BuxkKj8wZv+GhOf4GMtKKUrod4QCcKyJNtBD11s5PrnWcCgvngKwAK+06Aw==", "82e17570-af06-4e8d-a07b-6ed0fe07529c" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAshtrays_Ashtrays_AshtrayId",
                table: "UserAshtrays",
                column: "AshtrayId",
                principalTable: "Ashtrays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAshtrays_AspNetUsers_ApplicationUserId",
                table: "UserAshtrays",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarillos_AspNetUsers_ApplicationUserId",
                table: "UserCigarillos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarillos_Cigarillo_CigarilloId",
                table: "UserCigarillos",
                column: "CigarilloId",
                principalTable: "Cigarillo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarPocketCases_AspNetUsers_ApplicationUserId",
                table: "UserCigarPocketCases",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarPocketCases_CigarPocketCases_CigarPocketCaseId",
                table: "UserCigarPocketCases",
                column: "CigarPocketCaseId",
                principalTable: "CigarPocketCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigars_AspNetUsers_ApplicationUserId",
                table: "UserCigars",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigars_Cigars_CigarId",
                table: "UserCigars",
                column: "CigarId",
                principalTable: "Cigars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCutters_AspNetUsers_ApplicationUserId",
                table: "UserCutters",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCutters_Cutters_CutterId",
                table: "UserCutters",
                column: "CutterId",
                principalTable: "Cutters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHumidors_AspNetUsers_ApplicationUserId",
                table: "UserHumidors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHumidors_Humidors_HumidorId",
                table: "UserHumidors",
                column: "HumidorId",
                principalTable: "Humidors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAshtrays_Ashtrays_AshtrayId",
                table: "UserAshtrays");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAshtrays_AspNetUsers_ApplicationUserId",
                table: "UserAshtrays");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarillos_AspNetUsers_ApplicationUserId",
                table: "UserCigarillos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarillos_Cigarillo_CigarilloId",
                table: "UserCigarillos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarPocketCases_AspNetUsers_ApplicationUserId",
                table: "UserCigarPocketCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigarPocketCases_CigarPocketCases_CigarPocketCaseId",
                table: "UserCigarPocketCases");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigars_AspNetUsers_ApplicationUserId",
                table: "UserCigars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCigars_Cigars_CigarId",
                table: "UserCigars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCutters_AspNetUsers_ApplicationUserId",
                table: "UserCutters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCutters_Cutters_CutterId",
                table: "UserCutters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHumidors_AspNetUsers_ApplicationUserId",
                table: "UserHumidors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHumidors_Humidors_HumidorId",
                table: "UserHumidors");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLighters_AspNetUsers_ApplicationUserId",
                table: "UserLighters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLighters_Lighters_LighterId",
                table: "UserLighters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLighters",
                table: "UserLighters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHumidors",
                table: "UserHumidors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCutters",
                table: "UserCutters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCigars",
                table: "UserCigars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCigarPocketCases",
                table: "UserCigarPocketCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCigarillos",
                table: "UserCigarillos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAshtrays",
                table: "UserAshtrays");

            migrationBuilder.RenameTable(
                name: "UserLighters",
                newName: "UserLighter");

            migrationBuilder.RenameTable(
                name: "UserHumidors",
                newName: "UserHumidor");

            migrationBuilder.RenameTable(
                name: "UserCutters",
                newName: "UserCutter");

            migrationBuilder.RenameTable(
                name: "UserCigars",
                newName: "UserCigar");

            migrationBuilder.RenameTable(
                name: "UserCigarPocketCases",
                newName: "UserCigarPocketCase");

            migrationBuilder.RenameTable(
                name: "UserCigarillos",
                newName: "UserCigarillo");

            migrationBuilder.RenameTable(
                name: "UserAshtrays",
                newName: "UserAshtray");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighters_LighterId",
                table: "UserLighter",
                newName: "IX_UserLighter_LighterId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLighters_ApplicationUserId",
                table: "UserLighter",
                newName: "IX_UserLighter_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHumidors_HumidorId",
                table: "UserHumidor",
                newName: "IX_UserHumidor_HumidorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHumidors_ApplicationUserId",
                table: "UserHumidor",
                newName: "IX_UserHumidor_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCutters_CutterId",
                table: "UserCutter",
                newName: "IX_UserCutter_CutterId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCutters_ApplicationUserId",
                table: "UserCutter",
                newName: "IX_UserCutter_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigars_CigarId",
                table: "UserCigar",
                newName: "IX_UserCigar_CigarId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigars_ApplicationUserId",
                table: "UserCigar",
                newName: "IX_UserCigar_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarPocketCases_CigarPocketCaseId",
                table: "UserCigarPocketCase",
                newName: "IX_UserCigarPocketCase_CigarPocketCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarPocketCases_ApplicationUserId",
                table: "UserCigarPocketCase",
                newName: "IX_UserCigarPocketCase_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarillos_CigarilloId",
                table: "UserCigarillo",
                newName: "IX_UserCigarillo_CigarilloId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCigarillos_ApplicationUserId",
                table: "UserCigarillo",
                newName: "IX_UserCigarillo_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAshtrays_AshtrayId",
                table: "UserAshtray",
                newName: "IX_UserAshtray_AshtrayId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAshtrays_ApplicationUserId",
                table: "UserAshtray",
                newName: "IX_UserAshtray_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserLighter",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserHumidor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCutter",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCigar",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCigarPocketCase",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserCigarillo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserAshtray",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHumidor",
                table: "UserHumidor",
                columns: new[] { "UserId", "HumidorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCutter",
                table: "UserCutter",
                columns: new[] { "UserId", "CutterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCigar",
                table: "UserCigar",
                columns: new[] { "UserId", "CigarId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCigarPocketCase",
                table: "UserCigarPocketCase",
                columns: new[] { "UserId", "CigarPocketCaseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCigarillo",
                table: "UserCigarillo",
                columns: new[] { "UserId", "CigarilloId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAshtray",
                table: "UserAshtray",
                columns: new[] { "UserId", "AshtrayId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3bc24ee-2b67-4c8b-982e-1582c554977c", "AQAAAAEAACcQAAAAEGIkNbFALADIroXTf/avVJrwSu6Z0SkacKu6fGOpMmKkl6qARwjt2pXQe27WQ25bYw==", "62208ba3-932a-4e0c-a481-1059487b8338" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91cedbee-e459-477c-a72f-97b19b3e6774", "AQAAAAEAACcQAAAAEKbTYT9ZkNnUgUCBdW0YMFHuUH75eSSQwUq5BWSycFHpW3Vxc7GBWbg+P5hvFSKvIw==", "a6e39e14-d998-46bb-8dcb-ae3c3310c3a8" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAshtray_Ashtrays_AshtrayId",
                table: "UserAshtray",
                column: "AshtrayId",
                principalTable: "Ashtrays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAshtray_AspNetUsers_ApplicationUserId",
                table: "UserAshtray",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigar_AspNetUsers_ApplicationUserId",
                table: "UserCigar",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigar_Cigars_CigarId",
                table: "UserCigar",
                column: "CigarId",
                principalTable: "Cigars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarillo_AspNetUsers_ApplicationUserId",
                table: "UserCigarillo",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarillo_Cigarillo_CigarilloId",
                table: "UserCigarillo",
                column: "CigarilloId",
                principalTable: "Cigarillo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarPocketCase_AspNetUsers_ApplicationUserId",
                table: "UserCigarPocketCase",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCigarPocketCase_CigarPocketCases_CigarPocketCaseId",
                table: "UserCigarPocketCase",
                column: "CigarPocketCaseId",
                principalTable: "CigarPocketCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCutter_AspNetUsers_ApplicationUserId",
                table: "UserCutter",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCutter_Cutters_CutterId",
                table: "UserCutter",
                column: "CutterId",
                principalTable: "Cutters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHumidor_AspNetUsers_ApplicationUserId",
                table: "UserHumidor",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHumidor_Humidors_HumidorId",
                table: "UserHumidor",
                column: "HumidorId",
                principalTable: "Humidors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
