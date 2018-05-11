using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class RemovingNullFromRemovedDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValue: new Guid("3f87908f-8df8-484d-9804-c547bf840e93"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ScholarTerms",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "ScholarTerms",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new Guid("777a9cdc-41f2-4a4b-b1ce-e6ad5fd1e8f8"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Phone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonDocument",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "PersonDocument",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Person",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Person",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("6374a709-fe42-4d07-89fb-52969eda4306"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValue: new Guid("78878d87-ffe0-41ce-ab9e-c1287ec0a50c"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GradeHistory",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "GradeHistory",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new Guid("66c6d983-c5e0-457e-a246-52c0db06f29a"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Frequencies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Frequencies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValue: new Guid("b2f11f3a-d95e-4360-9bf5-c0ee5197305c"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Enrollments",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Enrollments",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: new Guid("1566b070-6b33-45a5-8f87-d187cfd424fc"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Email",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Email",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Curriculums",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Curriculums",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValue: new Guid("2a0a45f8-8f90-404b-8cff-df768012ea72"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Curriculum_Subject",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Curriculum_Subject",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValue: new Guid("e2de9a75-dd22-41ea-8f72-2c69ceba706b"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("a32bee79-c7ba-4ae0-a821-92b3e8fd2c28"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "CourseClass_Subject",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "CourseClass_Subject",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValue: new Guid("7df98b47-9e2f-4929-94de-84dd76fffc72"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "CourseClass_Student",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "CourseClass_Student",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValue: new Guid("9f0e6552-4abb-48c9-aeb0-f568d13a1d2e"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Configurations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Configurations",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValue: new Guid("4d860fff-8b73-4d9b-a2fe-3d37e5b5809c"),
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValue: new Guid("aea5762a-c45d-457d-9aa1-679caf46497e"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Address",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Address",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3f87908f-8df8-484d-9804-c547bf840e93"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ScholarTerms",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "ScholarTerms",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("777a9cdc-41f2-4a4b-b1ce-e6ad5fd1e8f8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Phone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Phone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PersonDocument",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "PersonDocument",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Person",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Person",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("6374a709-fe42-4d07-89fb-52969eda4306"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("78878d87-ffe0-41ce-ab9e-c1287ec0a50c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "GradeHistory",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "GradeHistory",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("66c6d983-c5e0-457e-a246-52c0db06f29a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Frequencies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Frequencies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("b2f11f3a-d95e-4360-9bf5-c0ee5197305c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("1566b070-6b33-45a5-8f87-d187cfd424fc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Email",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Email",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Curriculums",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Curriculums",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("2a0a45f8-8f90-404b-8cff-df768012ea72"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Curriculum_Subject",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Curriculum_Subject",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("e2de9a75-dd22-41ea-8f72-2c69ceba706b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("a32bee79-c7ba-4ae0-a821-92b3e8fd2c28"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "CourseClass_Subject",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "CourseClass_Subject",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("7df98b47-9e2f-4929-94de-84dd76fffc72"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "CourseClass_Student",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "CourseClass_Student",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("9f0e6552-4abb-48c9-aeb0-f568d13a1d2e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Configurations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Configurations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4d860fff-8b73-4d9b-a2fe-3d37e5b5809c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("aea5762a-c45d-457d-9aa1-679caf46497e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Address",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RemovedDate",
                table: "Address",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
