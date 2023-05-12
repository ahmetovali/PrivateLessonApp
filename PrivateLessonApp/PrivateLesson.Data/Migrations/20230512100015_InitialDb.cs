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
                    { "1a979822-46da-47c0-8201-2f42940437c3", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", null, "Öğrenciler", "Ogrenci", "OGRENCI" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(955), "Matematik Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(962), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(967), "Fizik Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(968), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(970), "Kimya Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(970), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(972), "Biyoloji Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(972), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(974), "Tarih Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(974), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(976), "Coğrafya Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(977), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(978), "İngilizce Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(979), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(980), "Almanca Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(981), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(982), "Fransızca Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(983), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(984), "Felsefe Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(985), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(986), "Müzik Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(987), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(988), "Resim Dersleri", true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(989), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6501), true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6502), "teacher-1.jpg" },
                    { 2, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6504), true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6505), "teacher-2.jpg" },
                    { 3, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6507), true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6507), "teacher-3.jpg" },
                    { 4, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6508), true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6509), "teacher-4.jpg" },
                    { 5, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6510), true, new DateTime(2023, 5, 12, 13, 0, 15, 648, DateTimeKind.Local).AddTicks(6511), "resimyok.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05a6cf7c-d1ec-4e40-bd37-5bace524ad61", 0, "İzmir", "d933a65e-1472-484f-8940-e2e5977ff83d", new DateTime(2001, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.demir@yahoo.com", true, "Ayşe", "Kadın", 5, "Demir", false, null, "AYSE.DEMIR@YAHOO.COM", "AYSEDEMIR", "AQAAAAIAAYagAAAAEF812wBeRVcxiDf9+KRvo1gOdNwVNo63bUAe79/Es8wictdihDutvJomlZao+OR60A==", "5329876543", null, false, "79fa3f04-4eed-4f93-b2b9-0e2ba8629dfd", false, "aysedemir" },
                    { "0601b97c-9713-4f14-9fb2-91b04c121a42", 0, "Bursa", "936de7b4-4ad5-4e1f-a03f-3ddc3b7056dc", new DateTime(1992, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "seyma.yilmaz@hotmail.com", true, "Şeyma", "Kadın", 5, "Yılmaz", false, null, "SEYMA.YILMAZ@HOTMAIL.COM", "SEYMAYILMAZ", "AQAAAAIAAYagAAAAEBqMLJC+4LPTDu8UgD9XOlMTwjfxO277oROKcCUoljFUxXScrePSs/0lnmYhQBX9bw==", "5399876543", null, false, "40368253-fd6d-47f1-8746-14c0f5b38368", false, "seymayilmaz" },
                    { "0cf978b8-770b-4f35-8549-52ab3e4d7900", 0, "İstanbul", "51c5da9f-3346-4276-ac2d-913a95aa05c9", new DateTime(2008, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "emreakin@hotmail.com", true, "Emre", "Erkek", 5, "Akın", false, null, "EMREAKIN@HOTMAIL.COM", "EMREAKIN", "AQAAAAIAAYagAAAAEIDQlZERCfOI2kKfc1DLILW8Wg8PGtaersR6u4bAICtvZs5OMV08GaX1KDtyDXSBMw==", "5379876543", null, false, "fca9fc73-2824-4d76-ae7b-47b37ba0dd5d", false, "emreakin" },
                    { "11f41da4-01a5-49bb-a297-915ddbc0d5e9", 0, "Bursa", "250dda10-a406-428d-9925-39c9ab884ca7", new DateTime(2009, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetkaya@hotmail.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMETKAYA@HOTMAIL.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEE71RS6AkpGaoz8xGnVtLprkDcnrt4s3Ip/9TQaez4ZH2xU08BG8yl2JcKVibA1wrg==", "5396542513", null, false, "e781b5ff-2ca0-4a43-aadd-d16e8126a434", false, "mehmetkaya" },
                    { "1822a0ca-0a7e-4da4-a026-a5a50a1b5305", 0, "İstanbul", "f9af34b3-b41e-4d35-bff3-f99ebeec9a30", new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denizcakir@hotmail.com", true, "Deniz", "Kadın", 5, "Çakır", false, null, "DENIZCAKIR@HOTMAIL.COM", "DENIZCAKIR", "AQAAAAIAAYagAAAAEFc54u730jCZaLnqFVM4pxPaiaX4mArNgJFfKqxCpD1fW5wnCQMKzrMW//5E8Mvm8A==", "5396542513", null, false, "896db0b0-95b1-4428-8dcf-2dd3a1fed88c", false, "denizcakir" },
                    { "1d9475a9-c2e3-4513-83f1-92fa5171f945", 0, "Antalya", "5aa15d77-a985-4e4d-a46f-55769182c1e6", new DateTime(2009, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mustafaozkan@gmail.com", true, "Mustafa", "Erkek", 5, "Özkan", false, null, "MUSTAFAOZKAN@GMAIL.COM", "MUSTAFAOZKAN", "AQAAAAIAAYagAAAAEG+qf43cIqj4Av41k8nkFZ8+SIDstIjOD94JwzIUPQZcCjawrKzMnkfVWk02Tbz0MA==", "5423456789", null, false, "48d52b83-7741-43dc-a0a9-ff631e58663a", false, "mustafaozkan" },
                    { "3310c3e0-ce2e-44bd-9a98-730ee7e12a8b", 0, "Ankara", "b5b66bc4-ce9d-48aa-9538-9adfea3b12b1", new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynepturk@gmail.com", true, "Zeynep", "Kadın", 5, "Türk", false, null, "ZEYNEPTURK@GMAIL.COM", "ZEYNEPTURK", "AQAAAAIAAYagAAAAEK1caI5V8oMug3Qd463DwfimdLps6AcGe9HlKaZBTtB6gF0actmORn5T3MIRLHESCg==", "5336549872", null, false, "34654ff2-ed4c-46dc-b937-7bd8fcf63f9b", false, "zeynepturk" },
                    { "73bfb08d-6f47-4016-adb4-a437dd8d09bc", 0, "Adana", "571aca10-e709-441b-b717-a601cb0b41bf", new DateTime(1990, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gokhan.aydin@gmail.com", true, "Gökhan", "Erkek", 5, "Aydın", false, null, "GOKHAN.AYDIN@GMAIL.COM", "GOKHANAYDIN", "AQAAAAIAAYagAAAAEGAQYwfezbv7eT5H8/XxriR8V/GLk+ulTzRquM0GQjaJLhO05De6irnYj+tsXWAxQw==", "5321234567", null, false, "b84a0020-a875-47f8-af0e-c1853c646314", false, "gokhanaydin" },
                    { "8a03a184-1824-4a87-a987-5cd817de817f", 0, "İstanbul", "8a6a3b50-bc4e-462c-90bd-1f06bf0ec32a", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@hotmail.com", true, "Ahmet", "Erkek", 5, "Ovalı", false, null, "AHMET@HOTMAIL.COM", "AHMET", "AQAAAAIAAYagAAAAEMTXe8D6QYN8xWtthvaXyWXeDsYcAtFsLQcII7N8j+09kHLiQP/ngF0xJKxIt3m7kw==", "5555555555", null, false, "9d4c39a3-fc0f-40a9-8e49-120e6a6649d9", false, "ahmet" },
                    { "8f17cfed-a964-4bd5-89cd-60075c729df8", 0, "Ankara", "f5df25e4-a96d-4353-8c5c-df3306cdc938", new DateTime(1990, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem.yilmaz@gmail.com", true, "Cem", "Erkek", 2, "Yılmaz", false, null, "CEM.YILMAZ@GMAIL.COM", "CEMYILMAZ", "AQAAAAIAAYagAAAAEK9CGc7CT4CyOcRj4FFPYc4zk5xRqf/kd0xAdkmS/sBKuMUgXVScEKhqCa+PyrVNBQ==", "5323456789", null, false, "74598949-b7a5-4d7c-a481-94da3993fc62", false, "cemyilmaz" },
                    { "a0b429a4-a53a-45a4-bfd7-2612852f42fe", 0, "Adana", "83f67d1e-60c4-4641-bc7f-eda18f111a4f", new DateTime(2003, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatmasahin@gmail.com", true, "Fatma", "Kadın", 5, "Şahin", false, null, "FATMASAHIN@GMAIL.COM", "FATMASAHIN", "AQAAAAIAAYagAAAAEJN1vyVXZ+chPUHQmULv9S+oEcZZ9SGT8N0g8+3CoJw6JDO1WFDYXvQ+BGxt2SFVkw==", "5334567890", null, false, "fe863090-a749-46ad-9b44-668039db900c", false, "fatmasahin" },
                    { "a1ea0889-d095-4621-91da-94c311ce9098", 0, "Bursa", "11f3509e-ad59-41ee-8b16-0b69481753f0", new DateTime(1980, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "selinkar@hotmail.com", true, "Selin", "Kadın", 1, "Kar", false, null, "SELINKAR@HOTMAIL.COM", "SELINKAR", "AQAAAAIAAYagAAAAEGNdOAPuqOYg0K7CPWokpno/XW9xwbSE8W9mZDHoouVkVhrv6PdOg7cJEzB0V6CJBg==", "5399782513", null, false, "a9e723b9-1ea6-4305-8fb2-df9f26d61fd9", false, "selinkar" },
                    { "a894e4ef-5068-4a94-9062-dc150c6f802a", 0, "Antalya", "32313549-fe8e-45b6-8df2-912e29d2c0ae", new DateTime(1980, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "gul.sahin@hotmail.com", true, "Gül", "Kadın", 5, "Şahin", false, null, "GUL.SAHIN@HOTMAIL.COM", "GULSAHIN", "AQAAAAIAAYagAAAAEPK81u+r+hW4b7ws8ZoqdYaCbhNx5EWcaYH4K62m3kl8zQPrt/KbrUrYXxL5mTjTmw==", "5361234567", null, false, "748a219e-3695-4e87-9da8-c9de814d6457", false, "gulsahin" },
                    { "a8c58153-e6d7-40eb-9eb5-b6421facc7ca", 0, "İstanbul", "b297ef16-5609-413a-b340-7d7392830d3a", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Esra", "Kadın", 5, "Aydın", false, null, "ESRAAYDIN@HOTMAIL.COM", "ESRAAYDIN", "AQAAAAIAAYagAAAAEGToRJiI1uS+tZQFz53XdPHoIMSpFh4ebfrXzJb3xgzRLDwEOtI0scbSmMmHmV3TBw==", "5397891234", null, false, "a33b55ac-9cac-4639-940f-305654365602", false, "esraaydin" },
                    { "a95f875e-e710-4634-a13e-90078cc08f72", 0, "İstanbul", "18251610-47c4-420d-ad91-5cb7bc69a9d3", new DateTime(1992, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "esraaydin@hotmail.com", true, "Şevval", "Kadın", 3, "Demir", false, null, "sevval.demir@hotmail.com", "SEVVALDEMIR", "AQAAAAIAAYagAAAAEBN3fKUJHFIcAvClx1rptTrPwQMHO1uJ4W1Ku3pB+uJASbeEoD1pIQC8wWdBDaJD7A==", "5387891234", null, false, "154725e5-b2d7-4fff-9c55-41f2b35240da", false, "sevvaldemir" },
                    { "ac11d4e5-08bb-41fb-bf73-adfebc8430bf", 0, "İzmir", "c7285138-8d79-4ab5-aea0-98e68a1f8247", new DateTime(1994, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.yildiz@gmail.com", true, "Mehmet", "Erkek", 4, "Yıldız", false, null, "MEHMET.YILDIZ@GMAIL.COM", "MEHMETYILDIZ", "AQAAAAIAAYagAAAAEBgPBZ0z31us2kSys4V5bS2RnJfz7eHcJgS9tnIRQfZW0ErYZYBb0wn7PIrei5fqGg==", "5336549876", null, false, "298811cc-020d-4def-8e3e-c5b9b7a8e5ec", false, "mehmetyildiz" },
                    { "de847b0a-2b0a-437f-ab4e-f5518b47fee3", 0, "Ankara", "3ccf908e-1c91-4634-b7f0-ded91008273e", new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz@gmail.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMETYILMAZ@GMAİL.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEKDop86FYXjt0CurMfQvlaTV6vfNuQhy0YRCYND+ENd0lRYR+FohIEDbuboljchwjw==", "5551234567", null, false, "4abb244c-89cb-4fb1-9f88-f1fb30b4d257", false, "ahmetyilmaz" },
                    { "f2d6854b-2750-4c58-a2fe-77465cfc0742", 0, "İzmir", "9dd7a906-2090-45a4-846a-9639119bfb3b", new DateTime(2007, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.yildiz@gmail.com", true, "Ali", "Erkek", 5, "Yıldız", false, null, "ALI.YILDIZ@GMAIL.COM", "ALIYILDIZ", "AQAAAAIAAYagAAAAEBJFK3aScSjR4lvnpqU2ge/Bjd65mt+KlQ5cvASrcpFeyIzmCRLzw84WB8oVxGli4g==", "5559876543", null, false, "e2bb9570-ed34-4e9b-b0d6-a30628498641", false, "aliyildiz" },
                    { "fbd7257a-6e9e-4689-9803-a9c8b0111fb8", 0, "Kayseri", "6834d567-07ff-4c6e-9442-5b7f496268ae", new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemal.kaya@gmail.com", true, "Kemal", "Erkek", 5, "Kaya", false, null, "KEMAL.KAYA@GMAIL.COM", "KEMALKAYA", "AQAAAAIAAYagAAAAEJNy69upKSUB+sI66g3B3Jtul5C/A+xINElUReBcJjLtpFef8UiAsGSgIUpwtRMxjA==", "5359876543", null, false, "2c5e71bc-b27a-4ef4-ba5a-c7059ec56652", false, "kemalkaya" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "05a6cf7c-d1ec-4e40-bd37-5bace524ad61" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "0601b97c-9713-4f14-9fb2-91b04c121a42" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "0cf978b8-770b-4f35-8549-52ab3e4d7900" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "11f41da4-01a5-49bb-a297-915ddbc0d5e9" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "1822a0ca-0a7e-4da4-a026-a5a50a1b5305" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "1d9475a9-c2e3-4513-83f1-92fa5171f945" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "3310c3e0-ce2e-44bd-9a98-730ee7e12a8b" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "73bfb08d-6f47-4016-adb4-a437dd8d09bc" },
                    { "1a979822-46da-47c0-8201-2f42940437c3", "8a03a184-1824-4a87-a987-5cd817de817f" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "8f17cfed-a964-4bd5-89cd-60075c729df8" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "a0b429a4-a53a-45a4-bfd7-2612852f42fe" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "a1ea0889-d095-4621-91da-94c311ce9098" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "a894e4ef-5068-4a94-9062-dc150c6f802a" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "a8c58153-e6d7-40eb-9eb5-b6421facc7ca" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "a95f875e-e710-4634-a13e-90078cc08f72" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "ac11d4e5-08bb-41fb-bf73-adfebc8430bf" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "de847b0a-2b0a-437f-ab4e-f5518b47fee3" },
                    { "9070f98f-7a4b-4736-9d01-4802ed61c9a4", "f2d6854b-2750-4c58-a2fe-77465cfc0742" },
                    { "6009bdd4-c680-4b31-b711-1c23c8b1e2e2", "fbd7257a-6e9e-4689-9803-a9c8b0111fb8" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "8a03a184-1824-4a87-a987-5cd817de817f" },
                    { 2, "1822a0ca-0a7e-4da4-a026-a5a50a1b5305" },
                    { 3, "de847b0a-2b0a-437f-ab4e-f5518b47fee3" },
                    { 4, "05a6cf7c-d1ec-4e40-bd37-5bace524ad61" },
                    { 5, "11f41da4-01a5-49bb-a297-915ddbc0d5e9" },
                    { 6, "a0b429a4-a53a-45a4-bfd7-2612852f42fe" },
                    { 7, "0cf978b8-770b-4f35-8549-52ab3e4d7900" },
                    { 8, "3310c3e0-ce2e-44bd-9a98-730ee7e12a8b" },
                    { 9, "f2d6854b-2750-4c58-a2fe-77465cfc0742" },
                    { 10, "1d9475a9-c2e3-4513-83f1-92fa5171f945" },
                    { 11, "a8c58153-e6d7-40eb-9eb5-b6421facc7ca" },
                    { 12, "a1ea0889-d095-4621-91da-94c311ce9098" },
                    { 13, "8f17cfed-a964-4bd5-89cd-60075c729df8" },
                    { 14, "a95f875e-e710-4634-a13e-90078cc08f72" },
                    { 15, "ac11d4e5-08bb-41fb-bf73-adfebc8430bf" },
                    { 16, "a894e4ef-5068-4a94-9062-dc150c6f802a" },
                    { 17, "fbd7257a-6e9e-4689-9803-a9c8b0111fb8" },
                    { 18, "73bfb08d-6f47-4016-adb4-a437dd8d09bc" },
                    { 19, "0601b97c-9713-4f14-9fb2-91b04c121a42" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9232), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9250), null, "1822a0ca-0a7e-4da4-a026-a5a50a1b5305" },
                    { 2, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9264), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9265), null, "de847b0a-2b0a-437f-ab4e-f5518b47fee3" },
                    { 3, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9267), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9268), null, "05a6cf7c-d1ec-4e40-bd37-5bace524ad61" },
                    { 4, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9270), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9271), null, "11f41da4-01a5-49bb-a297-915ddbc0d5e9" },
                    { 5, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9275), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9276), null, "a0b429a4-a53a-45a4-bfd7-2612852f42fe" },
                    { 6, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9278), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9279), null, "0cf978b8-770b-4f35-8549-52ab3e4d7900" },
                    { 7, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9281), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9282), null, "3310c3e0-ce2e-44bd-9a98-730ee7e12a8b" },
                    { 8, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9284), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9284), null, "f2d6854b-2750-4c58-a2fe-77465cfc0742" },
                    { 9, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9286), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9287), null, "1d9475a9-c2e3-4513-83f1-92fa5171f945" },
                    { 10, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9289), true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9290), null, "a8c58153-e6d7-40eb-9eb5-b6421facc7ca" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9347), "Çanakkale Onsekiz Mart Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9348), null, "a1ea0889-d095-4621-91da-94c311ce9098" },
                    { 2, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9361), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9362), null, "8f17cfed-a964-4bd5-89cd-60075c729df8" },
                    { 3, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9364), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9365), null, "a95f875e-e710-4634-a13e-90078cc08f72" },
                    { 4, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9368), "Ege Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9369), null, "ac11d4e5-08bb-41fb-bf73-adfebc8430bf" },
                    { 5, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9371), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9371), null, "a894e4ef-5068-4a94-9062-dc150c6f802a" },
                    { 6, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9374), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9375), null, "fbd7257a-6e9e-4689-9803-a9c8b0111fb8" },
                    { 7, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9376), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9377), null, "73bfb08d-6f47-4016-adb4-a437dd8d09bc" },
                    { 8, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9380), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 12, 13, 0, 13, 861, DateTimeKind.Local).AddTicks(9380), null, "0601b97c-9713-4f14-9fb2-91b04c121a42" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "BranchId", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, 4, new DateTime(2023, 5, 12, 13, 0, 15, 646, DateTimeKind.Local).AddTicks(6034), "ilan", true, 45m, 4, new DateTime(2023, 5, 12, 13, 0, 15, 646, DateTimeKind.Local).AddTicks(6040), "ilan" });

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
