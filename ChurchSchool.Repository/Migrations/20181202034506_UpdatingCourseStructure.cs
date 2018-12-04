using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class UpdatingCourseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Course_Subject_Course_SubjectId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Professors_ProfessorId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "Course_Subject");

            migrationBuilder.DropIndex(
                name: "IX_Classes_Course_SubjectId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Course_SubjectId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "LowestGradetoBeApproved",
                table: "Configurations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PercentageOfAbsenseByClass",
                table: "Configurations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Classes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Classes",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Classes",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CourseId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "LowestGradetoBeApproved",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "PercentageOfAbsenseByClass",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Course_SubjectId",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Classes",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course_Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ConfigurationCourseId = table.Column<Guid>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Subject_Configurations_ConfigurationCourseId",
                        column: x => x.ConfigurationCourseId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Subject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Course_SubjectId",
                table: "Classes",
                column: "Course_SubjectId",
                unique: true,
                filter: "[Course_SubjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject_ConfigurationCourseId",
                table: "Course_Subject",
                column: "ConfigurationCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject_SubjectId",
                table: "Course_Subject",
                column: "SubjectId");

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
        }
    }
}
