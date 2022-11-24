﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CigarWorld.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AshtrayTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AshtrayTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CigarPocketCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialOfManufacture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CigarPocketCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CutterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CutterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Humidors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialOfManufacture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lighters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrengthTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrengthTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ashtrays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AshtrayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ashtrays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ashtrays_AshtrayTypes_AshtrayId",
                        column: x => x.AshtrayId,
                        principalTable: "AshtrayTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCigarPocketCase",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CigarPocketCaseId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCigarPocketCase", x => new { x.UserId, x.CigarPocketCaseId });
                    table.ForeignKey(
                        name: "FK_UserCigarPocketCase_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCigarPocketCase_CigarPocketCases_CigarPocketCaseId",
                        column: x => x.CigarPocketCaseId,
                        principalTable: "CigarPocketCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cutters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cutters_CutterTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CutterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cigarillos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cigarillos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cigarillos_FilterTypes_FiterId",
                        column: x => x.FiterId,
                        principalTable: "FilterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHumidor",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HumidorId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHumidor", x => new { x.UserId, x.HumidorId });
                    table.ForeignKey(
                        name: "FK_UserHumidor_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHumidor_Humidors_HumidorId",
                        column: x => x.HumidorId,
                        principalTable: "Humidors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLighter",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LighterId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLighter", x => new { x.UserId, x.LighterId });
                    table.ForeignKey(
                        name: "FK_UserLighter_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLighter_Lighters_LighterId",
                        column: x => x.LighterId,
                        principalTable: "Lighters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cigars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Format = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Ring = table.Column<double>(type: "float", nullable: false),
                    SmokingDuration = table.Column<int>(type: "int", maxLength: 300, nullable: false),
                    CountryOfManufacturing = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrengthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cigars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cigars_StrengthTypes_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "StrengthTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAshtray",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AshtrayId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAshtray", x => new { x.UserId, x.AshtrayId });
                    table.ForeignKey(
                        name: "FK_UserAshtray_Ashtrays_AshtrayId",
                        column: x => x.AshtrayId,
                        principalTable: "Ashtrays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAshtray_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCutter",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CutterId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCutter", x => new { x.UserId, x.CutterId });
                    table.ForeignKey(
                        name: "FK_UserCutter_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCutter_Cutters_CutterId",
                        column: x => x.CutterId,
                        principalTable: "Cutters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCigarillo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CigarilloId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCigarillo", x => new { x.UserId, x.CigarilloId });
                    table.ForeignKey(
                        name: "FK_UserCigarillo_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCigarillo_Cigarillos_CigarilloId",
                        column: x => x.CigarilloId,
                        principalTable: "Cigarillos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCigar",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CigarId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCigar", x => new { x.UserId, x.CigarId });
                    table.ForeignKey(
                        name: "FK_UserCigar_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCigar_Cigars_CigarId",
                        column: x => x.CigarId,
                        principalTable: "Cigars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AshtrayTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "For cigars" },
                    { 2, "For Cigarillos" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Introduction", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a67ddfe2-5d26-45c2-bbe9-7fb8f4ef5138", 0, "ff9bacf0-4376-42ae-845d-ad5e4e2d8436", "admin@mail.com", false, "I am Admin", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEJn73s4DOUx1kUbYj0EtiXuScakH0mJG8VbYOp+GoDBFZTvyOXg7XvFjMpQNJA6JLw==", null, false, "Empty", "4eef386c-6e82-4c73-ae28-7ebd69d2b2f9", false, "Admin" },
                    { "ac1f591e-d6b3-f4ef-bc1f-d6b3ac1f591e", 0, "3d15cc1d-f376-4f4d-b98c-9838b7b811ce", "guest@mail.com", false, "I am guest", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEKrvkihy41DkYU3X8KiIGIzQmExk+8PzmhKgtQWvFr0hMa3SaH95gr4yhHVXivmyKw==", null, false, "Empty", "70a593bb-2ae8-4ff2-931d-ff9f1c2f6e6b", false, "Guest" }
                });

            migrationBuilder.InsertData(
                table: "CigarPocketCases",
                columns: new[] { "Id", "Brand", "Capacity", "Comment", "CountryOfManufacturing", "ImageUrl", "MaterialOfManufacture" },
                values: new object[] { 1, "Visol", 4, "Expertly crafted with the small cigar smoker in mind, the premium quality Visol Landon Carbon Fiber Mini Cigar Case allows you toss away your ugly cigarillo boxes and carry up to 4- little stogies in style..", "Germany", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRev3HE7yrOrEkefMQhkif-qti8T5pm9262jQ&usqp=CAU", "Оak" });

            migrationBuilder.InsertData(
                table: "CutterTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Guillotine" },
                    { 2, "V-Cut" },
                    { 3, "Point" }
                });

            migrationBuilder.InsertData(
                table: "FilterTypes",
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
                columns: new[] { "Id", "Brand", "Capacity", "Comment", "CountryOfManufacturing", "Height", "ImageUrl", "Length", "MaterialOfManufacture", "Weight" },
                values: new object[] { 1, "The Hampton", 50, "This remarkable black lacquer piece features a diamond pattern bonded leather inlay w/ red accent stitching.", "Cuba", 20.0, "https://www.cigarhumidors-online.com/media/catalog/product/cache/1/image/430x295/9df78eab33525d08d6e5fb8d27136e95/h/m/hmptnblu6.jpg", 20.0, "Оak", 5.0 });

            migrationBuilder.InsertData(
                table: "Lighters",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "ImageUrl" },
                values: new object[] { 1, "Cohiba", "Very nice lighter.", "Cuba", "https://lacasadelhabano-thehague.com/wp-content/uploads/2020/10/briquet-ligne-2-cohiba-016110-01.png" });

            migrationBuilder.InsertData(
                table: "StrengthTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mild" },
                    { 2, "Medium" },
                    { 3, "Full" }
                });

            migrationBuilder.InsertData(
                table: "Ashtrays",
                columns: new[] { "Id", "AshtrayId", "Brand", "Comment", "CountryOfManufacturing", "ImageUrl" },
                values: new object[] { 1, 1, "Lubinski", "Really nice and colorful ashtray.", "China", "https://m.media-amazon.com/images/I/51xDDJtDbBL._AC_SY1000_.jpg" });

            migrationBuilder.InsertData(
                table: "Cigarillos",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "FiterId", "ImageUrl" },
                values: new object[] { 1, "Clubmaster", "This Cigarillos have a very nice taste and nice flavor.", "Germany", 1, "https://i.colnect.net/f/4259/015/Clubmaster-Mini.jpg" });

            migrationBuilder.InsertData(
                table: "Cigars",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "Format", "ImageUrl", "Length", "Ring", "SmokingDuration", "StrengthId" },
                values: new object[] { 1, "Cohiba", "This cigar is very unice. The taste, smoke from she and the flavor make the cigar a very special.", "Cuba", "Vitola", "https://kalimancaribe.com/images/thumbnails/650/366/detailed/5/COHIBA_BEHIKE_BHK_52.jpg", 119, 52.0, 90, 1 });

            migrationBuilder.InsertData(
                table: "Cutters",
                columns: new[] { "Id", "Brand", "Comment", "CountryOfManufacturing", "ImageUrl", "TypeId" },
                values: new object[] { 1, "Cohiba", "Really nice and sharp cutter.", "Chuba", "https://mikescigars.com/media/catalog/product/cache/0fe343e181b5504db207ac8c729e73b7/h/t/Cohiba-Cutter-each.jpg", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Ashtrays_AshtrayId",
                table: "Ashtrays",
                column: "AshtrayId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cigarillos_FiterId",
                table: "Cigarillos",
                column: "FiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Cigars_StrengthId",
                table: "Cigars",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_Cutters_TypeId",
                table: "Cutters",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAshtray_ApplicationUserId",
                table: "UserAshtray",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAshtray_AshtrayId",
                table: "UserAshtray",
                column: "AshtrayId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCigar_ApplicationUserId",
                table: "UserCigar",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCigar_CigarId",
                table: "UserCigar",
                column: "CigarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCigarillo_ApplicationUserId",
                table: "UserCigarillo",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCigarillo_CigarilloId",
                table: "UserCigarillo",
                column: "CigarilloId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCigarPocketCase_ApplicationUserId",
                table: "UserCigarPocketCase",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCigarPocketCase_CigarPocketCaseId",
                table: "UserCigarPocketCase",
                column: "CigarPocketCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCutter_ApplicationUserId",
                table: "UserCutter",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCutter_CutterId",
                table: "UserCutter",
                column: "CutterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHumidor_ApplicationUserId",
                table: "UserHumidor",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHumidor_HumidorId",
                table: "UserHumidor",
                column: "HumidorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLighter_ApplicationUserId",
                table: "UserLighter",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLighter_LighterId",
                table: "UserLighter",
                column: "LighterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserAshtray");

            migrationBuilder.DropTable(
                name: "UserCigar");

            migrationBuilder.DropTable(
                name: "UserCigarillo");

            migrationBuilder.DropTable(
                name: "UserCigarPocketCase");

            migrationBuilder.DropTable(
                name: "UserCutter");

            migrationBuilder.DropTable(
                name: "UserHumidor");

            migrationBuilder.DropTable(
                name: "UserLighter");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ashtrays");

            migrationBuilder.DropTable(
                name: "Cigars");

            migrationBuilder.DropTable(
                name: "Cigarillos");

            migrationBuilder.DropTable(
                name: "CigarPocketCases");

            migrationBuilder.DropTable(
                name: "Cutters");

            migrationBuilder.DropTable(
                name: "Humidors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lighters");

            migrationBuilder.DropTable(
                name: "AshtrayTypes");

            migrationBuilder.DropTable(
                name: "StrengthTypes");

            migrationBuilder.DropTable(
                name: "FilterTypes");

            migrationBuilder.DropTable(
                name: "CutterTypes");
        }
    }
}
