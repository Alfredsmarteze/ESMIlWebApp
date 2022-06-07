using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class AddedOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
