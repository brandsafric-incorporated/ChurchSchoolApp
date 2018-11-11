using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class FixingCourseSubjectMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Subjects_ConfigurationCourseId",
                table: "Course_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Configurations_SubjectId",
                table: "Course_Subject");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Course_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ConfigurationCourseId",
                table: "Course_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_Configurations_ConfigurationCourseId",
                table: "Course_Subject",
                column: "ConfigurationCourseId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Course_Subject_Configurations_ConfigurationCourseId",
                table: "Course_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Subjects_SubjectId",
                table: "Course_Subject");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Course_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConfigurationCourseId",
                table: "Course_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_Subjects_ConfigurationCourseId",
                table: "Course_Subject",
                column: "ConfigurationCourseId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_Configurations_SubjectId",
                table: "Course_Subject",
                column: "SubjectId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
