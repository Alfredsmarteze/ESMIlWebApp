using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class addedAmbitionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ambition",
                table: "bibleStudyUnit",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ambition",
                table: "bibleStudyUnit");
        }
    }
}
