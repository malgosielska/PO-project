using Microsoft.EntityFrameworkCore.Migrations;

namespace lista10.Migrations
{
    public partial class changedlessons2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SUbjectName",
                table: "Lesson",
                newName: "SubjectName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Lesson",
                newName: "SUbjectName");
        }
    }
}
