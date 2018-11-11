using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class VinculatingSubjectToCourseSetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject_SubjectId",
                table: "Course_Subject",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_Subjects_SubjectId",
                table: "Course_Subject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Subjects_SubjectId",
                table: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Course_Subject_SubjectId",
                table: "Course_Subject");
        }
    }
}
