using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicSectionDate2",
                table: "pastExecutive");

            migrationBuilder.DropColumn(
                name: "FullAcademicSectionDate",
                table: "pastExecutive");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicSectionDate",
                table: "pastExecutive",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AcademicSectionDate",
                table: "pastExecutive",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AcademicSectionDate2",
                table: "pastExecutive",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FullAcademicSectionDate",
                table: "pastExecutive",
                type: "datetime2",
                nullable: true);
        }
    }
}
