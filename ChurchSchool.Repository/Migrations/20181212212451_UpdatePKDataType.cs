using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations
{
    public partial class UpdatePKDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curriculums",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProfileImage = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Sex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CourseId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CourseId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PercentageOfAbsenseByClass = table.Column<int>(nullable: false),
                    LowestGradetoBeApproved = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StreetName = table.Column<string>(type: "varchar(500)", nullable: false),
                    StreetNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(500)", nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    State = table.Column<string>(type: "varchar(2)", nullable: false),
                    Details = table.Column<string>(type: "varchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "varchar(256)", nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DocumentNumber = table.Column<string>(type: "varchar(30)", nullable: false),
                    IssuingEntity = table.Column<string>(type: "varchar(30)", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDocuments_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PersonId = table.Column<long>(nullable: false),
                    AreaCode = table.Column<string>(type: "varchar(4)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EnrollmentID = table.Column<string>(nullable: true),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum_Subject",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurriculumId = table.Column<long>(nullable: true),
                    SubjectId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curriculum_Subject_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curriculum_Subject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<long>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PersonId = table.Column<long>(nullable: false),
                    CourseClassId = table.Column<long>(nullable: false),
                    EnrollmentID = table.Column<string>(type: "varchar(15)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationCurriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ConfigurationId = table.Column<long>(nullable: false),
                    CurriculumId = table.Column<long>(nullable: false),
                    IsCurrentConfiguration = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationCurriculum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationCurriculum_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigurationCurriculum_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CourseConfigurationId = table.Column<long>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                        column: x => x.CourseConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProfessorId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false)
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
                name: "SubjectClass",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProfessorId = table.Column<long>(nullable: false),
                    SubjectId = table.Column<long>(nullable: false),
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
                name: "GradeHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    CurrentGradeId = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CourseClass_Student",
                columns: table => new
                {
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CourseClassId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClass_Student", x => new { x.CourseClassId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseClass_Student_Classes_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseClass_Student_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: true),
                    SubjectId = table.Column<long>(nullable: false),
                    StudentId = table.Column<long>(nullable: false),
                    ProfessorId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frequencies_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Frequencies_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Frequencies_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DocumentNumber = table.Column<string>(type: "varchar(30)", nullable: false),
                    IssuingEntity = table.Column<string>(type: "varchar(30)", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDocuments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectClassStudent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentId = table.Column<long>(nullable: false),
                    SubjectClassId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectClassStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectClassStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SubjectClassStudent_SubjectClass_SubjectClassId",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonId",
                table: "Addresses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCurriculum_ConfigurationId",
                table: "ConfigurationCurriculum",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCurriculum_CurriculumId",
                table: "ConfigurationCurriculum",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_Student_StudentId",
                table: "CourseClass_Student",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDocuments_CourseConfigurationId",
                table: "CourseDocuments",
                column: "CourseConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_CurriculumId",
                table: "Curriculum_Subject",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_SubjectId",
                table: "Curriculum_Subject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_PersonId",
                table: "Emails",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_ProfessorId",
                table: "Frequencies",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_StudentId",
                table: "Frequencies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_SubjectId",
                table: "Frequencies",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeHistory_CurrentGradeId",
                table: "GradeHistory",
                column: "CurrentGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocuments_PersonId",
                table: "PersonDocuments",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PersonId",
                table: "Phone",
                column: "PersonId");

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentDocuments_StudentId",
                table: "StudentDocuments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseClassId",
                table: "Students",
                column: "CourseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonId",
                table: "Students",
                column: "PersonId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ConfigurationCurriculum");

            migrationBuilder.DropTable(
                name: "CourseClass_Student");

            migrationBuilder.DropTable(
                name: "CourseDocuments");

            migrationBuilder.DropTable(
                name: "Curriculum_Subject");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "GradeHistory");

            migrationBuilder.DropTable(
                name: "PersonDocuments");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "ProfessorSubject");

            migrationBuilder.DropTable(
                name: "StudentDocuments");

            migrationBuilder.DropTable(
                name: "SubjectClassStudent");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Curriculums");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectClass");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
