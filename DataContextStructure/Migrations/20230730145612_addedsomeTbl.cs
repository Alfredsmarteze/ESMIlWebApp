using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContextStructure.Migrations
{
    public partial class addedsomeTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "pastExecutive",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "pastExecutive",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "brotherCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsmafId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brotherCordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_brotherCordinator_eSMAF_EsmafId",
                        column: x => x.EsmafId,
                        principalTable: "eSMAF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sisterCordinator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurnameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OthernameExcos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicSectionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsmafId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sisterCordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sisterCordinator_eSMAF_EsmafId",
                        column: x => x.EsmafId,
                        principalTable: "eSMAF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brotherCordinator_EsmafId",
                table: "brotherCordinator",
                column: "EsmafId");

            migrationBuilder.CreateIndex(
                name: "IX_sisterCordinator_EsmafId",
                table: "sisterCordinator",
                column: "EsmafId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brotherCordinator");

            migrationBuilder.DropTable(
                name: "sisterCordinator");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "pastExecutive");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "pastExecutive");
        }
    }
}
