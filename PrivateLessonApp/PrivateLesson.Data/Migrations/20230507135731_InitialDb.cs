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
                        name: "FK_Adverts_Teachers_TeacherId",
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", null, "Öğrenciler", "Ogrenci", "OGRENCI" },
                    { "a44a4695-4f86-4b32-9976-eaf375a39633", null, "Yöneticiler", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5549), "Matematik Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5556), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5567), "Fizik Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5569), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5575), "Kimya Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5577), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5582), "Biyoloji Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5584), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5589), "Tarih Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5591), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5596), "Coğrafya Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5598), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5603), "İngilizce Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5605), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5609), "Almanca Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5611), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5616), "Fransızca Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5618), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5623), "Felsefe Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5625), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5630), "Müzik Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5632), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5637), "Resim Dersleri", true, new DateTime(2023, 5, 7, 16, 57, 30, 478, DateTimeKind.Local).AddTicks(5639), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5749), true, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5755), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5762), true, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5764), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5769), true, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5771), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5776), true, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5778), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5782), true, new DateTime(2023, 5, 7, 16, 57, 30, 480, DateTimeKind.Local).AddTicks(5784), "resimyok.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "16f50864-2a00-4aca-b160-e5d6719ec3f8", 0, "İstanbul", "03510975-e6ee-4130-8099-36ed73b28744", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEA9LtRguMR8HkAXNbtreRlg7nTGmQec7baMqzxdiM4WcpWmEu4des1Qs4o6yy1FKow==", "5397891234", null, false, "df292d9c-0254-4906-a2ad-35c8ea46f01e", false, "esraaydin" },
                    { "2890d2d0-2eb0-43f0-8a38-2e62d8263aa8", 0, "İzmir", "1033451f-6196-4845-9b93-2513a24ba2aa", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAEPM7hwf2x1P+mcQcjI/7BzQww7QWLpM3o9caZJDVuCGGhkJFOQLFfXcZzEJWpwQTcQ==", "5559876543", null, false, "1b103905-7494-46dd-94a6-357305c808b8", false, "aliyildiz" },
                    { "32ee0803-e82c-4437-9fd5-1741d30ff5da", 0, "Bursa", "bf014457-b742-4b81-bfc4-21b83d0beccb", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAENICASb7sm3rJUqUhNLELlAYoHDn3pD9mfVaFOuWIDyoDqb8r/YD/f4z8u2z7dhF4Q==", "5396542513", null, false, "def5e7df-d74b-4404-b25c-561837496de2", false, "mehmetkaya" },
                    { "334fc8ed-7af0-48e8-99ba-065c9ef4f61f", 0, "Antalya", "012b802a-2407-46ce-83fa-c2041058ba34", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAEGnDyb/jjhEFuR5DwZdWvMinI4zdWwK+gjUNE1GzKIYHSixePG3/eJL2eZmq7U3EPg==", "5423456789", null, false, "d17540c8-3b16-4eb8-b59f-13aec5fd7a6f", false, "mustafaozkan" },
                    { "38d6d1dc-2173-4fd4-afd5-d75892fbbe7b", 0, "İstanbul", "7ca59165-6a54-4dfc-b18f-6475927df06c", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 3, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAELqhRXjjtlCB47EYT2GuYT1EJU3gVmD4UGHFp+Rg0TSTDKWD84eE2gN95HuvOlxWKQ==", "5387891234", null, false, "c37a0f17-20e0-48c4-88a1-c666beaba547", false, "sevvaldemir" },
                    { "497a4b44-a872-461b-af06-9bdb0328a5c4", 0, "İstanbul", "5971731f-1740-41a3-b745-4dafcd852f36", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAEGgbNpKLpfiOcWMSY5Yp7KsrBlDGKDa4e1qbIS3OrXMeWvvJFc6+PvXrsZGkBQftuA==", "5379876543", null, false, "ed1d5601-abb2-4436-951b-68dbf7668171", false, "emreakin" },
                    { "509743b4-0039-49cc-a085-888c0a3904e1", 0, "Ankara", "c92cc36f-0bfb-4b80-8144-d23a79bbad12", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMETYILMAZ@GMAİL.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEAYqkImUgTaE+XawX6uBJqBeE715i/ZR6ccAWCRHGZh1igpx89YUqxKdVcC6c1RZ5w==", "5551234567", null, false, "4ad6c33a-c2f8-47e2-beff-872353cf24e4", false, "ahmetyilmaz" },
                    { "603da648-462b-4bc9-939e-32da8516728f", 0, "İzmir", "34e90e41-feda-4f4d-92c2-63b2454c38aa", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 4, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAENA/2MSvSgsRSQC2k10WQAQt9aDWkvWa/SScd3fMXWe+/2c+od7uNPdpS9tiXG3e2w==", "5336549876", null, false, "7c54728a-4cd3-48a7-bf4f-5c9100bf80aa", false, "mehmetyildiz" },
                    { "73087a08-ad7c-4e46-852d-c6ebb03a1223", 0, "Adana", "0f54a220-60e1-4991-a735-a0e6488478e5", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 5, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAEOrtsh4Q8mLXTauab6YiDkZtsh1YgyGhX0reFHyIaZJj9WpTWY71zMhPF0IGYi3efg==", "5321234567", null, false, "139ad18c-da24-4ad5-befd-cf4cae5ba780", false, "gokhanaydin" },
                    { "8eb2fa77-dfdc-4ccc-970d-ad824a9703e3", 0, "İstanbul", "fd4e512d-ccdf-4383-a771-1dd66dbb67c9", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denizcakir@hotmail.com", true, "Deniz", "Kadın", 5, "Çakır", false, null, "DENIZCAKIR@HOTMAIL.COM", "DENIZCAKIR", "AQAAAAIAAYagAAAAEAGxHROPNxvRpJXvKU6JJ9G1ORwZ1915AW8g38d17itvSwRGXLbWkNKKzTfvOxpUVA==", "5396542513", null, false, "3ded02c3-4922-457a-a568-9fe22fd88676", false, "denizcakir" },
                    { "914e0197-3fd4-4310-872d-605d520fe948", 0, "Kayseri", "f6e39ae5-114e-409c-9d83-91266d333bee", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 5, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEJdu0QfBOxZRuvxufdk8IuLjGisZzjKAzuuSoqtqzanRorLeEMsm0tLpMCbE9+3pfQ==", "5359876543", null, false, "74431dd6-9952-4e2a-9421-c71752897ea0", false, "kemalkaya" },
                    { "92e79f96-3a9c-4382-8203-483f63b26b3d", 0, "Bursa", "f6168a20-ad5c-45c6-8623-d05fcf3cbf4c", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEKiVUrT3T9GZd2vOGHJ+GMIJ1d0SE2Y1/nPBaC4LZs1RbGTJoJ0bTMgZSXyjp+GWfw==", "5399782513", null, false, "48f9b339-bb08-4369-bd44-9cd32bce3fb2", false, "selinkar" },
                    { "ad265fb0-dd94-44e0-aff9-bfa6d60f205b", 0, "İstanbul", "9e99bb9f-3754-43f5-8fc2-aa17fc7407f3", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@hotmail.com", true, "Ahmet", "Erkek", 5, "Ovalı", false, null, "AHMET@HOTMAIL.COM", "AHMET", "AQAAAAIAAYagAAAAEOJ8WdPmw8w/lVQ/G3ra1hW89CZmET+oxMCe9P37j6pz6TNj6rM9hDzoIsHIXmZljg==", "5555555555", null, false, "a604c1b3-de54-4903-87c3-fa2058f44cca", false, "ahmet" },
                    { "ad332839-585e-4b96-8e73-0d7bcf2aaafe", 0, "Antalya", "c4d68efc-896a-4af6-8d43-2f9c52188d40", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 5, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAEG6kUACXYORYWND1el2k5Eu6cdg71TUYuZdNQUTqWo601mPAvqE9vCMbWnyxd2zb2g==", "5361234567", null, false, "9d85abdc-a8fc-4afd-8f4e-897cdef5e49b", false, "gulsahin" },
                    { "d07aee42-6694-4aaa-90ab-d421155be0ca", 0, "İzmir", "244ed901-5fbe-42d8-949b-aa7a4ae65797", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAEGypN7wYaE1OwamyV1u1yzf6wswUwCr+AMuSiehwacONQ4oL8kUaAVVaitEup6cwug==", "5329876543", null, false, "9100c182-8144-408a-8925-3f6572c8fc6a", false, "aysedemir" },
                    { "d7fc1a90-617a-47eb-8415-5741efc77ba3", 0, "Ankara", "75952f5b-032e-403a-bbb5-3208f2d292fe", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEMpp5DhsWcVkLnv7HNAuCtiLIAYZhmr40+PyO80Ues17Cc/0NJGPvAkjmEiO7QmX3w==", "5336549872", null, false, "7efc73a9-cb6f-463f-ad4c-0fdeaf83cf42", false, "zeynepturk" },
                    { "ef5532ea-9bc5-4f88-9a2a-5e538b399614", 0, "Bursa", "03aed046-228a-42ad-b4c9-5460385e49d5", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 5, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAEKpHghymmQ//z2B13VeinUzLJ+BAilNVDe2l6ZzFUvuvS5eNvik4fyxzdU6u8FxDDg==", "5399876543", null, false, "6e0d16fb-29d8-4600-9e5a-cf377a8f8bed", false, "seymayilmaz" },
                    { "f6e4f04e-e4f0-4872-be83-7e4f2bae4d5a", 0, "Ankara", "6961047f-0a07-4423-bcad-f384c9c6d6b3", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 2, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAEDr2CNzfFUpmfA9+o6DPc/+57/ZA7/meCsy+ROlHGbK7B59i216Xxx/ItF74Y0guig==", "5323456789", null, false, "14ad8a05-8d84-42ba-a55d-1ecff9c6dc07", false, "cemyilmaz" },
                    { "f766d0b1-3add-423d-a2c4-1cb4a3042b77", 0, "Adana", "8ae65703-cd51-408d-a31d-f4db661f7dcf", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEDjI91KCSl5YkBAYLls8U5gDRXAAZk7pOHrEw7eWo+RZJ8RZ30Z0/LugDIA5Ym1fjw==", "5334567890", null, false, "886aa841-eba8-45e3-8d8f-959f7079be1a", false, "fatmasahin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "16f50864-2a00-4aca-b160-e5d6719ec3f8" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "2890d2d0-2eb0-43f0-8a38-2e62d8263aa8" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "32ee0803-e82c-4437-9fd5-1741d30ff5da" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "334fc8ed-7af0-48e8-99ba-065c9ef4f61f" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "38d6d1dc-2173-4fd4-afd5-d75892fbbe7b" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "497a4b44-a872-461b-af06-9bdb0328a5c4" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "509743b4-0039-49cc-a085-888c0a3904e1" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "603da648-462b-4bc9-939e-32da8516728f" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "73087a08-ad7c-4e46-852d-c6ebb03a1223" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "8eb2fa77-dfdc-4ccc-970d-ad824a9703e3" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "914e0197-3fd4-4310-872d-605d520fe948" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "92e79f96-3a9c-4382-8203-483f63b26b3d" },
                    { "a44a4695-4f86-4b32-9976-eaf375a39633", "ad265fb0-dd94-44e0-aff9-bfa6d60f205b" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "ad332839-585e-4b96-8e73-0d7bcf2aaafe" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "d07aee42-6694-4aaa-90ab-d421155be0ca" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "d7fc1a90-617a-47eb-8415-5741efc77ba3" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "ef5532ea-9bc5-4f88-9a2a-5e538b399614" },
                    { "1c976454-b9ff-4fce-92ca-ec86eac67c94", "f6e4f04e-e4f0-4872-be83-7e4f2bae4d5a" },
                    { "8321c977-3271-42e7-84a7-a664e8ee2070", "f766d0b1-3add-423d-a2c4-1cb4a3042b77" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "ad265fb0-dd94-44e0-aff9-bfa6d60f205b" },
                    { 2, "8eb2fa77-dfdc-4ccc-970d-ad824a9703e3" },
                    { 3, "509743b4-0039-49cc-a085-888c0a3904e1" },
                    { 4, "d07aee42-6694-4aaa-90ab-d421155be0ca" },
                    { 5, "32ee0803-e82c-4437-9fd5-1741d30ff5da" },
                    { 6, "f766d0b1-3add-423d-a2c4-1cb4a3042b77" },
                    { 7, "497a4b44-a872-461b-af06-9bdb0328a5c4" },
                    { 8, "d7fc1a90-617a-47eb-8415-5741efc77ba3" },
                    { 9, "2890d2d0-2eb0-43f0-8a38-2e62d8263aa8" },
                    { 10, "334fc8ed-7af0-48e8-99ba-065c9ef4f61f" },
                    { 11, "16f50864-2a00-4aca-b160-e5d6719ec3f8" },
                    { 12, "92e79f96-3a9c-4382-8203-483f63b26b3d" },
                    { 13, "f6e4f04e-e4f0-4872-be83-7e4f2bae4d5a" },
                    { 14, "38d6d1dc-2173-4fd4-afd5-d75892fbbe7b" },
                    { 15, "603da648-462b-4bc9-939e-32da8516728f" },
                    { 16, "ad332839-585e-4b96-8e73-0d7bcf2aaafe" },
                    { 17, "914e0197-3fd4-4310-872d-605d520fe948" },
                    { 18, "73087a08-ad7c-4e46-852d-c6ebb03a1223" },
                    { 19, "ef5532ea-9bc5-4f88-9a2a-5e538b399614" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8123), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8162), null, "8eb2fa77-dfdc-4ccc-970d-ad824a9703e3" },
                    { 2, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8220), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8224), null, "509743b4-0039-49cc-a085-888c0a3904e1" },
                    { 3, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8235), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8239), null, "d07aee42-6694-4aaa-90ab-d421155be0ca" },
                    { 4, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8249), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8252), null, "32ee0803-e82c-4437-9fd5-1741d30ff5da" },
                    { 5, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8261), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8265), null, "f766d0b1-3add-423d-a2c4-1cb4a3042b77" },
                    { 6, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8278), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8282), null, "497a4b44-a872-461b-af06-9bdb0328a5c4" },
                    { 7, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8292), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8295), null, "d7fc1a90-617a-47eb-8415-5741efc77ba3" },
                    { 8, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8304), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8308), null, "2890d2d0-2eb0-43f0-8a38-2e62d8263aa8" },
                    { 9, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8317), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8321), null, "334fc8ed-7af0-48e8-99ba-065c9ef4f61f" },
                    { 10, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8334), true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8338), null, "16f50864-2a00-4aca-b160-e5d6719ec3f8" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8599), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8604), null, "92e79f96-3a9c-4382-8203-483f63b26b3d" },
                    { 2, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8645), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8650), null, "f6e4f04e-e4f0-4872-be83-7e4f2bae4d5a" },
                    { 3, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8661), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8665), null, "38d6d1dc-2173-4fd4-afd5-d75892fbbe7b" },
                    { 4, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8675), "Ege Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8680), null, "603da648-462b-4bc9-939e-32da8516728f" },
                    { 5, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8690), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8694), null, "ad332839-585e-4b96-8e73-0d7bcf2aaafe" },
                    { 6, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8706), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8711), null, "914e0197-3fd4-4310-872d-605d520fe948" },
                    { 7, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8722), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8725), null, "73087a08-ad7c-4e46-852d-c6ebb03a1223" },
                    { 8, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8735), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 7, 16, 57, 26, 875, DateTimeKind.Local).AddTicks(8738), null, "ef5532ea-9bc5-4f88-9a2a-5e538b399614" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, new DateTime(2023, 5, 7, 16, 57, 30, 474, DateTimeKind.Local).AddTicks(9460), "ilan", true, 45m, 4, new DateTime(2023, 5, 7, 16, 57, 30, 474, DateTimeKind.Local).AddTicks(9467), "ilan" });

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
                name: "Adverts");

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
