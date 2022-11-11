using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class SeedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "CigarPocketCases");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "CigarPocketCases");

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Cigars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AshtrayType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "For cigars" },
                    { 2, "For Cigarillos" }
                });

            migrationBuilder.InsertData(
                table: "CigarPocketCases",
                columns: new[] { "Id", "Brand", "Capacity", "Comment", "CountryOfManufacturing", "ImageUrl", "MaterialOfManufacture", "UserId" },
                values: new object[] { 1, "Visol", 4, "Expertly crafted with the small cigar smoker in mind, the premium quality Visol Landon Carbon Fiber Mini Cigar Case allows you toss away your ugly cigarillo boxes and carry up to 4- little stogies in style..", "Germany", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRev3HE7yrOrEkefMQhkif-qti8T5pm9262jQ&usqp=CAU", "Оak", null });

            migrationBuilder.InsertData(
                table: "CutterType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Guillotine" },
                    { 2, "V-Cut" },
                    { 3, "Point" }
                });

            migrationBuilder.InsertData(
                table: "FilterType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Standard" },
                    { 2, "Cherry" },
                    { 3, "Mint" },
                    { 4, "Vanila" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Humidors",
                columns: new[] { "Id", "Brand", "Capacity", "Comment", "CountryOfManufacturing", "Height", "ImageUrl", "Length", "MaterialOfManufacture", "UserId", "Weight" },
                values: new object[] { 1, "The Hampton", 50, "This remarkable black lacquer piece features a diamond pattern bonded leather inlay w/ red accent stitching.", "Cuba", 20.0, "https://www.cigarhumidors-online.com/media/catalog/product/cache/1/image/430x295/9df78eab33525d08d6e5fb8d27136e95/h/m/hmptnblu6.jpg", 20.0, "Оak", null, 5.0 });

            migrationBuilder.InsertData(
                table: "Lighters",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "ImageUrl", "UserId" },
                values: new object[] { 1, "Cohiba", "Very nice lighter.", "Cuba", "https://lacasadelhabano-thehague.com/wp-content/uploads/2020/10/briquet-ligne-2-cohiba-016110-01.png", null });

            migrationBuilder.InsertData(
                table: "StrengthType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mild" },
                    { 2, "Medium" },
                    { 3, "Full" }
                });

            migrationBuilder.InsertData(
                table: "Ashtrays",
                columns: new[] { "Id", "AshtrayId", "Brand", "Comment", "CountryOfManufacturing", "ImageUrl", "UserId" },
                values: new object[] { 1, 1, "Lubinski", "Really nice and colorful ashtray.", "China", "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg", null });

            migrationBuilder.InsertData(
                table: "Cigarillos",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "FiterId", "ImageUrl", "UserId" },
                values: new object[] { 1, "Clubmaster", "This Cigarillos have a very nice taste and nice flavor.", "Germany", 1, "https://i.colnect.net/f/4259/015/Clubmaster-Mini.jpg", null });

            migrationBuilder.InsertData(
                table: "Cigars",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "Format", "ImageUrl", "Length", "Ring", "SmokingDuration", "StrengthId", "UserId" },
                values: new object[] { 1, "Cohiba", "This cigar is very unice. The taste, smoke from she and the flavor make the cigar a very special.", "Cuba", "Vitola", "https://kalimancaribe.com/images/thumbnails/650/366/detailed/5/COHIBA_BEHIKE_BHK_52.jpg", 119, 52.0, 90, 1, null });

            migrationBuilder.InsertData(
                table: "Cutters",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "ImageUrl", "TypeId", "UserId" },
                values: new object[] { 1, "Cohiba", "Really nice and sharp cutter.", "Chuba", "https://mikescigars.com/media/catalog/product/cache/0fe343e181b5504db207ac8c729e73b7/h/t/Cohiba-Cutter-each.jpg", 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AshtrayType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ashtrays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CigarPocketCases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cigarillos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cigars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CutterType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CutterType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cutters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FilterType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FilterType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FilterType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FilterType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Humidors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lighters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StrengthType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StrengthType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AshtrayType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CutterType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FilterType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StrengthType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Cigars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "CigarPocketCases",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "CigarPocketCases",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
