using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AshtrayReview_Ashtrays_AshtrayId",
                table: "AshtrayReview");

            migrationBuilder.DropForeignKey(
                name: "FK_CigarPocketCaseReview_CigarPocketCases_CigarPocketCaseId",
                table: "CigarPocketCaseReview");

            migrationBuilder.DropForeignKey(
                name: "FK_CigarReview_Cigars_CigarId",
                table: "CigarReview");

            migrationBuilder.DropForeignKey(
                name: "FK_CutterReview_Cutters_CutterId",
                table: "CutterReview");

            migrationBuilder.DropForeignKey(
                name: "FK_HumidorReview_Humidors_HumidorId",
                table: "HumidorReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LighterReview_Lighters_LighterId",
                table: "LighterReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LighterReview",
                table: "LighterReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HumidorReview",
                table: "HumidorReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CutterReview",
                table: "CutterReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CigarReview",
                table: "CigarReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CigarPocketCaseReview",
                table: "CigarPocketCaseReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AshtrayReview",
                table: "AshtrayReview");

            migrationBuilder.RenameTable(
                name: "LighterReview",
                newName: "LighterReviews");

            migrationBuilder.RenameTable(
                name: "HumidorReview",
                newName: "HumidorReviews");

            migrationBuilder.RenameTable(
                name: "CutterReview",
                newName: "CutterReviews");

            migrationBuilder.RenameTable(
                name: "CigarReview",
                newName: "CigarReviews");

            migrationBuilder.RenameTable(
                name: "CigarPocketCaseReview",
                newName: "CigarPocketCaseReviews");

            migrationBuilder.RenameTable(
                name: "AshtrayReview",
                newName: "AshtrayReviews");

            migrationBuilder.RenameIndex(
                name: "IX_LighterReview_LighterId",
                table: "LighterReviews",
                newName: "IX_LighterReviews_LighterId");

            migrationBuilder.RenameIndex(
                name: "IX_HumidorReview_HumidorId",
                table: "HumidorReviews",
                newName: "IX_HumidorReviews_HumidorId");

            migrationBuilder.RenameIndex(
                name: "IX_CutterReview_CutterId",
                table: "CutterReviews",
                newName: "IX_CutterReviews_CutterId");

            migrationBuilder.RenameIndex(
                name: "IX_CigarReview_CigarId",
                table: "CigarReviews",
                newName: "IX_CigarReviews_CigarId");

            migrationBuilder.RenameIndex(
                name: "IX_CigarPocketCaseReview_CigarPocketCaseId",
                table: "CigarPocketCaseReviews",
                newName: "IX_CigarPocketCaseReviews_CigarPocketCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_AshtrayReview_AshtrayId",
                table: "AshtrayReviews",
                newName: "IX_AshtrayReviews_AshtrayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LighterReviews",
                table: "LighterReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HumidorReviews",
                table: "HumidorReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CutterReviews",
                table: "CutterReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CigarReviews",
                table: "CigarReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CigarPocketCaseReviews",
                table: "CigarPocketCaseReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AshtrayReviews",
                table: "AshtrayReviews",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AshtrayReviews_Ashtrays_AshtrayId",
                table: "AshtrayReviews",
                column: "AshtrayId",
                principalTable: "Ashtrays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CigarPocketCaseReviews_CigarPocketCases_CigarPocketCaseId",
                table: "CigarPocketCaseReviews",
                column: "CigarPocketCaseId",
                principalTable: "CigarPocketCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CigarReviews_Cigars_CigarId",
                table: "CigarReviews",
                column: "CigarId",
                principalTable: "Cigars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CutterReviews_Cutters_CutterId",
                table: "CutterReviews",
                column: "CutterId",
                principalTable: "Cutters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HumidorReviews_Humidors_HumidorId",
                table: "HumidorReviews",
                column: "HumidorId",
                principalTable: "Humidors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LighterReviews_Lighters_LighterId",
                table: "LighterReviews",
                column: "LighterId",
                principalTable: "Lighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AshtrayReviews_Ashtrays_AshtrayId",
                table: "AshtrayReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CigarPocketCaseReviews_CigarPocketCases_CigarPocketCaseId",
                table: "CigarPocketCaseReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CigarReviews_Cigars_CigarId",
                table: "CigarReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CutterReviews_Cutters_CutterId",
                table: "CutterReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_HumidorReviews_Humidors_HumidorId",
                table: "HumidorReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_LighterReviews_Lighters_LighterId",
                table: "LighterReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LighterReviews",
                table: "LighterReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HumidorReviews",
                table: "HumidorReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CutterReviews",
                table: "CutterReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CigarReviews",
                table: "CigarReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CigarPocketCaseReviews",
                table: "CigarPocketCaseReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AshtrayReviews",
                table: "AshtrayReviews");

            migrationBuilder.RenameTable(
                name: "LighterReviews",
                newName: "LighterReview");

            migrationBuilder.RenameTable(
                name: "HumidorReviews",
                newName: "HumidorReview");

            migrationBuilder.RenameTable(
                name: "CutterReviews",
                newName: "CutterReview");

            migrationBuilder.RenameTable(
                name: "CigarReviews",
                newName: "CigarReview");

            migrationBuilder.RenameTable(
                name: "CigarPocketCaseReviews",
                newName: "CigarPocketCaseReview");

            migrationBuilder.RenameTable(
                name: "AshtrayReviews",
                newName: "AshtrayReview");

            migrationBuilder.RenameIndex(
                name: "IX_LighterReviews_LighterId",
                table: "LighterReview",
                newName: "IX_LighterReview_LighterId");

            migrationBuilder.RenameIndex(
                name: "IX_HumidorReviews_HumidorId",
                table: "HumidorReview",
                newName: "IX_HumidorReview_HumidorId");

            migrationBuilder.RenameIndex(
                name: "IX_CutterReviews_CutterId",
                table: "CutterReview",
                newName: "IX_CutterReview_CutterId");

            migrationBuilder.RenameIndex(
                name: "IX_CigarReviews_CigarId",
                table: "CigarReview",
                newName: "IX_CigarReview_CigarId");

            migrationBuilder.RenameIndex(
                name: "IX_CigarPocketCaseReviews_CigarPocketCaseId",
                table: "CigarPocketCaseReview",
                newName: "IX_CigarPocketCaseReview_CigarPocketCaseId");

            migrationBuilder.RenameIndex(
                name: "IX_AshtrayReviews_AshtrayId",
                table: "AshtrayReview",
                newName: "IX_AshtrayReview_AshtrayId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LighterReview",
                table: "LighterReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HumidorReview",
                table: "HumidorReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CutterReview",
                table: "CutterReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CigarReview",
                table: "CigarReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CigarPocketCaseReview",
                table: "CigarPocketCaseReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AshtrayReview",
                table: "AshtrayReview",
                column: "Id");

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
                name: "FK_AshtrayReview_Ashtrays_AshtrayId",
                table: "AshtrayReview",
                column: "AshtrayId",
                principalTable: "Ashtrays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CigarPocketCaseReview_CigarPocketCases_CigarPocketCaseId",
                table: "CigarPocketCaseReview",
                column: "CigarPocketCaseId",
                principalTable: "CigarPocketCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CigarReview_Cigars_CigarId",
                table: "CigarReview",
                column: "CigarId",
                principalTable: "Cigars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CutterReview_Cutters_CutterId",
                table: "CutterReview",
                column: "CutterId",
                principalTable: "Cutters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HumidorReview_Humidors_HumidorId",
                table: "HumidorReview",
                column: "HumidorId",
                principalTable: "Humidors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LighterReview_Lighters_LighterId",
                table: "LighterReview",
                column: "LighterId",
                principalTable: "Lighters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
