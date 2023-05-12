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
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Teachers_TeacherId",
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

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
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
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", null, "Öğrenciler", "Ogrenci", "OGRENCI" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "e3119a67-2feb-47b8-ba93-e3db9a540cd6", null, "Yöneticiler", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(804), "Matematik Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(807), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(812), "Fizik Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(812), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(814), "Kimya Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(815), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(816), "Biyoloji Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(817), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(818), "Tarih Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(818), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(820), "Coğrafya Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(820), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(822), "İngilizce Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(822), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(824), "Almanca Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(824), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(825), "Fransızca Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(826), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(827), "Felsefe Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(828), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(829), "Müzik Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(830), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(831), "Resim Dersleri", true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(831), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5709), true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5711), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5713), true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5713), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5715), true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5715), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5717), true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5717), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5719), true, new DateTime(2023, 5, 12, 13, 57, 0, 390, DateTimeKind.Local).AddTicks(5719), "resimyok.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1481f491-b373-4b15-a730-9e67eb37249e", 0, "Adana", "89375d40-9dbf-4739-abe1-8837069da5f3", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 5, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAECBixth8gHmjuDEp/YeZRmA6RXma0rNjRzPEyS7BuAnf34IjFdluy0eyi2J4gQlDMw==", "5321234567", null, false, "f6725579-462f-481e-9d35-dbb5ff022148", false, "gokhanaydin" },
                    { "1a177ce2-5931-406d-9119-3347ec472ba9", 0, "İstanbul", "4c1dd918-e1af-49a2-844c-ddbc78e1dd0b", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEEg5qZtjf72zmwINc9YYrLPk5NJQjC/5AF0m59lDLums6pXnMSgSbLkOYZFCJe0C0Q==", "5397891234", null, false, "8b44d094-4d81-49fe-af36-17e34f8d32b2", false, "esraaydin" },
                    { "1e7ed4af-97e2-406a-9def-16ab848314c7", 0, "Bursa", "e6b02f4b-980f-4ad2-ba47-1c8647aa7732", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEL94g7+JaXBPEp8t5C4473to3mXpFeTRqfK8CjsBzAiOR3ll2k+BQ1tIntYx5aEKqA==", "5396542513", null, false, "56fc4490-280b-41ed-a6ac-67a2fd6ec3a3", false, "mehmetkaya" },
                    { "55bd22e6-2a9d-4ba2-b9ca-ccaf382a5b00", 0, "İstanbul", "9d4ce546-200f-4119-8b4f-6368de512985", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@hotmail.com", true, "Ahmet", "Erkek", 5, "Ovalı", false, null, "AHMET@HOTMAIL.COM", "AHMET", "AQAAAAIAAYagAAAAEMTgVe7DJst3E6DTKyCI88B5XGlVBy36OOBqBvYxx+kfBX58S18OCh2BzpHZ/3J32A==", "5555555555", null, false, "9b874daf-5e71-4b2c-90de-593dd35494fa", false, "ahmet" },
                    { "57aa0d8b-c87f-48ef-8dda-b95db2b49c54", 0, "İzmir", "551e8542-6f2b-46bb-9a1b-82ac835d3ea5", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 4, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAEOL8YX48TQ8nakWFS158vtZ55ZHy2VZnNC6S/Tawon0fHWLDZXgHp8Xyo00nFD9VVg==", "5336549876", null, false, "44ae7429-a46b-4925-8e8c-6d8d5df291ed", false, "mehmetyildiz" },
                    { "65bb8122-a0ac-4371-b0c1-80235e213edb", 0, "İzmir", "010f420e-bac8-46b2-8b94-6f05f1487a42", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAEIROzyTUAyfBUsdEYHWZ2HzjBa7t/uk8nSF/xTG6pZxuZySUEcih22rbk1aT8Uia9w==", "5329876543", null, false, "b1685b4b-c0d3-49a9-8b87-14adac91a31c", false, "aysedemir" },
                    { "736b4336-3fbd-4b46-a3a5-8968798e94d1", 0, "İstanbul", "d783354c-60b8-43cb-aec3-146b00c1e952", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 3, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAEOmMQhVo3sKvnPKhxburl63/Ie/BCz6KIVV9hzv6hbZAOJoBp3X9FPEJEX0Z0nmWLQ==", "5387891234", null, false, "f481b933-eabe-47ae-862d-8348ff7d5661", false, "sevvaldemir" },
                    { "7fd92995-4546-4880-b68f-e9915e962802", 0, "Ankara", "a1213575-e9f4-40ba-b76d-f84f4d7e08f1", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 2, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAEEOYnSqpHa1XXQ2yDIlL4n/RlbJEPQElJIyoWhr+q5SGJEBY2jSxD8PDSGZFXP2Taw==", "5323456789", null, false, "3c19a8bb-3441-4dbc-aaf1-ccf77f1caa41", false, "cemyilmaz" },
                    { "9bbc795a-c3f9-4a64-a3d6-dafe8f65b160", 0, "Antalya", "fba986a4-6e2f-417e-b7ed-e6460a626194", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAEFdAS9Eo8jf4uNQ7Ux3HKIWY6faNJ7GJni44Tixj2MQOqJa8FOtLa4dFZLxReMLhHg==", "5423456789", null, false, "283958d4-6644-4fcf-a83c-c058a236759e", false, "mustafaozkan" },
                    { "a5c98e9f-44b0-4c81-818e-e91bc42c953e", 0, "İstanbul", "8beda5ad-fcaa-4752-8b4b-916a28a85295", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denizcakir@hotmail.com", true, "Deniz", "Kadın", 5, "Çakır", false, null, "DENIZCAKIR@HOTMAIL.COM", "DENIZCAKIR", "AQAAAAIAAYagAAAAEOa4k9WWg0asjgU9bYbhQ0x4JJDGOY0XI7kTeh9rCEqCbItoenPjlv8RlRfW0sJQxQ==", "5396542513", null, false, "29fca088-662c-4ade-8947-60b56abc043a", false, "denizcakir" },
                    { "b9e5e681-4104-41e8-86b0-0258ff198b27", 0, "İstanbul", "cabd8f66-7cbf-46f0-9077-09224534fe3a", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAEHw+0v3pLCag9vscBmkNShBwsq0c7inyj9TB35qsY3mwsiPpJ5ehpdpQHhqtwLJeHQ==", "5379876543", null, false, "571899de-c24e-4174-96a9-b3717f924d26", false, "emreakin" },
                    { "c3dd3f7c-ba43-4963-b434-d50b737c1743", 0, "Ankara", "64195c65-5e6f-4e38-bd00-ee1ceb771509", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEBaMSh67eRIoJkNoFqedkkCnM5YBxoc8fshpemSJ/hOU1Rm6vUGXQdNZ6gRsUYGx1w==", "5336549872", null, false, "6cc6f14a-64aa-42d7-aec7-89e2dc49fea8", false, "zeynepturk" },
                    { "c8f66982-61c8-401f-9c09-493ab9872362", 0, "Bursa", "f6f05f6e-db67-4603-8edc-1d0b170e4918", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEOkcH3Im9mVQPwNMmbbx7SvM9fRVWboSmbSlarWNK3sG1x6ZSK/Whskqhn20XY85wQ==", "5399782513", null, false, "c4e9c978-1a42-43cf-9ec5-9cbeaa4a1d88", false, "selinkar" },
                    { "cb9fe7b2-b43b-43e4-b629-1999e60cd98f", 0, "İzmir", "0d890b37-c546-4fa7-8ddc-b60314b4d5f6", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAEBnYrcmX6zJsPgPZIZSyoyH0+4265Ryk0Q0ztwNW6MOS//DuGjfeLJf6zOwmyxGr0Q==", "5559876543", null, false, "b9cdb89d-c43d-498e-812c-5741b2c636cb", false, "aliyildiz" },
                    { "d210a19c-9c77-47b8-9b1a-0a63f951c465", 0, "Kayseri", "a022a457-0645-45d0-9972-d0ff526950b3", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 5, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEGaZh41YrQxhh5b4QsjbsO8o5j6fKYxxEIkF/0guACm06SlhL6VPC5l65ctwSsaG/A==", "5359876543", null, false, "83eb2fb7-cb5c-4aa5-a526-f9e5849d5126", false, "kemalkaya" },
                    { "db79a216-2700-4d09-ae2f-f09d30ed356f", 0, "Adana", "363a8285-634e-4435-8887-8f4b14bdc067", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEEn5jHSvNMeBrEhbO96aZ92bY4NmG6oyY4Oi+PPu1k462ZFDMHMFmYy+LVhyYr5M4w==", "5334567890", null, false, "bbb2c789-f183-4f33-8e76-a7d1c1c7eddb", false, "fatmasahin" },
                    { "e68702cf-3d87-482d-a4a4-3822e6ab278d", 0, "Antalya", "40a94a8b-0e32-44e3-8842-30840543bbd1", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 5, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAEDcGowqjzOj+FUjQRouu6ifCjxu4dN6B3R/wBRLVSM7SA3OudvuhIpbSjlCDHLSDVg==", "5361234567", null, false, "accf23dd-8ff5-4c40-a27d-54712c043eb5", false, "gulsahin" },
                    { "ec0d588f-cb8a-4c7e-ae02-72074845f3b8", 0, "Ankara", "54f2e7e7-ceff-4a3e-9f50-8a23c08d9516", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMETYILMAZ@GMAİL.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEHddKFJs9x+vtFVfgNKL2RqNxojcXqAz+kAqag2g1jiqUiHy4JPyWAiP8kLagX8vZg==", "5551234567", null, false, "829f3185-07a3-49b1-8fe3-ec50e138bc1e", false, "ahmetyilmaz" },
                    { "eff716f0-d4a5-4fe0-819f-08e33ae5388a", 0, "Bursa", "f5605d3a-b1a5-44f4-98a8-d4ef926e001f", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 5, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAEF3Y8QBCaOMj74P+u4xeMPZnzoWSzLclowzu6QpFjgYo2QTU9pXWMlX/7eU/zPl9nA==", "5399876543", null, false, "4cf4418f-b901-49e2-b858-5c5f3cc0b9e6", false, "seymayilmaz" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "1481f491-b373-4b15-a730-9e67eb37249e" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "1a177ce2-5931-406d-9119-3347ec472ba9" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "1e7ed4af-97e2-406a-9def-16ab848314c7" },
                    { "e3119a67-2feb-47b8-ba93-e3db9a540cd6", "55bd22e6-2a9d-4ba2-b9ca-ccaf382a5b00" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "57aa0d8b-c87f-48ef-8dda-b95db2b49c54" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "65bb8122-a0ac-4371-b0c1-80235e213edb" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "736b4336-3fbd-4b46-a3a5-8968798e94d1" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "7fd92995-4546-4880-b68f-e9915e962802" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "9bbc795a-c3f9-4a64-a3d6-dafe8f65b160" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "a5c98e9f-44b0-4c81-818e-e91bc42c953e" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "b9e5e681-4104-41e8-86b0-0258ff198b27" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "c3dd3f7c-ba43-4963-b434-d50b737c1743" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "c8f66982-61c8-401f-9c09-493ab9872362" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "cb9fe7b2-b43b-43e4-b629-1999e60cd98f" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "d210a19c-9c77-47b8-9b1a-0a63f951c465" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "db79a216-2700-4d09-ae2f-f09d30ed356f" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "e68702cf-3d87-482d-a4a4-3822e6ab278d" },
                    { "1a76bd65-23b1-400b-bfb7-bf3fc24c98f3", "ec0d588f-cb8a-4c7e-ae02-72074845f3b8" },
                    { "a0f72869-20a4-452b-b0df-32ca88a2cd42", "eff716f0-d4a5-4fe0-819f-08e33ae5388a" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "55bd22e6-2a9d-4ba2-b9ca-ccaf382a5b00" },
                    { 2, "a5c98e9f-44b0-4c81-818e-e91bc42c953e" },
                    { 3, "ec0d588f-cb8a-4c7e-ae02-72074845f3b8" },
                    { 4, "65bb8122-a0ac-4371-b0c1-80235e213edb" },
                    { 5, "1e7ed4af-97e2-406a-9def-16ab848314c7" },
                    { 6, "db79a216-2700-4d09-ae2f-f09d30ed356f" },
                    { 7, "b9e5e681-4104-41e8-86b0-0258ff198b27" },
                    { 8, "c3dd3f7c-ba43-4963-b434-d50b737c1743" },
                    { 9, "cb9fe7b2-b43b-43e4-b629-1999e60cd98f" },
                    { 10, "9bbc795a-c3f9-4a64-a3d6-dafe8f65b160" },
                    { 11, "1a177ce2-5931-406d-9119-3347ec472ba9" },
                    { 12, "c8f66982-61c8-401f-9c09-493ab9872362" },
                    { 13, "7fd92995-4546-4880-b68f-e9915e962802" },
                    { 14, "736b4336-3fbd-4b46-a3a5-8968798e94d1" },
                    { 15, "57aa0d8b-c87f-48ef-8dda-b95db2b49c54" },
                    { 16, "e68702cf-3d87-482d-a4a4-3822e6ab278d" },
                    { 17, "d210a19c-9c77-47b8-9b1a-0a63f951c465" },
                    { 18, "1481f491-b373-4b15-a730-9e67eb37249e" },
                    { 19, "eff716f0-d4a5-4fe0-819f-08e33ae5388a" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9272), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9288), null, "a5c98e9f-44b0-4c81-818e-e91bc42c953e" },
                    { 2, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9301), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9302), null, "ec0d588f-cb8a-4c7e-ae02-72074845f3b8" },
                    { 3, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9304), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9305), null, "65bb8122-a0ac-4371-b0c1-80235e213edb" },
                    { 4, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9306), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9307), null, "1e7ed4af-97e2-406a-9def-16ab848314c7" },
                    { 5, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9309), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9309), null, "db79a216-2700-4d09-ae2f-f09d30ed356f" },
                    { 6, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9312), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9312), null, "b9e5e681-4104-41e8-86b0-0258ff198b27" },
                    { 7, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9314), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9315), null, "c3dd3f7c-ba43-4963-b434-d50b737c1743" },
                    { 8, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9317), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9317), null, "cb9fe7b2-b43b-43e4-b629-1999e60cd98f" },
                    { 9, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9319), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9320), null, "9bbc795a-c3f9-4a64-a3d6-dafe8f65b160" },
                    { 10, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9322), true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9323), null, "1a177ce2-5931-406d-9119-3347ec472ba9" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9386), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9387), null, "c8f66982-61c8-401f-9c09-493ab9872362" },
                    { 2, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9399), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9400), null, "7fd92995-4546-4880-b68f-e9915e962802" },
                    { 3, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9402), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9403), null, "736b4336-3fbd-4b46-a3a5-8968798e94d1" },
                    { 4, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9405), "Ege Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9405), null, "57aa0d8b-c87f-48ef-8dda-b95db2b49c54" },
                    { 5, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9407), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9408), null, "e68702cf-3d87-482d-a4a4-3822e6ab278d" },
                    { 6, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9411), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9411), null, "d210a19c-9c77-47b8-9b1a-0a63f951c465" },
                    { 7, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9413), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9414), null, "1481f491-b373-4b15-a730-9e67eb37249e" },
                    { 8, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9416), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 12, 13, 56, 58, 593, DateTimeKind.Local).AddTicks(9416), null, "eff716f0-d4a5-4fe0-819f-08e33ae5388a" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "BranchId", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, 4, new DateTime(2023, 5, 12, 13, 57, 0, 388, DateTimeKind.Local).AddTicks(8279), "ilan", true, 45m, 4, new DateTime(2023, 5, 12, 13, 57, 0, 388, DateTimeKind.Local).AddTicks(8283), "ilan" });

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
                name: "IX_Adverts_BranchId",
                table: "Adverts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TeacherId",
                table: "Adverts",
                column: "TeacherId");

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
                name: "IX_CartItems_AdvertId",
                table: "CartItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AdvertId",
                table: "OrderItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

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
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
