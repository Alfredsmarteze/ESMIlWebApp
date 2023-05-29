using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "bibleStudyUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bibleStudyUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "choralUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choralUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dmeUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dmeUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "firstTimer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Othernames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningVisitingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonOfComing = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firstTimer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LgaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loginInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastBibleStudyCordinators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastBibleStudyCordinators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastChoralUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastChoralUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastDMECordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastDMECordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastExecutive",
                columns: table => new
                {
                    EsmafId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcademicSectionDate2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullAcademicSectionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastExecutive", x => x.EsmafId);
                });

            migrationBuilder.CreateTable(
                name: "pastPrayerUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastPrayerUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastPublicityUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastPublicityUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastTechnicalUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastTechnicalUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastTransportUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastTransportUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastUsheringUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastUsheringUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pastWelfareUnitCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastWelfareUnitCordinator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prayerUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prayerUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "publicityAndEditorialUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicityAndEditorialUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "register",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmpassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_register", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "technicalUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technicalUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transportUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usheringUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usheringUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "welfareUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ambition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateJoinESM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HostelAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionInFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_welfareUnit", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "eSMAF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Othernames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfEntry = table.Column<int>(type: "int", nullable: false),
                    YearOfGraduation = table.Column<int>(type: "int", nullable: false),
                    UnitServed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PastId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eSMAF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eSMAF_pastExecutive_PastId",
                        column: x => x.PastId,
                        principalTable: "pastExecutive",
                        principalColumn: "EsmafId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_eSMAF_PastId",
                table: "eSMAF",
                column: "PastId",
                unique: true,
                filter: "[PastId] IS NOT NULL");
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
                name: "bibleStudyUnit");

            migrationBuilder.DropTable(
                name: "choralUnit");

            migrationBuilder.DropTable(
                name: "dmeUnit");

            migrationBuilder.DropTable(
                name: "eSMAF");

            migrationBuilder.DropTable(
                name: "firstTimer");

            migrationBuilder.DropTable(
                name: "lga");

            migrationBuilder.DropTable(
                name: "loginInfo");

            migrationBuilder.DropTable(
                name: "pastBibleStudyCordinators");

            migrationBuilder.DropTable(
                name: "pastChoralUnitCordinator");

            migrationBuilder.DropTable(
                name: "pastDMECordinator");

            migrationBuilder.DropTable(
                name: "pastPrayerUnitCordinator");

            migrationBuilder.DropTable(
                name: "pastPublicityUnitCordinator");

            migrationBuilder.DropTable(
                name: "pastTechnicalUnitCordinator");

            migrationBuilder.DropTable(
                name: "pastTransportUnitCordinator");

            migrationBuilder.DropTable(
                name: "pastUsheringUnitCordinator");

            migrationBuilder.DropTable(
                name: "pastWelfareUnitCordinator");

            migrationBuilder.DropTable(
                name: "prayerUnit");

            migrationBuilder.DropTable(
                name: "publicityAndEditorialUnit");

            migrationBuilder.DropTable(
                name: "register");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "technicalUnit");

            migrationBuilder.DropTable(
                name: "transportUnit");

            migrationBuilder.DropTable(
                name: "usheringUnit");

            migrationBuilder.DropTable(
                name: "welfareUnit");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "pastExecutive");
        }
    }
}
