using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class FixingDefaultToInsertDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Subjects",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 452, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValue: new Guid("e1639d82-8734-4e51-8552-3832409fa33a"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("4dc15545-5eab-4d4d-b842-5c5071696498"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ScholarTerms",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 444, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new Guid("70009968-85b7-4aad-9684-6154d6070c88"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("85b7034c-6311-4c7a-98e9-645016943a31"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Person",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 447, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("3667b75b-8e66-4895-966b-702f6aad02bb"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c1c13381-b94a-4ed0-9b4b-d9ea1cf31c75"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Grades",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 434, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValue: new Guid("a70a6923-90fd-4ce9-8c3f-f220a2c019c5"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c6cf87f5-a362-439a-afb1-a5bb3ee9e633"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "GradeHistory",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 436, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new Guid("cd193f0a-06f1-4963-a632-2d0fd61f6ecd"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8d44d48b-3a29-469d-9d9b-1ed83bdc1900"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Frequencies",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 429, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValue: new Guid("d324557b-e224-48dc-a81f-6d97765038ce"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("d49fb2cd-813f-4bac-acc9-1d59ed4ccae4"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Enrollments",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 425, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: new Guid("fcf1c87f-e6ec-433d-9fb3-c9b4e1a816f0"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c7333907-9365-459f-b6ff-74b7a3309421"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculums",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 412, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValue: new Guid("8f9cf6fd-38a7-4691-8818-b0836a852107"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("6c7ade85-3d26-4063-a5a5-ec0f6ce7e7a5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculum_Subject",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 419, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValue: new Guid("8869f3e4-0359-4e31-9721-ab585e012b35"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("c795f497-5801-462d-a0c9-345a6aad7997"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Courses",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 383, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("c84b4c5e-ffdd-458a-9219-aac5ae52b65b"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("29f6ca48-64d9-488c-aa0e-0ccfcbbce3c9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Subject",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 406, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValue: new Guid("6bdb4c26-0de4-4578-8fcc-516fd7d5ec21"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("3fe71458-ff24-4b00-9968-fb7316fe39cf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Student",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 397, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValue: new Guid("cfe541f3-2339-4ca2-9bfd-59d504381e5c"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("8b1e09c2-731c-4a5c-ac4c-911fd042b6ed"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Configurations",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 408, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValue: new Guid("646e3ba1-541f-4a80-a143-10261531c996"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("d65442ef-b633-46a7-aae5-5fb06c9be1ce"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Classes",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 390, DateTimeKind.Local));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValue: new Guid("794c439d-e9be-4207-9f6e-9658bb09041d"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("2ba86fb7-4dea-4cc9-be40-7ab152394c40"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 452, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValue: new Guid("4dc15545-5eab-4d4d-b842-5c5071696498"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("e1639d82-8734-4e51-8552-3832409fa33a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 444, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new Guid("85b7034c-6311-4c7a-98e9-645016943a31"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("70009968-85b7-4aad-9684-6154d6070c88"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Person",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 447, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("c1c13381-b94a-4ed0-9b4b-d9ea1cf31c75"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3667b75b-8e66-4895-966b-702f6aad02bb"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Grades",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 434, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValue: new Guid("c6cf87f5-a362-439a-afb1-a5bb3ee9e633"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("a70a6923-90fd-4ce9-8c3f-f220a2c019c5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 436, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new Guid("8d44d48b-3a29-469d-9d9b-1ed83bdc1900"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("cd193f0a-06f1-4963-a632-2d0fd61f6ecd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Frequencies",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 429, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValue: new Guid("d49fb2cd-813f-4bac-acc9-1d59ed4ccae4"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("d324557b-e224-48dc-a81f-6d97765038ce"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Enrollments",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 425, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: new Guid("c7333907-9365-459f-b6ff-74b7a3309421"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("fcf1c87f-e6ec-433d-9fb3-c9b4e1a816f0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculums",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 412, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValue: new Guid("6c7ade85-3d26-4063-a5a5-ec0f6ce7e7a5"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8f9cf6fd-38a7-4691-8818-b0836a852107"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Curriculum_Subject",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 419, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValue: new Guid("c795f497-5801-462d-a0c9-345a6aad7997"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("8869f3e4-0359-4e31-9721-ab585e012b35"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 383, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("29f6ca48-64d9-488c-aa0e-0ccfcbbce3c9"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c84b4c5e-ffdd-458a-9219-aac5ae52b65b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Subject",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 406, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValue: new Guid("3fe71458-ff24-4b00-9968-fb7316fe39cf"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("6bdb4c26-0de4-4578-8fcc-516fd7d5ec21"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "CourseClass_Student",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 397, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValue: new Guid("8b1e09c2-731c-4a5c-ac4c-911fd042b6ed"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("cfe541f3-2339-4ca2-9bfd-59d504381e5c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Configurations",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 408, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValue: new Guid("d65442ef-b633-46a7-aae5-5fb06c9be1ce"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("646e3ba1-541f-4a80-a143-10261531c996"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertedDate",
                table: "Classes",
                nullable: false,
                defaultValue: new DateTime(2018, 5, 10, 1, 34, 52, 390, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValue: new Guid("2ba86fb7-4dea-4cc9-be40-7ab152394c40"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("794c439d-e9be-4207-9f6e-9658bb09041d"));
        }
    }
}
