using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class ChangingCourseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Courses_CourseId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Curriculum_Subject_Curriculums_CurriculumId",
                table: "Curriculum_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Curriculum_Subject_Subjects_SubjectId",
                table: "Curriculum_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "IsCurrentConfiguration",
                table: "Configurations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Subjects",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Students",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "StudentDocuments",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ProfessorSubject",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Professors",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Phone",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "PersonDocuments",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "People",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "GradeHistory",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Frequencies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Emails",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculums",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Curriculum_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculum_Subject",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurriculumId",
                table: "Curriculum_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Courses",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseDocuments",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseConfigurationId",
                table: "CourseDocuments",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Student",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Configurations",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Configurations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Configurations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ConfigurationCurriculum",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Classes",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Addresses",
                type: "datetime",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.CreateTable(
                name: "Course_Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    ConfigurationCourseId = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    CourseConfigurationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Subject_Configurations_CourseConfigurationId",
                        column: x => x.CourseConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject_CourseConfigurationId",
                table: "Course_Subject",
                column: "CourseConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Courses_CourseId",
                table: "Configurations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments",
                column: "CourseConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curriculum_Subject_Curriculums_CurriculumId",
                table: "Curriculum_Subject",
                column: "CurriculumId",
                principalTable: "Curriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curriculum_Subject_Subjects_SubjectId",
                table: "Curriculum_Subject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Courses_CourseId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_Curriculum_Subject_Curriculums_CurriculumId",
                table: "Curriculum_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Curriculum_Subject_Subjects_SubjectId",
                table: "Curriculum_Subject");

            migrationBuilder.DropTable(
                name: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Configurations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Subjects",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Students",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "StudentDocuments",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ProfessorSubject",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Professors",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Phone",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "PersonDocuments",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "People",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "GradeHistory",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Frequencies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Emails",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculums",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Curriculum_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculum_Subject",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurriculumId",
                table: "Curriculum_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Courses",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseDocuments",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseConfigurationId",
                table: "CourseDocuments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Student",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Configurations",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Configurations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentConfiguration",
                table: "Configurations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ConfigurationCurriculum",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Classes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Addresses",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Courses_CourseId",
                table: "Configurations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments",
                column: "CourseConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curriculum_Subject_Curriculums_CurriculumId",
                table: "Curriculum_Subject",
                column: "CurriculumId",
                principalTable: "Curriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curriculum_Subject_Subjects_SubjectId",
                table: "Curriculum_Subject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
