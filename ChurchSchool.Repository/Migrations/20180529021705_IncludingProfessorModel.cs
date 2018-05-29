using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class IncludingProfessorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curriculum_Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurriculumId = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curriculum_Subject_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculum_Subject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    EnrollmentID = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    PersonId = table.Column<Guid>(nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ClassName = table.Column<string>(nullable: true),
                    Curriculum_SubjectId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Curriculum_Subject_Curriculum_SubjectId",
                        column: x => x.Curriculum_SubjectId,
                        principalTable: "Curriculum_Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseClass_Student",
                columns: table => new
                {
                    CourseClassId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClass_Student", x => new { x.CourseClassId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseClass_Student_Classes_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseClass_Student_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Curriculum_SubjectId",
                table: "Classes",
                column: "Curriculum_SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ProfessorId",
                table: "Classes",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Student_StudentId",
                table: "CourseClass_Student",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_CurriculumId",
                table: "Curriculum_Subject",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_SubjectId",
                table: "Curriculum_Subject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_PersonId",
                table: "Professors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_ProfessorId",
                table: "ProfessorSubject",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_SubjectId",
                table: "ProfessorSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseClass_Student");

            migrationBuilder.DropTable(
                name: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Curriculum_Subject");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
