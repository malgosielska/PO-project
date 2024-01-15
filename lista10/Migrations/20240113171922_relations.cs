using Microsoft.EntityFrameworkCore.Migrations;

namespace lista10.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClassId",
                table: "Schedule",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SubjectId",
                table: "Schedule",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Class_ClassId",
                table: "Schedule",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                table: "Schedule",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Class_ClassId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ClassId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_SubjectId",
                table: "Schedule");
        }
    }
}
