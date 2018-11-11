using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class ChangingCourseClassStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Curriculum_Subject_Curriculum_SubjectId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Professors_ProfessorId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Configurations_CourseConfigurationId",
                table: "Course_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Subjects_SubjectId",
                table: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Course_Subject_CourseConfigurationId",
                table: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Curriculum_SubjectId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CourseConfigurationId",
                table: "Course_Subject");

            migrationBuilder.DropColumn(
                name: "Curriculum_SubjectId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Courses",
                newName: "IsActive");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Course_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Course_Subject",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConfigurationCourseId",
                table: "Course_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Course_Subject",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Course_SubjectId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject_ConfigurationCourseId",
                table: "Course_Subject",
                column: "ConfigurationCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Course_SubjectId",
                table: "Classes",
                column: "Course_SubjectId",
                unique: true,
                filter: "[Course_SubjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Course_Subject_Course_SubjectId",
                table: "Classes",
                column: "Course_SubjectId",
                principalTable: "Course_Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Professors_ProfessorId",
                table: "Classes",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Course_Subject_Course_SubjectId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Professors_ProfessorId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Subjects_ConfigurationCourseId",
                table: "Course_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_Configurations_SubjectId",
                table: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Course_Subject_ConfigurationCourseId",
                table: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Course_SubjectId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Course_SubjectId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Courses",
                newName: "isActive");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Course_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Course_Subject",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConfigurationCourseId",
                table: "Course_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Course_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseConfigurationId",
                table: "Course_Subject",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Curriculum_SubjectId",
                table: "Classes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject_CourseConfigurationId",
                table: "Course_Subject",
                column: "CourseConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Curriculum_SubjectId",
                table: "Classes",
                column: "Curriculum_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Curriculum_Subject_Curriculum_SubjectId",
                table: "Classes",
                column: "Curriculum_SubjectId",
                principalTable: "Curriculum_Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Professors_ProfessorId",
                table: "Classes",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_Configurations_CourseConfigurationId",
                table: "Course_Subject",
                column: "CourseConfigurationId",
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
    }
}
