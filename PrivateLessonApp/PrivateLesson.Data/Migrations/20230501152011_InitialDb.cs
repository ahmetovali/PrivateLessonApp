using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrivateLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Graduation = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherBranches", x => new { x.TeacherId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", null, "Öğrenciler", "Ogrenci", "OGRENCI" },
                    { "6b588377-b6bc-440d-813a-771eeaa79253", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", null, "Öğretmenler", "Ogretmen", "OGRETMEN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matamatik", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8332), "Matematik Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8336), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8341), "Fizik Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8342), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8343), "Kimya Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8344), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8345), "Biyoloji Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8346), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8347), "Tarih Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8348), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8349), "Coğrafya Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8350), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8351), "İngilizce Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8351), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8353), "Almanca Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8353), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8355), "Fransızca Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8355), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8356), "Felsefe Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8357), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8358), "Müzik Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8359), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8360), "Resim Dersleri", true, new DateTime(2023, 5, 1, 18, 20, 11, 543, DateTimeKind.Local).AddTicks(8361), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6514), true, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6516), "1.jpg" },
                    { 2, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6518), true, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6518), "2.jpg" },
                    { 3, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6520), true, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6520), "3.jpg" },
                    { 4, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6521), true, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6522), "4.jpg" },
                    { 5, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6523), true, new DateTime(2023, 5, 1, 18, 20, 11, 544, DateTimeKind.Local).AddTicks(6523), "5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1937b64a-9bc6-496f-8305-9e6879b3df5e", 0, "Ankara", "5d0f6fe5-714c-4e56-8398-21d03f162f8f", new DateTime(1999, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "umut.celik@example.com", true, "Umut", "Erkek", 3, "Çelik", false, null, "UMUT.CELIK@EXAMPLE.COM", "UMUTCELIK", "AQAAAAIAAYagAAAAEAsUDPyTUaRnZR1351fMKcthj2Q3BsfOZk5vRWzW5Hj/C29JyGBYyRz9AOeg8TleDw==", "5552223344", null, false, "2ebf2478-b876-48d3-a7e4-a057d7f52617", false, "umutcelik" },
                    { "28e67e95-fa20-451c-a9f0-583722d24200", 0, "İstanbul", "0d0c6d50-f073-40d4-8b4c-63aa6bfc087d", new DateTime(1988, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin.demir@example.com", true, "Aylin", "Kadın", 4, "Demir", false, null, "AYLIN.DEMIR@EXAMPLE.COM", "AYLINDEMIR", "AQAAAAIAAYagAAAAELW+YJQZyeqw4ucIFXnex0tmyWClHl5BTbPEgByH0zeJBGXHfwSbp3DZjHDNoqDuIA==", "5557779900", null, false, "49c90e37-0557-49a5-9326-91a42fa1854a", false, "aylindemir" },
                    { "2b19b395-3462-42ea-a0df-a0ae4b89ab0b", 0, "İstanbul", "89509709-61fa-42c8-a6bc-1060a3dac4f0", new DateTime(1992, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "goksu.demir@example.com", true, "Göksu", "Kadın", 5, "Demir", false, null, "GOKSU.DEMIR@EXAMPLE.COM", "GOKSUDEMIR", "AQAAAAIAAYagAAAAEO6a2av+1N+CLpB8NNRbDtVJP0Y5HPTC2S9AAKfkA3Rn07T2SOMp9hGAds8hPc/7pA==", "5554443322", null, false, "b36d0e22-0602-4be8-a206-502fe3c8430d", false, "goksudemir" },
                    { "2b26e93b-fb65-4f91-a24d-5f2313f02b9d", 0, "Bursa", "2a6215cf-8074-442d-9aa3-c266b7c74d4b", new DateTime(1998, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "seda.dogan@example.com", true, "Seda", "Kadın", 5, "Doğan", false, null, "SEDA.DOGAN@EXAMPLE.COM", "SEDADOGAN", "AQAAAAIAAYagAAAAEHaF0c1SGU9c+wU24DNZv0PpvcqdCLiAR/p6UPeX6sMfY4LBG985yeNYhnC3TF07kw==", "5554445566", null, false, "daec400e-f329-40fa-9e48-d2155bc367c3", false, "sedadogan" },
                    { "447de64b-34d7-49ff-8b33-1db3328938a7", 0, "Bursa", "62fe2b00-cc73-4a91-af72-f21ad10b4b94", new DateTime(1994, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "asli.yilmaz@example.com", true, "Aslı", "Kadın", 5, "Yılmaz", false, null, "ASLI.YILMAZ@EXAMPLE.COM", "ASLIYILMAZ", "AQAAAAIAAYagAAAAEIqbkt97/PuxB+hrbJy2+14FILm7jRHesvUSekQ4N7sSbUZcWP0On5vIQ6cmHiB5aQ==", "5555556677", null, false, "9ff10a86-0122-4b92-95b7-4ce03b9b41f7", false, "asliyilmaz" },
                    { "4f67603c-224f-43bc-a46c-c09a4ceb48a9", 0, "İstanbul", "79a01474-3c20-47fb-a28f-e6d81dcb153c", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetovali1903@gmail.com", true, "Ahmet", "Erkek", 5, "Ovalı", false, null, "AHMETOVALI1903@GMAIL.COM", "AHMETOVALI", "AQAAAAIAAYagAAAAEG1LBTNOSG32ErUBP8VMYl6hZI7LpSeIo1zzLTaAO0mweMhvL/obpx7EsIGqq0wqoA==", "5555555555", null, false, "b84771f0-fe16-444a-9271-a396582b8abc", false, "ahmetovali" },
                    { "5323ca7a-13f4-4bb5-a0c4-69f51584b27a", 0, "Antalya", "5107fb6d-bb23-4fd8-8970-9502f5a676cf", new DateTime(1990, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.kaya@example.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMET.KAYA@EXAMPLE.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEL4F0wlAPKqC2IkYd4OGwNNG99qNxU1scERFijYce3HSPaAZBO3JkZqlzW4s3rhjig==", "5551112233", null, false, "6346c395-9233-49af-a948-134d21b6aec2", false, "mehmetkaya" },
                    { "59ede6e1-c871-40f1-aa50-640f86835ed2", 0, "İzmir", "4818699b-8e86-4b22-bbf2-12b30d0a1f63", new DateTime(1997, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.can@example.com", true, "Murat", "Erkek", 5, "Can", false, null, "MURAT.CAN@EXAMPLE.COM", "MURATCAN", "AQAAAAIAAYagAAAAEC7Q0rg0iN8xtwtU+bD+4hMuGBr6UU/+K75hO+0ExNHbrOU6d28pk04t9lzuzzgAcA==", "5556667788", null, false, "f73ddc86-3d6b-4d49-bf70-376b6c556326", false, "muratcan" },
                    { "6b5a3284-b71f-48a9-9631-3f2a4c117546", 0, "Ankara", "5a8e220e-645b-4208-ae2d-b2cacb87ffbe", new DateTime(1987, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mert.kilic@example.com", true, "Mert", "Erkek", 5, "Kılıç", false, null, "MERT.KILIC@EXAMPLE.COM", "MERTKILIC", "AQAAAAIAAYagAAAAEJdghufyd3/f3pSrNPfJCA7wwaXY5UyYz7L2smXYlW3Srsz8YHZsq+rRiLZFPY0Weg==", "5551112233", null, false, "7e3ebafe-ea8b-421e-9011-69b899d530b0", false, "mertkilic" },
                    { "776eb689-ffc7-4715-80b6-9586009b7c3e", 0, "İzmir", "dcd9bd82-bc53-45d0-88b6-f0f14bd018f5", new DateTime(1991, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildir@example.com", true, "Emre", "Erkek", 1, "Yıldır", false, null, "EMRE.YILDIR@EXAMPLE.COM", "EMREYILDIR", "AQAAAAIAAYagAAAAEMNdPS6QNxw5wsjm9hlrmK/Wf1wxoTea02PClhQ/2Ya6jfAuPAnBNl27AFo2PLMDyA==", "5558887744", null, false, "359c31e2-edc8-465b-9b49-0cf9b52601f0", false, "emreyildir" },
                    { "9762298a-db23-4fce-a190-9ed853a2e0b5", 0, "İstanbul", "d200d823-1908-47e2-8dd5-5bb3f6359c24", new DateTime(1985, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.gunes@example.com", true, "Murat", "Erkek", 5, "Güneş", false, null, "MURAT.GUNES@EXAMPLE.COM", "MURATGUNES", "AQAAAAIAAYagAAAAEDGcgs85UPBrwPb4thmUEwO4CjMT30Skh4VfLWjcBB0xS/0gbpcoF23R7ietHSZv0A==", "5558889999", null, false, "47780a85-f16c-47b0-b403-d725dc0637d5", false, "muratgunes" },
                    { "9c4d427a-c0b1-4893-99e1-e50aad36fd56", 0, "Ankara", "f205c7a6-f2ce-4570-ae93-766cbb83516e", new DateTime(1994, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elif.akyildiz@example.com", true, "Elif", "Kadın", 5, "Akyıldız", false, null, "ELIF.AKYILDIZ@EXAMPLE.COM", "ELIFAKYILDIZ", "AQAAAAIAAYagAAAAEA92S1U161kzqB1r1hk08+L10+EAkBHR8r7IMQyISxnqcydfMxNE05Uff4KrwiVMwA==", "5558887766", null, false, "1821cccf-c921-4dca-a68e-479c1bff8b42", false, "elifakyildiz" },
                    { "9ddc724b-1543-4ce2-8edf-afa6d3239bb8", 0, "Ankara", "a3afec62-7076-4b83-94e8-8b21c4f15281", new DateTime(1991, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.yildiz@example.com", true, "Ayşe", "Kadın", 5, "Yıldız", false, null, "AYSE.YILDIZ@EXAMPLE.COM", "AYSEYILDIZ", "AQAAAAIAAYagAAAAEG8BXeGSDeau2AZ+E0WGmOdRst/RFtT4u/pUXIYYHVGvi5r17mDPgKfP+65F0JHZ9g==", "5553334444", null, false, "d66493ac-5bc6-4cea-822b-1003cd58d19b", false, "ayseyildiz" },
                    { "a29e0df9-3eb3-4f66-92e2-a69168f61468", 0, "İzmir", "1084754c-b822-40a1-961c-a92e0785b6f0", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "selin.ozcan@example.com", true, "Selin", "Kadın", 5, "Özcan", false, null, "SELIN.OZCAN@EXAMPLE.COM", "SELINOZCAN", "AQAAAAIAAYagAAAAEBw+6oYhqRzhE3Q1VlQYbJ0/iY7LsDRiPrzaLz/RGA+IOW1tQ+OEoYxIOBdNrAxGHA==", "5559876543", null, false, "10cef4f0-0e54-4982-b0ec-cbaa3cf46710", false, "selinozcan" },
                    { "aa91d4a0-9b30-4593-82a6-051048902a2f", 0, "Ankara", "49250853-23f2-414a-8aea-fbd0bc3a90e5", new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@example.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMET.YILMAZ@EXAMPLE.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEC3cMQgGBSxuwTwad0O8EBSHWvI9T9y0ZaYQQNFx20AGk4LNFHq02uO/eMALdfDB2A==", "5551234567", null, false, "7b5aa0d0-48e5-4b35-aac8-965975ee7c28", false, "ahmetyilmaz" },
                    { "ac276751-8f40-4d8c-928a-dbad034f6e98", 0, "Antalya", "aaeb5b4f-7eb0-4a2a-a13e-6d4b86f3dff8", new DateTime(1985, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebru.ozturk@example.com", true, "Ebru", "Kadın", 2, "Öztürk", false, null, "EBRU.OZTURK@EXAMPLE.COM", "EBRUOZTURK", "AQAAAAIAAYagAAAAEK91g5fHOdxMKKTfsP+BRcoCclL7GJl5Ps9oBg/f9cS+1X6aEvthaNbELOYWlJbYqw==", "5552221133", null, false, "18e47780-6f23-4a84-b84d-4ae61572625a", false, "ebruozturk" },
                    { "af88986c-281e-48b9-b4b9-f97942dc9a84", 0, "İstanbul", "c2af6261-c091-4601-85af-e39ef4c64aee", new DateTime(1992, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "hatice.aydin@example.com", true, "Hatice", "Kadın", 5, "Aydın", false, null, "HATICE.AYDIN@EXAMPLE.COM", "HATICEAYDIN", "AQAAAAIAAYagAAAAEAEqquqE9QldcHRYhQep3q5geaBWioMSKBZ/fhX7M3x8jbEFNHNL4v8/46Z/mLw5eg==", "5551234567", null, false, "8885c1cf-7eea-4b2f-bc83-c0e6658b0b76", false, "haticeaydin" },
                    { "baa4d49a-b70e-40a9-a7d0-a3597f8c646a", 0, "İzmir", "20419a0d-3db8-460d-8177-333363e48bb7", new DateTime(1980, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ercan.ozturk@example.com", true, "Ercan", "Erkek", 5, "Öztürk", false, null, "ERCAN.OZTURK@EXAMPLE.COM", "ERCANOZTURK", "AQAAAAIAAYagAAAAEAmmmimXhOWhtDcJ/Aybo/IKzjSH2QD2AsK+bM8g8RqHj7rQTX/6RCyMXCH6EvSnDg==", "5552223344", null, false, "5b46e1da-ba5e-44fd-a368-8a97a61be5d6", false, "ercanozturk" },
                    { "c460bb67-ff96-462a-88bb-67fdde388e51", 0, "Ankara", "1c0c58fc-0b3b-4a4a-85eb-dc94cebd47d5", new DateTime(1985, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildiz@example.com", true, "Emre", "Erkek", 5, "Yıldız", false, null, "EMRE.YILDIZ@EXAMPLE.COM", "EMREYILDIZ", null, "5301234567", null, false, "7aa96fee-e4b7-4347-978e-a700687cceaa", false, "emreyildiz" },
                    { "c6ee570c-500d-4c78-a29d-44755ab605a6", 0, "Adana", "23cc5c80-bdf6-4c0e-bcaf-9c69262a125d", new DateTime(1996, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.guler@example.com", true, "Ali", "Erkek", 5, "Güler", false, null, "ALI.GULER@EXAMPLE.COM", "ALIGULER", "AQAAAAIAAYagAAAAEFqQDkF6Siqg0yrmnwM42r977eGgeVIZk6Lgk6rk6oUO6Xlyp+MMD2znrrS2cOsWFg==", "5557778899", null, false, "35f68058-7573-43e6-91a4-9aebcb733bbe", false, "aliguler" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "1937b64a-9bc6-496f-8305-9e6879b3df5e" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "28e67e95-fa20-451c-a9f0-583722d24200" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "2b19b395-3462-42ea-a0df-a0ae4b89ab0b" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "2b26e93b-fb65-4f91-a24d-5f2313f02b9d" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "447de64b-34d7-49ff-8b33-1db3328938a7" },
                    { "6b588377-b6bc-440d-813a-771eeaa79253", "4f67603c-224f-43bc-a46c-c09a4ceb48a9" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "5323ca7a-13f4-4bb5-a0c4-69f51584b27a" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "59ede6e1-c871-40f1-aa50-640f86835ed2" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "6b5a3284-b71f-48a9-9631-3f2a4c117546" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "776eb689-ffc7-4715-80b6-9586009b7c3e" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "9762298a-db23-4fce-a190-9ed853a2e0b5" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "9c4d427a-c0b1-4893-99e1-e50aad36fd56" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "9ddc724b-1543-4ce2-8edf-afa6d3239bb8" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "a29e0df9-3eb3-4f66-92e2-a69168f61468" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "aa91d4a0-9b30-4593-82a6-051048902a2f" },
                    { "cdd1d0c1-9b00-4de9-abe1-0158fd9f477f", "ac276751-8f40-4d8c-928a-dbad034f6e98" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "af88986c-281e-48b9-b4b9-f97942dc9a84" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "baa4d49a-b70e-40a9-a7d0-a3597f8c646a" },
                    { "4425cdbf-decb-42d2-a980-8f6a4fa1ca8c", "c6ee570c-500d-4c78-a29d-44755ab605a6" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "4f67603c-224f-43bc-a46c-c09a4ceb48a9" },
                    { 2, "aa91d4a0-9b30-4593-82a6-051048902a2f" },
                    { 3, "a29e0df9-3eb3-4f66-92e2-a69168f61468" },
                    { 4, "5323ca7a-13f4-4bb5-a0c4-69f51584b27a" },
                    { 5, "2b26e93b-fb65-4f91-a24d-5f2313f02b9d" },
                    { 6, "9762298a-db23-4fce-a190-9ed853a2e0b5" },
                    { 7, "9ddc724b-1543-4ce2-8edf-afa6d3239bb8" },
                    { 8, "baa4d49a-b70e-40a9-a7d0-a3597f8c646a" },
                    { 9, "c6ee570c-500d-4c78-a29d-44755ab605a6" },
                    { 10, "af88986c-281e-48b9-b4b9-f97942dc9a84" },
                    { 11, "6b5a3284-b71f-48a9-9631-3f2a4c117546" },
                    { 12, "447de64b-34d7-49ff-8b33-1db3328938a7" },
                    { 13, "776eb689-ffc7-4715-80b6-9586009b7c3e" },
                    { 14, "ac276751-8f40-4d8c-928a-dbad034f6e98" },
                    { 15, "1937b64a-9bc6-496f-8305-9e6879b3df5e" },
                    { 16, "28e67e95-fa20-451c-a9f0-583722d24200" },
                    { 17, "59ede6e1-c871-40f1-aa50-640f86835ed2" },
                    { 18, "9c4d427a-c0b1-4893-99e1-e50aad36fd56" },
                    { 19, "2b19b395-3462-42ea-a0df-a0ae4b89ab0b" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "ImageId", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3362), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3378), null, "aa91d4a0-9b30-4593-82a6-051048902a2f" },
                    { 2, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3391), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3392), null, "a29e0df9-3eb3-4f66-92e2-a69168f61468" },
                    { 3, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3440), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3441), null, "5323ca7a-13f4-4bb5-a0c4-69f51584b27a" },
                    { 4, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3443), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3444), null, "2b26e93b-fb65-4f91-a24d-5f2313f02b9d" },
                    { 5, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3445), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3446), null, "9762298a-db23-4fce-a190-9ed853a2e0b5" },
                    { 6, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3449), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3449), null, "9ddc724b-1543-4ce2-8edf-afa6d3239bb8" },
                    { 7, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3452), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3452), null, "baa4d49a-b70e-40a9-a7d0-a3597f8c646a" },
                    { 8, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3454), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3455), null, "c6ee570c-500d-4c78-a29d-44755ab605a6" },
                    { 9, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3457), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3458), null, "af88986c-281e-48b9-b4b9-f97942dc9a84" },
                    { 10, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3460), null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3460), null, "6b5a3284-b71f-48a9-9631-3f2a4c117546" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "ImageId", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3516), "Kırıkkale Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3517), null, "447de64b-34d7-49ff-8b33-1db3328938a7" },
                    { 2, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3526), "Orta Doğu Teknik Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3527), null, "776eb689-ffc7-4715-80b6-9586009b7c3e" },
                    { 3, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3529), "İstanbul Teknik Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3529), null, "ac276751-8f40-4d8c-928a-dbad034f6e98" },
                    { 4, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3531), "Yıldız Teknik Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3532), null, "1937b64a-9bc6-496f-8305-9e6879b3df5e" },
                    { 5, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3534), "Akdeniz Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3535), null, "28e67e95-fa20-451c-a9f0-583722d24200" },
                    { 6, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3538), "Erciyes Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3539), null, "59ede6e1-c871-40f1-aa50-640f86835ed2" },
                    { 7, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3540), "Çukurova Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3541), null, "9c4d427a-c0b1-4893-99e1-e50aad36fd56" },
                    { 8, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3543), "Uludağ Üniversitesi", null, true, new DateTime(2023, 5, 1, 18, 20, 9, 668, DateTimeKind.Local).AddTicks(3543), null, "2b19b395-3462-42ea-a0df-a0ae4b89ab0b" }
                });

            migrationBuilder.InsertData(
                table: "TeacherBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 7 },
                    { 9, 7 },
                    { 10, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherStudents",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 6, 3 },
                    { 5, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TeacherId",
                table: "CartItems",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_TeacherId",
                table: "OrderItems",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ImageId",
                table: "Students",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherBranches_BranchId",
                table: "TeacherBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ImageId",
                table: "Teachers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TeacherBranches");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
