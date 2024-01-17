using Microsoft.EntityFrameworkCore.Migrations;

namespace lista10.Migrations
{
    public partial class changedlessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Teacher_TeacherId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_TeacherId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Lesson");

            migrationBuilder.AddColumn<string>(
                name: "SUbjectName",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SUbjectName",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Lesson");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TeacherId",
                table: "Lesson",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Teacher_TeacherId",
                table: "Lesson",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
