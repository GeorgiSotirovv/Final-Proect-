using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class AllTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ashtrays_AshtrayType_AshtrayId",
                table: "Ashtrays");

            migrationBuilder.DropForeignKey(
                name: "FK_Cigarillos_FilterType_FiterId",
                table: "Cigarillos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cigars_StrengthType_StrengthId",
                table: "Cigars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cutters_CutterType_TypeId",
                table: "Cutters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrengthType",
                table: "StrengthType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilterType",
                table: "FilterType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CutterType",
                table: "CutterType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AshtrayType",
                table: "AshtrayType");

            migrationBuilder.RenameTable(
                name: "StrengthType",
                newName: "StrengthTypes");

            migrationBuilder.RenameTable(
                name: "FilterType",
                newName: "FilterTypes");

            migrationBuilder.RenameTable(
                name: "CutterType",
                newName: "CutterTypes");

            migrationBuilder.RenameTable(
                name: "AshtrayType",
                newName: "AshtrayTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrengthTypes",
                table: "StrengthTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilterTypes",
                table: "FilterTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CutterTypes",
                table: "CutterTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AshtrayTypes",
                table: "AshtrayTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ashtrays_AshtrayTypes_AshtrayId",
                table: "Ashtrays",
                column: "AshtrayId",
                principalTable: "AshtrayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cigarillos_FilterTypes_FiterId",
                table: "Cigarillos",
                column: "FiterId",
                principalTable: "FilterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cigars_StrengthTypes_StrengthId",
                table: "Cigars",
                column: "StrengthId",
                principalTable: "StrengthTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cutters_CutterTypes_TypeId",
                table: "Cutters",
                column: "TypeId",
                principalTable: "CutterTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ashtrays_AshtrayTypes_AshtrayId",
                table: "Ashtrays");

            migrationBuilder.DropForeignKey(
                name: "FK_Cigarillos_FilterTypes_FiterId",
                table: "Cigarillos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cigars_StrengthTypes_StrengthId",
                table: "Cigars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cutters_CutterTypes_TypeId",
                table: "Cutters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrengthTypes",
                table: "StrengthTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilterTypes",
                table: "FilterTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CutterTypes",
                table: "CutterTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AshtrayTypes",
                table: "AshtrayTypes");

            migrationBuilder.RenameTable(
                name: "StrengthTypes",
                newName: "StrengthType");

            migrationBuilder.RenameTable(
                name: "FilterTypes",
                newName: "FilterType");

            migrationBuilder.RenameTable(
                name: "CutterTypes",
                newName: "CutterType");

            migrationBuilder.RenameTable(
                name: "AshtrayTypes",
                newName: "AshtrayType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrengthType",
                table: "StrengthType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilterType",
                table: "FilterType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CutterType",
                table: "CutterType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AshtrayType",
                table: "AshtrayType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ashtrays_AshtrayType_AshtrayId",
                table: "Ashtrays",
                column: "AshtrayId",
                principalTable: "AshtrayType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cigarillos_FilterType_FiterId",
                table: "Cigarillos",
                column: "FiterId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cigars_StrengthType_StrengthId",
                table: "Cigars",
                column: "StrengthId",
                principalTable: "StrengthType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cutters_CutterType_TypeId",
                table: "Cutters",
                column: "TypeId",
                principalTable: "CutterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
