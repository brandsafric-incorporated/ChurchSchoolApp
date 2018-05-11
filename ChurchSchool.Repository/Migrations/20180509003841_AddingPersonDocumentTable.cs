using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class AddingPersonDocumentTable : Migration
    {
        private string _documentTypeTable = "DocumentType";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "PersonDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DocumentNumber = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IssuingDate = table.Column<DateTime>(nullable: false),
                    IssuingEntity = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: true),
                    RemovedDate = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDocument_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonDocument_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocument_ProfessorId",
                table: "PersonDocument",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocument_StudentId",
                table: "PersonDocument",
                column: "StudentId");

            migrationBuilder.CreateTable(
                name: _documentTypeTable,
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false),
                     Description = table.Column<string>(type: "varchar(20)", nullable: false)
                 },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonDocument");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.DropTable(_documentTypeTable);
        }
    }
}
