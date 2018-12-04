using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class AddSubjectClassStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Students",
                newName: "CourseClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                newName: "IX_Students_CourseClassId");

            migrationBuilder.CreateTable(
                name: "SubjectClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectClass_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectClass_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectClassStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentId = table.Column<Guid>(nullable: false),
                    SubjectClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectClassStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectClassStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectClassStudent_SubjectClass_SubjectClassId",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClass_ProfessorId",
                table: "SubjectClass",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClass_SubjectId",
                table: "SubjectClass",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClassStudent_StudentId",
                table: "SubjectClassStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClassStudent_SubjectClassId",
                table: "SubjectClassStudent",
                column: "SubjectClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_CourseClassId",
                table: "Students",
                column: "CourseClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_CourseClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "SubjectClassStudent");

            migrationBuilder.DropTable(
                name: "SubjectClass");

            migrationBuilder.RenameColumn(
                name: "CourseClassId",
                table: "Students",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseClassId",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
