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
                    { "27049112-ce59-4d38-befd-91575888e8a5", null, "Öğretmenler", "Ogretmen", "OGRETMEN" },
                    { "31dc642c-b780-4cfd-a253-fa5bcdb2c574", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", null, "Öğrenciler", "Ogrenci", "OGRENCI" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "28e85c10-3800-4a53-9961-96f4e1f4186c", 0, "Ankara", "21555c75-8040-4d68-9e39-74fa93c1f208", new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@example.com", true, "Ahmet", "Erkek", "Yılmaz", false, null, "AHMET.YILMAZ@EXAMPLE.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEMmQXkbXi+8Qcu8d0+eUZw+bfCYmaBUvd9SWLowKll1CZaEJvb19ZFMNkw1W5PSQNw==", "5551234567", null, false, "9ad0f15b-9a62-4994-bedf-399e84ef3d24", false, "ahmetyilmaz" },
                    { "29d7ab6f-9b07-40a6-9d56-d3df22c4365d", 0, "İstanbul", "fdf7b513-ac36-4060-a56b-5cc3a49df7f9", new DateTime(1998, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetovali1903@gmail.com", true, "Ahmet", "Erkek", "Ovalı", false, null, "AHMETOVALI1903@GMAIL.COM", "AHMETOVALI", "AQAAAAIAAYagAAAAECnZg6/idbLF5Np2jdxQWAvjZhBwgfxe0LdqVGu62sN1tdtCFMwFDCgaAzz5eiR0ZQ==", "5555555555", null, false, "6591ff91-8bb9-4995-b74c-f8ddd20c5176", false, "ahmetovali" },
                    { "2e75a9a7-25d8-4521-91f7-27fd8c9919b6", 0, "İzmir", "e236fb2f-dcbe-42e5-8ae4-c024efb65190", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "selin.ozcan@example.com", true, "Selin", "Kadın", "Özcan", false, null, "SELIN.OZCAN@EXAMPLE.COM", "SELINOZCAN", "AQAAAAIAAYagAAAAEJmOalm/n+3su7c211U3W9/999WJnBl1JXfEffPThPK0QRNWuwN4DMcnRVevFxxkMA==", "5559876543", null, false, "aa1a3972-d661-4e5d-977b-dbfde966b673", false, "selinozcan" },
                    { "2f2c96bb-12de-40e1-9127-4b3617d0f4ad", 0, "İstanbul", "544fc094-edb0-4869-96d3-5d8e134877a8", new DateTime(1992, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "goksu.demir@example.com", true, "Göksu", "Kadın", "Demir", false, null, "GOKSU.DEMIR@EXAMPLE.COM", "GOKSUDEMIR", "AQAAAAIAAYagAAAAEDtmbskNPUKQwwwVQfS7wKb8V2T5fTSiEfr7E7IjnqEluuopN+YTQLBUx3s4e1bzeQ==", "5554443322", null, false, "154f09f9-3d96-4426-b14e-35b633b53994", false, "goksudemir" },
                    { "31e2943c-14c9-42d3-96a0-fd704a964c82", 0, "İzmir", "c149299a-473b-44a0-b1d9-fdc1e85c6727", new DateTime(1991, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildir@example.com", true, "Emre", "Erkek", "Yıldır", false, null, "EMRE.YILDIR@EXAMPLE.COM", "EMREYILDIR", "AQAAAAIAAYagAAAAEPvjgsuMsADoUxCnhSe31x3a+f0tyxzZ69zzBACxeu4902IHx5v++coWqSagKs1u9Q==", "5558887744", null, false, "f5d715f3-cc77-4ccb-b7ea-2612958bade1", false, "emreyildir" },
                    { "3ca65c7c-ca6a-49d0-b00d-70b475e5979c", 0, "Antalya", "ec213b02-ea46-463b-8778-986ac136a077", new DateTime(1990, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.kaya@example.com", true, "Mehmet", "Erkek", "Kaya", false, null, "MEHMET.KAYA@EXAMPLE.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAEJr8XmO81vNScFkultyApXkFKSyxcKVcxa9vzIB+bBiaZoBQmsZtTjNYPqejA+QASw==", "5551112233", null, false, "6b063368-4f00-4711-8bf7-5b5a7d0dd9b8", false, "mehmetkaya" },
                    { "475f90ef-58eb-4859-82a8-6f0ae71eac16", 0, "İzmir", "358ae5b7-cfd8-4c2d-9ec9-72d9b8e530b6", new DateTime(1997, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.can@example.com", true, "Murat", "Erkek", "Can", false, null, "MURAT.CAN@EXAMPLE.COM", "MURATCAN", "AQAAAAIAAYagAAAAEJV5TNgXtO9OD76sA8bwdypsM6/j66GWxM4FYU5EtMx1RwZnlkf6nWvC21ubCznQpA==", "5556667788", null, false, "11443373-6525-46b2-94e0-9b73acc521ce", false, "muratcan" },
                    { "4b3ccc9e-7a5e-4cf5-8955-e705047afdfe", 0, "Antalya", "47744209-81ad-4273-a8cc-02f6907c8ede", new DateTime(1985, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebru.ozturk@example.com", true, "Ebru", "Kadın", "Öztürk", false, null, "EBRU.OZTURK@EXAMPLE.COM", "EBRUOZTURK", "AQAAAAIAAYagAAAAEEq81MHvJUxdBQazhmQVEbAIFvKsQIDRnhgLcghhAiErOB7xBQAIwkGJMeFRXddi1A==", "5552221133", null, false, "40a6ac50-19d0-44b3-9910-6a9f209143dd", false, "ebruozturk" },
                    { "4c9f733d-222e-4384-a9b0-b04e63e53280", 0, "İstanbul", "0f706797-80cd-4cc3-959d-3f5ab204e871", new DateTime(1988, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin.demir@example.com", true, "Aylin", "Kadın", "Demir", false, null, "AYLIN.DEMIR@EXAMPLE.COM", "AYLINDEMIR", "AQAAAAIAAYagAAAAEDbqctN6I4FncxJzV5BLXiKuDA0RDxpKuJ623SNQpPn7z510MAMm6Z92ZnYas6aVnQ==", "5557779900", null, false, "477aa8f5-26e3-4466-b020-b68b3728fdf0", false, "aylindemir" },
                    { "57252b05-f93d-4ff6-8f44-428f7575a032", 0, "Ankara", "8d3eff63-42ca-474b-9c7c-1d242dfa9c7c", new DateTime(1999, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "umut.celik@example.com", true, "Umut", "Erkek", "Çelik", false, null, "UMUT.CELIK@EXAMPLE.COM", "UMUTCELIK", "AQAAAAIAAYagAAAAEIvWv/8AxTBxdqy2BnUX0f7nbpbAkjF/vBi+wwHSfPKD2WpQf2JF3IYJhiYZbEArIA==", "5552223344", null, false, "534d5cc4-6e58-488a-ab2d-f5e0f08d1f21", false, "umutcelik" },
                    { "66b89ddf-f1e2-4254-aad9-b6e5534bc1e6", 0, "Ankara", "95e9fb11-c34c-4bae-b3e7-b95c3d61d65d", new DateTime(1987, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mert.kilic@example.com", true, "Mert", "Erkek", "Kılıç", false, null, "MERT.KILIC@EXAMPLE.COM", "MERTKILIC", "AQAAAAIAAYagAAAAEDH3xhz5Z7m9sMwsesa+B9VnRjgE6O9+yAj8PsUuFKYcEAF2iAD7vzy3hseQ0+ADIg==", "5551112233", null, false, "efbdd84f-828c-4b15-af10-a2d8ee1b2ffc", false, "mertkilic" },
                    { "6b84c195-30c2-4e06-98cb-f6e5665264eb", 0, "Ankara", "8db3f7ac-8504-4e29-ada9-552849df940a", new DateTime(1991, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.yildiz@example.com", true, "Ayşe", "Kadın", "Yıldız", false, null, "AYSE.YILDIZ@EXAMPLE.COM", "AYSEYILDIZ", "AQAAAAIAAYagAAAAEEf8fveM7UAb8XNC5OYzHInw28sqOYE0NcnB6YIdhw2UITqAt1VM7+Aqdgi/K3ksuQ==", "5553334444", null, false, "f92dd67a-d88b-4d48-84c5-20ed1a5a3fef", false, "ayseyildiz" },
                    { "76ebe4bc-a654-4efc-8ec1-6eff31f247d9", 0, "Ankara", "84238209-3218-47de-8221-e4ec5aa4dba9", new DateTime(1994, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elif.akyildiz@example.com", true, "Elif", "Kadın", "Akyıldız", false, null, "ELIF.AKYILDIZ@EXAMPLE.COM", "ELIFAKYILDIZ", "AQAAAAIAAYagAAAAEJFk44nASTtREdE5DkSpRAnWtEAxHzPHGJW9/8PCMWSmxo2UwtmkTUn7v7ZYq/OxWw==", "5558887766", null, false, "4077a8a8-0f62-4b57-b26c-c6f819412159", false, "elifakyildiz" },
                    { "86af69bf-cc78-4264-870a-49137c75556c", 0, "Adana", "581e4aa3-53ae-4a07-bfa0-ad38527d76a7", new DateTime(1996, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.guler@example.com", true, "Ali", "Erkek", "Güler", false, null, "ALI.GULER@EXAMPLE.COM", "ALIGULER", "AQAAAAIAAYagAAAAEFyIfPrifjEEeo/ZZkrAMvzyc27U4k8JN/v7i+E10cmKSW5tRlMd2ch2mp89El/yzA==", "5557778899", null, false, "25b21c5e-2e7a-49fb-84c6-eb3bb4625fbd", false, "aliguler" },
                    { "89415615-faeb-4a23-ba99-76f1099866d7", 0, "Ankara", "1b888ff3-b044-43ac-8036-ae45a4e6f24f", new DateTime(1985, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildiz@example.com", true, "Emre", "Erkek", "Yıldız", false, null, "EMRE.YILDIZ@EXAMPLE.COM", "EMREYILDIZ", null, "5301234567", null, false, "f18e5856-6b9d-4764-8022-4e55027ce78a", false, "emreyildiz" },
                    { "89d7b0eb-69b6-4941-a414-4fd4df08456c", 0, "Bursa", "ff17353c-b871-4cf4-8fc8-e263e2a39306", new DateTime(1994, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "asli.yilmaz@example.com", true, "Aslı", "Kadın", "Yılmaz", false, null, "ASLI.YILMAZ@EXAMPLE.COM", "ASLIYILMAZ", "AQAAAAIAAYagAAAAENzUQO8RbLgC6FA0F+/nQcOgDn+3Nd2YjoyP2INxqY5Bxb1JHuyQZ4esFzmm7zNJ1A==", "5555556677", null, false, "144d0b59-851f-4c91-9e57-8120bb180bf7", false, "asliyilmaz" },
                    { "94c61502-2554-4b39-9bf1-f7854310337c", 0, "İstanbul", "7f16b922-ea00-4ee5-9487-4ac78e6b86c8", new DateTime(1992, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "hatice.aydin@example.com", true, "Hatice", "Kadın", "Aydın", false, null, "HATICE.AYDIN@EXAMPLE.COM", "HATICEAYDIN", "AQAAAAIAAYagAAAAED6a2DVTjrH/Z91dLv/2kP6WrzuPismL0NoUxLZqgptQzI0MniDOUiQsaJw4jDLyog==", "5551234567", null, false, "f966768b-3b4a-475e-b658-81ee4c4a203b", false, "haticeaydin" },
                    { "a187f91d-c6b3-4041-aae2-dbba299ffc44", 0, "İzmir", "a7e13458-daf3-4817-befb-b64b34f5a74f", new DateTime(1980, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ercan.ozturk@example.com", true, "Ercan", "Erkek", "Öztürk", false, null, "ERCAN.OZTURK@EXAMPLE.COM", "ERCANOZTURK", "AQAAAAIAAYagAAAAEGO2g+R6lp1haWli8MNP+GdOsjuM9RIUqkQB69NT109x+6+aCNrIOHQXB7HwmdGErA==", "5552223344", null, false, "fefd629c-de62-45ee-a4b0-9ad5a989a16a", false, "ercanozturk" },
                    { "d15d36c0-f706-4323-aa37-74024adb3291", 0, "Bursa", "8fb3baa5-8b9b-4a80-b6dc-7020a5c13779", new DateTime(1998, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "seda.dogan@example.com", true, "Seda", "Kadın", "Doğan", false, null, "SEDA.DOGAN@EXAMPLE.COM", "SEDADOGAN", "AQAAAAIAAYagAAAAEEjowSiyRdJO3aQUViS9/PgsqV3u1zAY6k1WR36SJL2wBG+YJOR5/pO8gE7T9vTV4w==", "5554445566", null, false, "6de90389-2ac4-4c12-9e77-45864b034962", false, "sedadogan" },
                    { "f3639403-467a-4c34-88bd-c855ca583925", 0, "İstanbul", "673cddc9-abb3-4001-b2eb-4def20277844", new DateTime(1985, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.gunes@example.com", true, "Murat", "Erkek", "Güneş", false, null, "MURAT.GUNES@EXAMPLE.COM", "MURATGUNES", "AQAAAAIAAYagAAAAEM+dRcl7jGUjyv7cWDNl/MDCrreoIWuLmF5YzxDkrh6AhjeKYZppZaz3SBdx1juD7Q==", "5558889999", null, false, "e6f8a8d2-4b9c-4e1b-b27f-e9307b07504c", false, "muratgunes" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matamatik", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4145), "Matematik Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4153), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4157), "Fizik Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4158), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4160), "Kimya Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4160), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4162), "Biyoloji Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4162), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4163), "Tarih Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4164), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4165), "Coğrafya Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4166), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4167), "İngilizce Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4167), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4169), "Almanca Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4169), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4170), "Fransızca Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4171), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4172), "Felsefe Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4172), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4174), "Müzik Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4174), "muzik" },
                    { 12, "Resim", new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4176), "Resim Dersleri", true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(4176), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6290), true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6292), "1.jpg" },
                    { 2, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6294), true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6294), "2.jpg" },
                    { 3, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6296), true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6296), "3.jpg" },
                    { 4, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6297), true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6298), "4.jpg" },
                    { 5, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6299), true, new DateTime(2023, 4, 28, 16, 19, 15, 763, DateTimeKind.Local).AddTicks(6299), "5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "28e85c10-3800-4a53-9961-96f4e1f4186c" },
                    { "31dc642c-b780-4cfd-a253-fa5bcdb2c574", "29d7ab6f-9b07-40a6-9d56-d3df22c4365d" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "2e75a9a7-25d8-4521-91f7-27fd8c9919b6" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "2f2c96bb-12de-40e1-9127-4b3617d0f4ad" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "31e2943c-14c9-42d3-96a0-fd704a964c82" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "3ca65c7c-ca6a-49d0-b00d-70b475e5979c" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "475f90ef-58eb-4859-82a8-6f0ae71eac16" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "4b3ccc9e-7a5e-4cf5-8955-e705047afdfe" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "4c9f733d-222e-4384-a9b0-b04e63e53280" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "57252b05-f93d-4ff6-8f44-428f7575a032" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "66b89ddf-f1e2-4254-aad9-b6e5534bc1e6" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "6b84c195-30c2-4e06-98cb-f6e5665264eb" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "76ebe4bc-a654-4efc-8ec1-6eff31f247d9" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "86af69bf-cc78-4264-870a-49137c75556c" },
                    { "27049112-ce59-4d38-befd-91575888e8a5", "89d7b0eb-69b6-4941-a414-4fd4df08456c" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "94c61502-2554-4b39-9bf1-f7854310337c" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "a187f91d-c6b3-4041-aae2-dbba299ffc44" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "d15d36c0-f706-4323-aa37-74024adb3291" },
                    { "80108e5d-aa70-42f2-ab65-c38208c28a8b", "f3639403-467a-4c34-88bd-c855ca583925" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "ImageId", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9811), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9830), null, "28e85c10-3800-4a53-9961-96f4e1f4186c" },
                    { 2, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9852), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9853), null, "2e75a9a7-25d8-4521-91f7-27fd8c9919b6" },
                    { 3, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9858), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9859), null, "3ca65c7c-ca6a-49d0-b00d-70b475e5979c" },
                    { 4, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9863), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9864), null, "d15d36c0-f706-4323-aa37-74024adb3291" },
                    { 5, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9869), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9871), null, "f3639403-467a-4c34-88bd-c855ca583925" },
                    { 6, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9875), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9877), null, "6b84c195-30c2-4e06-98cb-f6e5665264eb" },
                    { 7, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9880), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9881), null, "a187f91d-c6b3-4041-aae2-dbba299ffc44" },
                    { 8, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9885), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9886), null, "86af69bf-cc78-4264-870a-49137c75556c" },
                    { 9, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9889), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9890), null, "94c61502-2554-4b39-9bf1-f7854310337c" },
                    { 10, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9896), 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 908, DateTimeKind.Local).AddTicks(9897), null, "66b89ddf-f1e2-4254-aad9-b6e5534bc1e6" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "ImageId", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(5), "Kırıkkale Üniversitesi", 1, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(7), null, "89d7b0eb-69b6-4941-a414-4fd4df08456c" },
                    { 2, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(36), "Orta Doğu Teknik Üniversitesi", 2, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(38), null, "31e2943c-14c9-42d3-96a0-fd704a964c82" },
                    { 3, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(42), "İstanbul Teknik Üniversitesi", 3, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(43), null, "4b3ccc9e-7a5e-4cf5-8955-e705047afdfe" },
                    { 4, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(47), "Yıldız Teknik Üniversitesi", 4, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(48), null, "57252b05-f93d-4ff6-8f44-428f7575a032" },
                    { 5, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(52), "Akdeniz Üniversitesi", 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(53), null, "4c9f733d-222e-4384-a9b0-b04e63e53280" },
                    { 6, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(59), "Erciyes Üniversitesi", 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(60), null, "475f90ef-58eb-4859-82a8-6f0ae71eac16" },
                    { 7, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(64), "Çukurova Üniversitesi", 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(65), null, "76ebe4bc-a654-4efc-8ec1-6eff31f247d9" },
                    { 8, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(69), "Uludağ Üniversitesi", 5, true, new DateTime(2023, 4, 28, 16, 19, 13, 909, DateTimeKind.Local).AddTicks(70), null, "2f2c96bb-12de-40e1-9127-4b3617d0f4ad" }
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
