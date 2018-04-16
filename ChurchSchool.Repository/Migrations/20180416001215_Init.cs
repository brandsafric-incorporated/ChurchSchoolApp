using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curriculums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScholarTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseConfiguration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    CurriculumId = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    IsCurrentConfiguration = table.Column<bool>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseConfiguration_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    EmailId = table.Column<Guid>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    EmailId = table.Column<Guid>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ScholarTermId = table.Column<Guid>(nullable: false),
                    CurriculumId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => new { x.ScholarTermId, x.CurriculumId });
                    table.ForeignKey(
                        name: "FK_Classes_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_ScholarTerms_ScholarTermId",
                        column: x => x.ScholarTermId,
                        principalTable: "ScholarTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum_Subject",
                columns: table => new
                {
                    CurriculumId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum_Subject", x => new { x.CurriculumId, x.SubjectId });
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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseConfigurationId = table.Column<Guid>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseConfiguration_CourseConfigurationId",
                        column: x => x.CourseConfigurationId,
                        principalTable: "CourseConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    Neighborhood = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AreaCode = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseClass_Subject",
                columns: table => new
                {
                    CourseClassId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RelatedClassCurriculumId = table.Column<Guid>(nullable: true),
                    RelatedClassScholarTermId = table.Column<Guid>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClass_Subject", x => new { x.CourseClassId, x.SubjectId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_CourseClass_Subject_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseClass_Subject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseClass_Subject_Classes_RelatedClassScholarTermId_RelatedClassCurriculumId",
                        columns: x => new { x.RelatedClassScholarTermId, x.RelatedClassCurriculumId },
                        principalTable: "Classes",
                        principalColumns: new[] { "ScholarTermId", "CurriculumId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseClass_Student",
                columns: table => new
                {
                    CourseClassId = table.Column<Guid>(nullable: false),
                    EnrolledStudentId = table.Column<Guid>(nullable: false),
                    EnrollmentId = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RelatedClassCurriculumId = table.Column<Guid>(nullable: true),
                    RelatedClassScholarTermId = table.Column<Guid>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClass_Student", x => new { x.CourseClassId, x.EnrolledStudentId });
                    table.ForeignKey(
                        name: "FK_CourseClass_Student_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseClass_Student_Classes_RelatedClassScholarTermId_RelatedClassCurriculumId",
                        columns: x => new { x.RelatedClassScholarTermId, x.RelatedClassCurriculumId },
                        principalTable: "Classes",
                        principalColumns: new[] { "ScholarTermId", "CurriculumId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    ScholarTermId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false),
                    EnrollmentId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => new { x.ScholarTermId, x.SubjectId, x.EnrollmentId });
                    table.ForeignKey(
                        name: "FK_Frequencies_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frequencies_ScholarTerms_ScholarTermId",
                        column: x => x.ScholarTermId,
                        principalTable: "ScholarTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frequencies_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EnrollmentId = table.Column<Guid>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    ScholarTermId = table.Column<Guid>(nullable: true),
                    SubjectId = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_ScholarTerms_ScholarTermId",
                        column: x => x.ScholarTermId,
                        principalTable: "ScholarTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentGradeId = table.Column<Guid>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeHistory_Grades_CurrentGradeId",
                        column: x => x.CurrentGradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProfessorId",
                table: "Address",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CurriculumId",
                table: "Classes",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Student_EnrollmentId",
                table: "CourseClass_Student",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Student_RelatedClassScholarTermId_RelatedClassCurriculumId",
                table: "CourseClass_Student",
                columns: new[] { "RelatedClassScholarTermId", "RelatedClassCurriculumId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Subject_ProfessorId",
                table: "CourseClass_Subject",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Subject_SubjectId",
                table: "CourseClass_Subject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Subject_RelatedClassScholarTermId_RelatedClassCurriculumId",
                table: "CourseClass_Subject",
                columns: new[] { "RelatedClassScholarTermId", "RelatedClassCurriculumId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseConfiguration_CurriculumId",
                table: "CourseConfiguration",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseConfigurationId",
                table: "Courses",
                column: "CourseConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_SubjectId",
                table: "Curriculum_Subject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_EnrollmentId",
                table: "Frequencies",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_SubjectId",
                table: "Frequencies",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeHistory_CurrentGradeId",
                table: "GradeHistory",
                column: "CurrentGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EnrollmentId",
                table: "Grades",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ScholarTermId",
                table: "Grades",
                column: "ScholarTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ProfessorId",
                table: "Phone",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_StudentId",
                table: "Phone",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_EmailId",
                table: "Professors",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EmailId",
                table: "Students",
                column: "EmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CourseClass_Student");

            migrationBuilder.DropTable(
                name: "CourseClass_Subject");

            migrationBuilder.DropTable(
                name: "Curriculum_Subject");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "GradeHistory");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "ScholarTerms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "CourseConfiguration");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Curriculums");
        }
    }
}
