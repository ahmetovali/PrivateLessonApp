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
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
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
                    Description = table.Column<string>(type: "TEXT", nullable: true),
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
                    { "15549beb-4106-499c-9685-603ced3864a3", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", null, "Öğrenciler", "Ogrenci", "OGRENCI" },
                    { "72503ac6-1097-4bda-b3e8-5f5dd8d4b4fd", null, "Yöneticiler", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2633), "Matematik Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2638), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2644), "Fizik Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2646), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2649), "Kimya Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2649), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2652), "Biyoloji Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2653), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2655), "Tarih Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2656), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2659), "Coğrafya Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2660), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2662), "İngilizce Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2664), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2666), "Almanca Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2667), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2669), "Fransızca Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2670), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2673), "Felsefe Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2674), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2676), "Müzik Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2677), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2679), "Resim Dersleri", true, new DateTime(2023, 5, 2, 13, 28, 59, 754, DateTimeKind.Local).AddTicks(2680), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5566), true, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5569), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5572), true, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5573), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5576), true, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5577), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5579), true, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5581), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5583), true, new DateTime(2023, 5, 2, 13, 28, 59, 755, DateTimeKind.Local).AddTicks(5584), "resimyok.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "08a999de-5e39-4091-b0a2-e26271a9244e", 0, "Ankara", "4f8a8540-b59f-411a-988c-478c42a4266e", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 2, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAEDU4JZq/Bm1rbPRiVHkDTBHladz9HjYHXJ0rvqdTF0j+c1h4xWb6yjSuRFBX6TWkTw==", "5323456789", null, false, "af99e5bf-fb9d-4e34-97fd-1bc6f4db10cf", false, "cemyilmaz" },
                    { "108d135b-32e6-4aab-b67e-6287821be53a", 0, "Adana", "3421c1db-8dc1-4bcc-8d05-4285d65ba8d1", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 5, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAENRGQOm0jCUfstFS5YHdRyutuEiyh0XmdckYf5hCt+R1frsCklZYdt5ao0QoLRLZhg==", "5321234567", null, false, "a8da3985-e666-4d86-93c5-dcf9fdfd2d15", false, "gokhanaydin" },
                    { "1ca7dc61-1264-4dce-8b71-b89e091804b7", 0, "İstanbul", "50351115-98f1-4354-bb8f-a299ad4ecc77", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEEnBx0sNi1vUW88AZhs914saDqWhJMnqK/x7lsnGlDyAhjv9GMSHzF/mpw8BLSleog==", "5397891234", null, false, "ef8fd159-5700-474a-b1cc-c87900af6014", false, "esraaydin" },
                    { "1ff5e5cc-a719-4ed5-9df9-0a491c4d84b2", 0, "İstanbul", "b9fff245-b344-4f24-9dd1-f1c561bc348e", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 3, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAEHggd8jzo9Ic0sPOdK8SZbEIWmmXXLxydJgLWvmbT0t3mKFSaXZkTfxJP4gZEJMUAw==", "5387891234", null, false, "ef428b3a-c040-46af-a09e-94c48c9d4a9a", false, "sevvaldemir" },
                    { "22f680eb-f0c1-4c4b-99d9-aa2771e9f76a", 0, "Bursa", "54b9c1c7-8f09-44dd-829f-c0ac64febe2a", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEDNQ+c1ujpkpn4vI1hKTTPy3zkmyp1riZaGXOc4FWcd/R2EQgGAlrIrtEzH5TsKXHg==", "5396542513", null, false, "77cdc223-45bc-4361-8db7-c532583346fe", false, "mehmetkaya" },
                    { "26fa0135-c82a-42de-aee3-11f7bab35747", 0, "İzmir", "fccbaaa9-9519-41b3-a5ca-d6b8e171e0b0", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 4, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAEJQ04FKfTkBjg05COmqxpchA+FmJGaTx4P5iOXoMR0pWY0KJOBMtKC7Q8hirjANI0w==", "5336549876", null, false, "e114d494-0826-48a9-af3d-32a38d24c068", false, "mehmetyildiz" },
                    { "2d1798d1-8e6a-4805-a032-13e66c107bd7", 0, "Bursa", "dfbe7d60-67c6-4f79-8a2d-1d6f3e8d14de", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 5, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAEFlAuEokATQ6XVfSJsXcmZpnrX30TqJPcbxuHPt8PEd23XDIzSNuP3I/qjoN10UEzA==", "5399876543", null, false, "2c6cc210-f5d3-44ba-99e1-f287abbc4f2b", false, "seymayilmaz" },
                    { "2ea19015-5e2d-4541-9985-8463d8fe8a2d", 0, "İstanbul", "188f5124-68b5-48f5-bb4b-578ab74fb296", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@hotmail.com", true, "Ahmet", "Erkek", 5, "Ovalı", false, null, "AHMET@HOTMAIL.COM", "AHMET", "AQAAAAIAAYagAAAAEH4XP8FCZxY7WymCDvuVfWBPj25OGoXvXs+5pXIeXHOHCngb2l4UKEwRYhSP0ldFCw==", "5555555555", null, false, "5441303b-6630-4427-810a-3a3a1ae11dd7", false, "ahmet" },
                    { "54b948e9-3958-4d1a-aecc-f03ce0395955", 0, "Kayseri", "d349d8ef-c94f-40c1-923d-8aa6d270d209", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 5, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEBKDVpDjLox/e/dk5HgFChloLhROu1MFPux7W7Bcl0gWSl93yGyMoTXPeF7Pt9kZfA==", "5359876543", null, false, "48a8e92d-6a05-49ee-ac3e-4c4dc8a668a9", false, "kemalkaya" },
                    { "5e47b7b7-a7d0-49e5-a67d-b6c71dc5b759", 0, "Ankara", "4a7122b3-66fb-40df-a246-75b5d99c83a8", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMETYILMAZ@GMAİL.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEIINgr+TzUUh9azKoFGVYYsoNO4XFuenZ+iYzIECPJ8A/ISc2CwuYad0scE1swMWMw==", "5551234567", null, false, "9a92a277-1308-4ea5-aaa5-02a615612812", false, "ahmetyilmaz" },
                    { "9491c173-a816-4f7f-9a37-a30db67f57c6", 0, "Bursa", "05570d69-8fde-4a25-8dd3-eb78a2f634a5", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEElt6PdzG9VHmn0+tFGf5FnXF1eR5fKdK0Oaz7uotfmkZKJeMsJDSpIXd+yHg3y77w==", "5399782513", null, false, "28d4ca31-b18f-4c84-ab44-904747f6f399", false, "selinkar" },
                    { "9a1fe876-fe8f-400d-8b88-f9fb0714e7c9", 0, "Adana", "65dcaab7-b8be-4e66-8de5-3080526b159b", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEJ/Rq8SMmlu4H48DYu9a/FJxCq3FEB85mNcCyzJzoc0xEo2R85XqGSo5VVHlXutl+w==", "5334567890", null, false, "6eacedde-bc46-4927-a144-b50d53f1c2b6", false, "fatmasahin" },
                    { "a3037e92-4888-4096-bf7e-5d8fa5c66654", 0, "İstanbul", "5387fc02-c1b7-4bcf-9e2d-40fec12056e0", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAELrmvknV9FlL7sd8fPqOPfEVJ2We6LodAazNASTF6xtJYED/E3OcCFTN3dEOr6BwQg==", "5379876543", null, false, "ce409f11-138a-4c4e-9422-ae250a36d5bb", false, "emreakin" },
                    { "b0cb2d32-fc07-435c-8e54-4f81c14d4798", 0, "Antalya", "05440694-dcdd-4f33-b1df-525e95bcb458", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAEMtyzEyjUcaN8FdarEcMlowulC5f1xcHL6cAvedinP5A2tcTPsXWcAuuEjiDWNZ3TQ==", "5423456789", null, false, "135ec879-8310-4949-aad2-1fe8df8cc620", false, "mustafaozkan" },
                    { "b2eecaa5-d098-455e-980d-0c6938587727", 0, "Ankara", "f0848617-7ae9-4d38-9df1-b65fcf47e6e8", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEGgTa1BayM0Q2qrsj/rgtVuXEij87EDUTWQPeUWqBAzeB7qgmaolyAYgAHP8UjW+Sg==", "5336549872", null, false, "08530b7b-749e-49b0-ab0e-ba19c03389b1", false, "zeynepturk" },
                    { "be3cdd2d-24fb-41ba-80ee-0373f75fbb70", 0, "Antalya", "dc6adf27-f4e4-4c61-a5fc-44face69f2a9", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 5, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAEMh1+kiuEEmM0PVYJHpwZL+M6knbvlAuadauMi1lskmsFkZU/tc5ytHVRHWDfu8FbA==", "5361234567", null, false, "cd5f3d79-05f9-4c6b-a287-7f04a1778dc7", false, "gulsahin" },
                    { "c7412237-1a15-402e-81fc-2040e4a240bf", 0, "İzmir", "13aa5f20-026c-452f-9afa-08d24a68b437", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAELRT5TbOH1Ly9gbFtMyST22LKQUVeFceYcJdKglwnddL3w7KCmbnqF6HnBm86oNs1Q==", "5559876543", null, false, "f703f6e7-6a38-427b-a09b-737fcdc54f16", false, "aliyildiz" },
                    { "d4f37be3-e849-49cd-bee4-bf8c593c6c87", 0, "İstanbul", "fb880fca-f9fd-4785-a456-3345f4ea6542", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denizcakir@hotmail.com", true, "Deniz", "Kadın", 5, "Çakır", false, null, "DENIZCAKIR@HOTMAIL.COM", "DENIZCAKIR", "AQAAAAIAAYagAAAAECQRhdZ3B7GtxbtsDwXhsuU2Vm2kQU/Qi4uApMPPUMTKkXCqaGq2FVayWnhUNqYinw==", "5396542513", null, false, "a37c8ee6-1f32-419d-8680-adc370ffea48", false, "denizcakir" },
                    { "deba7d51-3260-4a71-aaf8-4efb25370b3a", 0, "İzmir", "6fb14880-b0b9-4bab-955d-82a1bd725b12", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAENS7yHPQscbkLI1FTCjzA8rMo3ganJbRHUpHbtnAfpYBZh1048TAxiW78fUi1ksYzA==", "5329876543", null, false, "129b961e-08fa-47a4-ab9f-5afe6799ae6e", false, "aysedemir" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "15549beb-4106-499c-9685-603ced3864a3", "08a999de-5e39-4091-b0a2-e26271a9244e" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "108d135b-32e6-4aab-b67e-6287821be53a" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "1ca7dc61-1264-4dce-8b71-b89e091804b7" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "1ff5e5cc-a719-4ed5-9df9-0a491c4d84b2" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "22f680eb-f0c1-4c4b-99d9-aa2771e9f76a" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "26fa0135-c82a-42de-aee3-11f7bab35747" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "2d1798d1-8e6a-4805-a032-13e66c107bd7" },
                    { "72503ac6-1097-4bda-b3e8-5f5dd8d4b4fd", "2ea19015-5e2d-4541-9985-8463d8fe8a2d" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "54b948e9-3958-4d1a-aecc-f03ce0395955" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "5e47b7b7-a7d0-49e5-a67d-b6c71dc5b759" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "9491c173-a816-4f7f-9a37-a30db67f57c6" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "9a1fe876-fe8f-400d-8b88-f9fb0714e7c9" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "a3037e92-4888-4096-bf7e-5d8fa5c66654" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "b0cb2d32-fc07-435c-8e54-4f81c14d4798" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "b2eecaa5-d098-455e-980d-0c6938587727" },
                    { "15549beb-4106-499c-9685-603ced3864a3", "be3cdd2d-24fb-41ba-80ee-0373f75fbb70" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "c7412237-1a15-402e-81fc-2040e4a240bf" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "d4f37be3-e849-49cd-bee4-bf8c593c6c87" },
                    { "1c3d9b4b-a18d-4fc9-957a-4cc983160b73", "deba7d51-3260-4a71-aaf8-4efb25370b3a" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "2ea19015-5e2d-4541-9985-8463d8fe8a2d" },
                    { 2, "d4f37be3-e849-49cd-bee4-bf8c593c6c87" },
                    { 3, "5e47b7b7-a7d0-49e5-a67d-b6c71dc5b759" },
                    { 4, "deba7d51-3260-4a71-aaf8-4efb25370b3a" },
                    { 5, "22f680eb-f0c1-4c4b-99d9-aa2771e9f76a" },
                    { 6, "9a1fe876-fe8f-400d-8b88-f9fb0714e7c9" },
                    { 7, "a3037e92-4888-4096-bf7e-5d8fa5c66654" },
                    { 8, "b2eecaa5-d098-455e-980d-0c6938587727" },
                    { 9, "c7412237-1a15-402e-81fc-2040e4a240bf" },
                    { 10, "b0cb2d32-fc07-435c-8e54-4f81c14d4798" },
                    { 11, "1ca7dc61-1264-4dce-8b71-b89e091804b7" },
                    { 12, "9491c173-a816-4f7f-9a37-a30db67f57c6" },
                    { 13, "08a999de-5e39-4091-b0a2-e26271a9244e" },
                    { 14, "1ff5e5cc-a719-4ed5-9df9-0a491c4d84b2" },
                    { 15, "26fa0135-c82a-42de-aee3-11f7bab35747" },
                    { 16, "be3cdd2d-24fb-41ba-80ee-0373f75fbb70" },
                    { 17, "54b948e9-3958-4d1a-aecc-f03ce0395955" },
                    { 18, "108d135b-32e6-4aab-b67e-6287821be53a" },
                    { 19, "2d1798d1-8e6a-4805-a032-13e66c107bd7" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2379), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2394), null, "d4f37be3-e849-49cd-bee4-bf8c593c6c87" },
                    { 2, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2405), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2406), null, "5e47b7b7-a7d0-49e5-a67d-b6c71dc5b759" },
                    { 3, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2408), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2409), null, "deba7d51-3260-4a71-aaf8-4efb25370b3a" },
                    { 4, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2411), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2412), null, "22f680eb-f0c1-4c4b-99d9-aa2771e9f76a" },
                    { 5, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2413), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2414), null, "9a1fe876-fe8f-400d-8b88-f9fb0714e7c9" },
                    { 6, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2416), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2417), null, "a3037e92-4888-4096-bf7e-5d8fa5c66654" },
                    { 7, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2419), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2419), null, "b2eecaa5-d098-455e-980d-0c6938587727" },
                    { 8, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2421), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2422), null, "c7412237-1a15-402e-81fc-2040e4a240bf" },
                    { 9, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2424), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2424), null, "b0cb2d32-fc07-435c-8e54-4f81c14d4798" },
                    { 10, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2427), true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2427), null, "1ca7dc61-1264-4dce-8b71-b89e091804b7" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2489), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2490), null, "9491c173-a816-4f7f-9a37-a30db67f57c6" },
                    { 2, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2500), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2501), null, "08a999de-5e39-4091-b0a2-e26271a9244e" },
                    { 3, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2503), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2504), null, "1ff5e5cc-a719-4ed5-9df9-0a491c4d84b2" },
                    { 4, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2506), "Ege Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2507), null, "26fa0135-c82a-42de-aee3-11f7bab35747" },
                    { 5, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2508), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2509), null, "be3cdd2d-24fb-41ba-80ee-0373f75fbb70" },
                    { 6, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2512), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2512), null, "54b948e9-3958-4d1a-aecc-f03ce0395955" },
                    { 7, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2514), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2515), null, "108d135b-32e6-4aab-b67e-6287821be53a" },
                    { 8, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2517), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 2, 13, 28, 57, 847, DateTimeKind.Local).AddTicks(2517), null, "2d1798d1-8e6a-4805-a032-13e66c107bd7" }
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
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherBranches_BranchId",
                table: "TeacherBranches",
                column: "BranchId");

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
