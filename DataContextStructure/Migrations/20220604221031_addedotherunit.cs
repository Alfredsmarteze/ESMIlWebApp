using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class addedotherunit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BibleStudyUnit",
                table: "BibleStudyUnit");

            migrationBuilder.RenameTable(
                name: "BibleStudyUnit",
                newName: "bibleStudyUnit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bibleStudyUnit",
                table: "bibleStudyUnit",
                column: "Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "choralUnit");

            migrationBuilder.DropTable(
                name: "dmeUnit");

            migrationBuilder.DropTable(
                name: "publicityAndEditorialUnit");

            migrationBuilder.DropTable(
                name: "technicalUnit");

            migrationBuilder.DropTable(
                name: "usheringUnit");

            migrationBuilder.DropTable(
                name: "welfareUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bibleStudyUnit",
                table: "bibleStudyUnit");

            migrationBuilder.RenameTable(
                name: "bibleStudyUnit",
                newName: "BibleStudyUnit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BibleStudyUnit",
                table: "BibleStudyUnit",
                column: "Id");
        }
    }
}
