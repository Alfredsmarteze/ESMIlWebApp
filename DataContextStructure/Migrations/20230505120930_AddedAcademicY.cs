using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class AddedAcademicY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicSessionDate",
                table: "eSMAF",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcademicSessionDate2",
                table: "eSMAF",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicSessionDate",
                table: "eSMAF");

            migrationBuilder.DropColumn(
                name: "AcademicSessionDate2",
                table: "eSMAF");
        }
    }
}
