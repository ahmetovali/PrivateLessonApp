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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
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
                    { "1ead16a5-50f9-4079-910b-80ac95027684", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", null, "Öğretmenler", "Öğretmen", "OGRETMEN" },
                    { "df13404b-0425-4670-ac16-f721b892caac", null, "Öğrenciler", "Öğrenci", "OGRENCI" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0ca225bc-497f-492d-98d1-99e5645fe291", 0, "İstanbul", "2f0cf0eb-31c4-46f3-8125-19120a425b40", new DateTime(1992, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "hatice.aydin@example.com", true, "Hatice", "Kadın", "Aydın", false, null, "HATICE.AYDIN@EXAMPLE.COM", "HATICEAYDIN", "AQAAAAIAAYagAAAAEHAiD/xB0CH2IPADAyi6k38H1xv5xoHWLhXgdo3m8AMfO/YNQ6jlQ8Z113Udrs9fNA==", "5551234567", null, false, "4d1e9893-7126-4f98-85b4-49925fd4a43e", false, "haticeaydin" },
                    { "1c0f707f-b080-4835-aacb-b749e1d2d4ea", 0, "Antalya", "4883e705-0ac6-4340-9579-abd9953b8f9e", new DateTime(1990, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.kaya@example.com", true, "Mehmet", "Erkek", "Kaya", false, null, "MEHMET.KAYA@EXAMPLE.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEP9gDMMmeUAidfTQ0iIyyLyBBPMJXjkLO4XAflRFwyftZ5cshwB9wWDUy1G6qePUEA==", "5551112233", null, false, "437d9fad-7ef6-4041-b078-fe87d92fb933", false, "mehmetkaya" },
                    { "237a9294-669f-495f-8aea-c95430561a0b", 0, "Ankara", "64dc343d-b4b0-4792-8512-c8b48cf89e09", new DateTime(1987, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mert.kilic@example.com", true, "Mert", "Erkek", "Kılıç", false, null, "MERT.KILIC@EXAMPLE.COM", "MERTKILIC", "AQAAAAIAAYagAAAAEMasu2TiC+voHMvWp7V+E9zwPVP+svUthtjHrNQoGRORN4rS/psu0XuSB+hJjHBH+g==", "5551112233", null, false, "3a9c652a-3d44-41b3-bf39-ab3689f0ebba", false, "mertkilic" },
                    { "45f36c5a-f362-4769-9567-741154e98f84", 0, "Bursa", "8d02902c-6fea-45ed-aa2a-d7f2db7ed73b", new DateTime(1994, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "asli.yilmaz@example.com", true, "Aslı", "Kadın", "Yılmaz", false, null, "ASLI.YILMAZ@EXAMPLE.COM", "ASLIYILMAZ", "AQAAAAIAAYagAAAAEBdyYBAzzTFuEaWuMRNJPNkz2lwQECeAZKTY0HLGF4HnzA0vH8JNuaEVRBtBKeKIeA==", "5555556677", null, false, "abd0cc38-2d36-42a0-98fc-a09af7ef2065", false, "asliyilmaz" },
                    { "46bbfa6e-bf2c-4c75-abab-a2ce4fe462c8", 0, "Ankara", "fa366d4e-98a3-48a2-bfed-5e5225115aaf", new DateTime(1999, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "umut.celik@example.com", true, "Umut", "Erkek", "Çelik", false, null, "UMUT.CELIK@EXAMPLE.COM", "UMUTCELIK", "AQAAAAIAAYagAAAAELCKk4q+ToJb5lw4PwW7r7z/sBSO+wim0O+Up4B9OA2noesOpAgpBDOP/qn3+N4Dtw==", "5552223344", null, false, "32988afc-4073-4def-a0d0-b5a0c38813fc", false, "umutcelik" },
                    { "4f5e1da5-c3c2-4e96-b771-95cc538fdb71", 0, "İzmir", "404c1e50-65f2-4cbc-99c4-d566c66921af", new DateTime(1997, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.can@example.com", true, "Murat", "Erkek", "Can", false, null, "MURAT.CAN@EXAMPLE.COM", "MURATCAN", "AQAAAAIAAYagAAAAEE6lsnGuk+sdJWbRPg/p5GgYYD63oNXuYlAKaKr5pWe0yVafCwoJkeB2Q0iERx21PA==", "5556667788", null, false, "dc3b80c2-e3ac-44f0-8629-bac543192358", false, "muratcan" },
                    { "656c9e9f-9fb3-4258-973d-7fda59bd19db", 0, "Antalya", "48c6e2bb-fb07-4ae7-a8ff-ae2ea7837941", new DateTime(1985, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebru.ozturk@example.com", true, "Ebru", "Kadın", "Öztürk", false, null, "EBRU.OZTURK@EXAMPLE.COM", "EBRUOZTURK", "AQAAAAIAAYagAAAAEGYqUN1siZPryoo03eqyPMufG07u7WQpKvF/EgssmVQMwBngirvP4lavNX/k99241g==", "5552221133", null, false, "26bc18ad-64cd-4cce-9036-0a74c62199cc", false, "ebruozturk" },
                    { "674ab086-45b0-48cb-8149-cf6c465eab89", 0, "İstanbul", "c11c3264-eb65-4897-a920-95af4bd249e5", new DateTime(1988, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin.demir@example.com", true, "Aylin", "Kadın", "Demir", false, null, "AYLIN.DEMIR@EXAMPLE.COM", "AYLINDEMIR", "AQAAAAIAAYagAAAAEOwKbzl4C1O1zVVEMDIn0SAPNzXuOPu4f6ue4hKdvyhtSiEh/Eppa1Msg2Zngqo2yg==", "5557779900", null, false, "c2cb3e2f-af4d-4bca-850c-f5f5253293f6", false, "aylindemir" },
                    { "7177dd61-6c1c-42eb-bcc3-00c5494ecc57", 0, "İzmir", "ae801043-dc90-491e-8f32-934926333776", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "selin.ozcan@example.com", true, "Selin", "Kadın", "Özcan", false, null, "SELIN.OZCAN@EXAMPLE.COM", "SELINOZCAN", "AQAAAAIAAYagAAAAEBheConIIEhFeRl0zxYuTHvZmeN/81bS3e9O/CswuipJB0MU45dpPLQbwq4+au2Csw==", "5559876543", null, false, "5ed98af1-e50c-4924-a918-bc58aa94e7bc", false, "selinozcan" },
                    { "72917505-bb15-47fe-b10d-8a4743c66195", 0, "İzmir", "6e70fd00-b7ee-48b3-95d9-a7c61fbe4d26", new DateTime(1980, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ercan.ozturk@example.com", true, "Ercan", "Erkek", "Öztürk", false, null, "ERCAN.OZTURK@EXAMPLE.COM", "ERCANOZTURK", "AQAAAAIAAYagAAAAEHenCsix0WzNaLNN/UUm/weSPxEeMaKIR18w4RhE+gXfyH5VPbqJXNWoFGDVGpRq/w==", "5552223344", null, false, "2f6bc759-d1e0-4a2e-9e2b-7be271a3150a", false, "ercanozturk" },
                    { "76363925-9072-4736-915f-ece26aa0dc30", 0, "İstanbul", "ce0d4173-3aca-429c-931a-3a4a2d1bbfbc", new DateTime(1985, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.gunes@example.com", true, "Murat", "Erkek", "Güneş", false, null, "MURAT.GUNES@EXAMPLE.COM", "MURATGUNES", "AQAAAAIAAYagAAAAEM7sxKgCC9ZsIJxfMOSpS3s1RDpne5NpLpVlrigayXvPANrH71O7DgEzEBYDY/LsFA==", "5558889999", null, false, "9b51b572-5280-4e62-bd97-e5f6d6b39077", false, "muratgunes" },
                    { "7817ee1b-6eb4-4449-ac44-c57f6c311edb", 0, "Ankara", "984717f7-9a69-4436-90b7-3c821ea82037", new DateTime(1985, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildiz@example.com", true, "Emre", "Erkek", "Yıldız", false, null, "EMRE.YILDIZ@EXAMPLE.COM", "EMREYILDIZ", null, "5301234567", null, false, "51edab4c-0480-413e-87fb-7877d47e8510", false, "emreyildiz" },
                    { "79f96167-7589-4d4f-b02d-c4d4105b0230", 0, "İzmir", "14f30ddf-c4d1-435a-a1ed-a681faf96180", new DateTime(1991, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildir@example.com", true, "Emre", "Erkek", "Yıldır", false, null, "EMRE.YILDIR@EXAMPLE.COM", "EMREYILDIR", "AQAAAAIAAYagAAAAEJeSM8QE0DjtSCPo06HveT1HDQfgNZ/gt9nId81sG5VdaZ1w0SKZMBS7ToG2RRbBoQ==", "5558887744", null, false, "1ac3ed45-e519-42ce-ac55-331e2a69dbc1", false, "emreyildir" },
                    { "abef7276-b604-4c3c-adb1-2a878d3140be", 0, "Bursa", "80fd9191-54d5-4307-bd45-2ad79c550d15", new DateTime(1998, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "seda.dogan@example.com", true, "Seda", "Kadın", "Doğan", false, null, "SEDA.DOGAN@EXAMPLE.COM", "SEDADOGAN", "AQAAAAIAAYagAAAAEGtJzIp4E+VIkvNcyT9WMQYjxJUPETSrVIOsib3nZ3oeGDziObymyjc9hVDcOmaRQA==", "5554445566", null, false, "e2b983ff-d817-462f-a371-6f31d6ca2ef6", false, "sedadogan" },
                    { "bed72338-361e-4709-a197-e1f6c2c40a77", 0, "Adana", "7676c58e-aece-4d01-8584-5ab7522e892a", new DateTime(1996, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.guler@example.com", true, "Ali", "Erkek", "Güler", false, null, "ALI.GULER@EXAMPLE.COM", "ALIGULER", "AQAAAAIAAYagAAAAEOsAecBicv+l67ACzLXPqi8b8fVDPny2wElExNb0lYrE3nKEfYuiblSxjrVeVoL9eQ==", "5557778899", null, false, "4e12185d-a642-4762-98d7-e349134cae95", false, "aliguler" },
                    { "ca2d1d35-8476-4b7a-af6e-5d1ef00f32c3", 0, "İstanbul", "29e4f9cc-59db-4494-bbac-b287d3c14876", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetovali1903@gmail.com", true, "Ahmet", "Erkek", "Ovalı", false, null, "AHMETOVALI1903@GMAIL.COM", "AHMETOVALI", "AQAAAAIAAYagAAAAEJ7s2dPGAyEaUniegxszKTjED/qRN19ww9+8jaKlJn3Ogd5A6nvTSP2R9RMmQxiefw==", "5555555555", null, false, "3e78d64b-4834-4310-97f0-74e5290c1493", false, "ahmetovali" },
                    { "d26ac1ff-0492-4827-8d9b-a92f106242f9", 0, "Ankara", "023d365f-0b33-430d-9719-01a949c094e4", new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@example.com", true, "Ahmet", "Erkek", "Yılmaz", false, null, "AHMET.YILMAZ@EXAMPLE.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAENo7MP7yCVPiNmmHM0Hx6dcU55L6x/oLIXLR20r9aU+0vcK+pJ2i4ILo5FRvqNjIdw==", "5551234567", null, false, "ee8088c2-08f6-4404-8b77-e06b57c5c42b", false, "ahmetyilmaz" },
                    { "e2c50181-52b5-4b46-8edf-99199c684e08", 0, "Ankara", "c71d1124-cee7-47bc-821b-c25a7283f798", new DateTime(1991, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.yildiz@example.com", true, "Ayşe", "Kadın", "Yıldız", false, null, "AYSE.YILDIZ@EXAMPLE.COM", "AYSEYILDIZ", "AQAAAAIAAYagAAAAEDgQvJm0koZkj6fAwXKXQGzqwFnuAG7gPRiMbiIcLQjuKk3zLr07qmy1zOOcA7C+ow==", "5553334444", null, false, "acd32beb-66ba-401f-aa02-c3cf5056c817", false, "ayseyildiz" },
                    { "e7757cac-ae31-482d-be3d-244e6e7dc4c2", 0, "İstanbul", "c6ebcc0a-b031-44f7-8177-2823cab530e7", new DateTime(1992, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "goksu.demir@example.com", true, "Göksu", "Kadın", "Demir", false, null, "GOKSU.DEMIR@EXAMPLE.COM", "GOKSUDEMIR", "AQAAAAIAAYagAAAAEAChrXfxUsj3r/xHqROBVVLTtFdw6yPUOGYnlKJ2JlhumGHzekDOhTvJASVm9XtkVA==", "5554443322", null, false, "782edccc-5f0d-4867-be4a-8f689709646b", false, "goksudemir" },
                    { "e9d470c0-b5e3-461b-bd93-5d4ec41af35a", 0, "Ankara", "46e31c1d-24d2-41c0-b90d-2009d65250a9", new DateTime(1994, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elif.akyildiz@example.com", true, "Elif", "Kadın", "Akyıldız", false, null, "ELIF.AKYILDIZ@EXAMPLE.COM", "ELIFAKYILDIZ", "AQAAAAIAAYagAAAAEDAt9gcBDGPOdkE37pkasJDkye3IgxdQpee5VoU0ghRFlcVG+cvllznkFyduTNz2XQ==", "5558887766", null, false, "ad297081-c10b-4fa5-b7b1-0e4dc904c172", false, "elifakyildiz" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matamatik", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9476), "Matematik Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9483), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9488), "Fizik Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9489), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9491), "Kimya Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9491), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9493), "Biyoloji Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9493), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9495), "Tarih Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9496), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9497), "Coğrafya Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9498), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9499), "İngilizce Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9500), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9502), "Almanca Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9502), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9504), "Fransızca Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9504), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9506), "Felsefe Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9506), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9508), "Müzik Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9509), "muzik" },
                    { 12, "Resim", new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9510), "Resim Dersleri", true, new DateTime(2023, 4, 18, 15, 2, 38, 290, DateTimeKind.Local).AddTicks(9511), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2076), true, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2078), "1.jpg" },
                    { 2, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2080), true, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2081), "2.jpg" },
                    { 3, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2082), true, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2083), "3.jpg" },
                    { 4, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2084), true, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2085), "4.jpg" },
                    { 5, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2086), true, new DateTime(2023, 4, 18, 15, 2, 38, 291, DateTimeKind.Local).AddTicks(2087), "5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "df13404b-0425-4670-ac16-f721b892caac", "0ca225bc-497f-492d-98d1-99e5645fe291" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "1c0f707f-b080-4835-aacb-b749e1d2d4ea" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "237a9294-669f-495f-8aea-c95430561a0b" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "45f36c5a-f362-4769-9567-741154e98f84" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "46bbfa6e-bf2c-4c75-abab-a2ce4fe462c8" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "4f5e1da5-c3c2-4e96-b771-95cc538fdb71" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "656c9e9f-9fb3-4258-973d-7fda59bd19db" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "674ab086-45b0-48cb-8149-cf6c465eab89" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "7177dd61-6c1c-42eb-bcc3-00c5494ecc57" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "72917505-bb15-47fe-b10d-8a4743c66195" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "76363925-9072-4736-915f-ece26aa0dc30" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "79f96167-7589-4d4f-b02d-c4d4105b0230" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "abef7276-b604-4c3c-adb1-2a878d3140be" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "bed72338-361e-4709-a197-e1f6c2c40a77" },
                    { "1ead16a5-50f9-4079-910b-80ac95027684", "ca2d1d35-8476-4b7a-af6e-5d1ef00f32c3" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "d26ac1ff-0492-4827-8d9b-a92f106242f9" },
                    { "df13404b-0425-4670-ac16-f721b892caac", "e2c50181-52b5-4b46-8edf-99199c684e08" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "e7757cac-ae31-482d-be3d-244e6e7dc4c2" },
                    { "9fbddff8-c9c8-4650-b17c-56afaba90b21", "e9d470c0-b5e3-461b-bd93-5d4ec41af35a" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "ImageId", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9725), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9747), null, "d26ac1ff-0492-4827-8d9b-a92f106242f9" },
                    { 2, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9769), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9770), null, "7177dd61-6c1c-42eb-bcc3-00c5494ecc57" },
                    { 3, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9775), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9776), null, "1c0f707f-b080-4835-aacb-b749e1d2d4ea" },
                    { 4, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9781), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9782), null, "abef7276-b604-4c3c-adb1-2a878d3140be" },
                    { 5, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9786), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9787), null, "76363925-9072-4736-915f-ece26aa0dc30" },
                    { 6, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9792), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9794), null, "e2c50181-52b5-4b46-8edf-99199c684e08" },
                    { 7, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9797), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9799), null, "72917505-bb15-47fe-b10d-8a4743c66195" },
                    { 8, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9803), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9804), null, "bed72338-361e-4709-a197-e1f6c2c40a77" },
                    { 9, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9807), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9809), null, "0ca225bc-497f-492d-98d1-99e5645fe291" },
                    { 10, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9814), 5, true, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9816), null, "237a9294-669f-495f-8aea-c95430561a0b" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "ImageId", "IsApproved", "Price", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9977), "Kırıkkale Üniversitesi", 1, true, 300m, new DateTime(2023, 4, 18, 15, 2, 36, 63, DateTimeKind.Local).AddTicks(9979), null, "45f36c5a-f362-4769-9567-741154e98f84" },
                    { 2, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(7), "Orta Doğu Teknik Üniversitesi", 2, true, 400m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(9), null, "79f96167-7589-4d4f-b02d-c4d4105b0230" },
                    { 3, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(15), "İstanbul Teknik Üniversitesi", 3, true, 350m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(16), null, "656c9e9f-9fb3-4258-973d-7fda59bd19db" },
                    { 4, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(21), "Yıldız Teknik Üniversitesi", 4, true, 380m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(23), null, "46bbfa6e-bf2c-4c75-abab-a2ce4fe462c8" },
                    { 5, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(29), "Akdeniz Üniversitesi", 5, true, 320m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(30), null, "674ab086-45b0-48cb-8149-cf6c465eab89" },
                    { 6, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(37), "Erciyes Üniversitesi", 5, true, 400m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(39), null, "4f5e1da5-c3c2-4e96-b771-95cc538fdb71" },
                    { 7, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(44), "Çukurova Üniversitesi", 5, true, 420m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(45), null, "e9d470c0-b5e3-461b-bd93-5d4ec41af35a" },
                    { 8, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(50), "Uludağ Üniversitesi", 5, true, 380m, new DateTime(2023, 4, 18, 15, 2, 36, 64, DateTimeKind.Local).AddTicks(51), null, "e7757cac-ae31-482d-be3d-244e6e7dc4c2" }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ImageId",
                table: "Students",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

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
                column: "UserId");

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
                name: "TeacherBranches");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
