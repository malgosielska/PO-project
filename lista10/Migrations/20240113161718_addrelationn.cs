using Microsoft.EntityFrameworkCore.Migrations;

namespace lista10.Migrations
{
    public partial class addrelationn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectId",
                table: "Teacher",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Subject_SubjectId",
                table: "Teacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Subject_SubjectId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_SubjectId",
                table: "Teacher");
        }
    }
}
