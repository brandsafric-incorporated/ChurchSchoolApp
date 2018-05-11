using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class AddingDefaultToInsertDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 452, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValue: new Guid("4dc15545-5eab-4d4d-b842-5c5071696498"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3f87908f-8df8-484d-9804-c547bf840e93"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 444, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new Guid("85b7034c-6311-4c7a-98e9-645016943a31"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("777a9cdc-41f2-4a4b-b1ce-e6ad5fd1e8f8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 447, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("c1c13381-b94a-4ed0-9b4b-d9ea1cf31c75"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("6374a709-fe42-4d07-89fb-52969eda4306"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Grades",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 434, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValue: new Guid("c6cf87f5-a362-439a-afb1-a5bb3ee9e633"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("78878d87-ffe0-41ce-ab9e-c1287ec0a50c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 436, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new Guid("8d44d48b-3a29-469d-9d9b-1ed83bdc1900"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("66c6d983-c5e0-457e-a246-52c0db06f29a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Frequencies",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 429, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValue: new Guid("d49fb2cd-813f-4bac-acc9-1d59ed4ccae4"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("b2f11f3a-d95e-4360-9bf5-c0ee5197305c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Enrollments",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 425, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: new Guid("c7333907-9365-459f-b6ff-74b7a3309421"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("1566b070-6b33-45a5-8f87-d187cfd424fc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculums",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 412, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValue: new Guid("6c7ade85-3d26-4063-a5a5-ec0f6ce7e7a5"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("2a0a45f8-8f90-404b-8cff-df768012ea72"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculum_Subject",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 419, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValue: new Guid("c795f497-5801-462d-a0c9-345a6aad7997"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("e2de9a75-dd22-41ea-8f72-2c69ceba706b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 383, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("29f6ca48-64d9-488c-aa0e-0ccfcbbce3c9"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("a32bee79-c7ba-4ae0-a821-92b3e8fd2c28"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Subject",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 406, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValue: new Guid("3fe71458-ff24-4b00-9968-fb7316fe39cf"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("7df98b47-9e2f-4929-94de-84dd76fffc72"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Student",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 397, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValue: new Guid("8b1e09c2-731c-4a5c-ac4c-911fd042b6ed"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("9f0e6552-4abb-48c9-aeb0-f568d13a1d2e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Configurations",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 408, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValue: new Guid("d65442ef-b633-46a7-aae5-5fb06c9be1ce"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4d860fff-8b73-4d9b-a2fe-3d37e5b5809c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 390, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValue: new Guid("2ba86fb7-4dea-4cc9-be40-7ab152394c40"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("aea5762a-c45d-457d-9aa1-679caf46497e"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 452, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValue: new Guid("3f87908f-8df8-484d-9804-c547bf840e93"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4dc15545-5eab-4d4d-b842-5c5071696498"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ScholarTerms",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 444, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new Guid("777a9cdc-41f2-4a4b-b1ce-e6ad5fd1e8f8"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("85b7034c-6311-4c7a-98e9-645016943a31"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Person",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 447, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("6374a709-fe42-4d07-89fb-52969eda4306"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c1c13381-b94a-4ed0-9b4b-d9ea1cf31c75"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 434, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValue: new Guid("78878d87-ffe0-41ce-ab9e-c1287ec0a50c"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c6cf87f5-a362-439a-afb1-a5bb3ee9e633"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "GradeHistory",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 436, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new Guid("66c6d983-c5e0-457e-a246-52c0db06f29a"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8d44d48b-3a29-469d-9d9b-1ed83bdc1900"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Frequencies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 429, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValue: new Guid("b2f11f3a-d95e-4360-9bf5-c0ee5197305c"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("d49fb2cd-813f-4bac-acc9-1d59ed4ccae4"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 425, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: new Guid("1566b070-6b33-45a5-8f87-d187cfd424fc"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c7333907-9365-459f-b6ff-74b7a3309421"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculums",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 412, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValue: new Guid("2a0a45f8-8f90-404b-8cff-df768012ea72"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("6c7ade85-3d26-4063-a5a5-ec0f6ce7e7a5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculum_Subject",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 419, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValue: new Guid("e2de9a75-dd22-41ea-8f72-2c69ceba706b"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("c795f497-5801-462d-a0c9-345a6aad7997"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 383, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("a32bee79-c7ba-4ae0-a821-92b3e8fd2c28"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("29f6ca48-64d9-488c-aa0e-0ccfcbbce3c9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Subject",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 406, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValue: new Guid("7df98b47-9e2f-4929-94de-84dd76fffc72"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("3fe71458-ff24-4b00-9968-fb7316fe39cf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Student",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 397, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValue: new Guid("9f0e6552-4abb-48c9-aeb0-f568d13a1d2e"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("8b1e09c2-731c-4a5c-ac4c-911fd042b6ed"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Configurations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 408, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValue: new Guid("4d860fff-8b73-4d9b-a2fe-3d37e5b5809c"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("d65442ef-b633-46a7-aae5-5fb06c9be1ce"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 390, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValue: new Guid("aea5762a-c45d-457d-9aa1-679caf46497e"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("2ba86fb7-4dea-4cc9-be40-7ab152394c40"));
        }
    }
}
