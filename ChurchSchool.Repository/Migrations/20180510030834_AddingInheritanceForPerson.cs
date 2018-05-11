using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class AddingInheritanceForPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Professors_ProfessorId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseClass_Subject_Professors_ProfessorId",
                table: "CourseClass_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseConfiguration_Curriculums_CurriculumId",
                table: "CourseConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseConfiguration_CourseConfigurationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDocument_Professors_ProfessorId",
                table: "PersonDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDocument_Students_StudentId",
                table: "PersonDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Professors_ProfessorId",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Students_StudentId",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Email_EmailId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Phone_ProfessorId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_PersonDocument_ProfessorId",
                table: "PersonDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseConfiguration",
                table: "CourseConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_Address_ProfessorId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "PersonDocument");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "CourseConfiguration",
                newName: "Configurations");

            migrationBuilder.RenameIndex(
                name: "IX_Students_EmailId",
                table: "Person",
                newName: "IX_Person_EmailId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Phone",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_StudentId",
                table: "Phone",
                newName: "IX_Phone_PersonId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "PersonDocument",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocument_StudentId",
                table: "PersonDocument",
                newName: "IX_PersonDocument_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseConfiguration_CurriculumId",
                table: "Configurations",
                newName: "IX_Configurations_CurriculumId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Address",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                newName: "IX_Address_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configurations",
                table: "Configurations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Curriculums_CurriculumId",
                table: "Configurations",
                column: "CurriculumId",
                principalTable: "Curriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseClass_Subject_Person_ProfessorId",
                table: "CourseClass_Subject",
                column: "ProfessorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Configurations_CourseConfigurationId",
                table: "Courses",
                column: "CourseConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Person_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Email_EmailId",
                table: "Person",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDocument_Person_PersonId",
                table: "PersonDocument",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Person_PersonId",
                table: "Phone",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Curriculums_CurriculumId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseClass_Subject_Person_ProfessorId",
                table: "CourseClass_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Configurations_CourseConfigurationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Person_StudentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Email_EmailId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDocument_Person_PersonId",
                table: "PersonDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Person_PersonId",
                table: "Phone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configurations",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Configurations",
                newName: "CourseConfiguration");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Phone",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_PersonId",
                table: "Phone",
                newName: "IX_Phone_StudentId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonDocument",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonDocument_PersonId",
                table: "PersonDocument",
                newName: "IX_PersonDocument_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_EmailId",
                table: "Students",
                newName: "IX_Students_EmailId");

            migrationBuilder.RenameIndex(
                name: "IX_Configurations_CurriculumId",
                table: "CourseConfiguration",
                newName: "IX_CourseConfiguration_CurriculumId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Address",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                newName: "IX_Address_StudentId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Phone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "PersonDocument",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessorId",
                table: "Address",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseConfiguration",
                table: "CourseConfiguration",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ProfessorId",
                table: "Phone",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocument_ProfessorId",
                table: "PersonDocument",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProfessorId",
                table: "Address",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_EmailId",
                table: "Professors",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Professors_ProfessorId",
                table: "Address",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseClass_Subject_Professors_ProfessorId",
                table: "CourseClass_Subject",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseConfiguration_Curriculums_CurriculumId",
                table: "CourseConfiguration",
                column: "CurriculumId",
                principalTable: "Curriculums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseConfiguration_CourseConfigurationId",
                table: "Courses",
                column: "CourseConfigurationId",
                principalTable: "CourseConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDocument_Professors_ProfessorId",
                table: "PersonDocument",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDocument_Students_StudentId",
                table: "PersonDocument",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Professors_ProfessorId",
                table: "Phone",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Students_StudentId",
                table: "Phone",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Email_EmailId",
                table: "Students",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
