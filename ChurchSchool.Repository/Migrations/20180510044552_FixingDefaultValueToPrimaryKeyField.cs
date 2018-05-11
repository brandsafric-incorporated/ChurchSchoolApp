using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class FixingDefaultValueToPrimaryKeyField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("e1639d82-8734-4e51-8552-3832409fa33a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("70009968-85b7-4aad-9684-6154d6070c88"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3667b75b-8e66-4895-966b-702f6aad02bb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("a70a6923-90fd-4ce9-8c3f-f220a2c019c5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("cd193f0a-06f1-4963-a632-2d0fd61f6ecd"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("d324557b-e224-48dc-a81f-6d97765038ce"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("fcf1c87f-e6ec-433d-9fb3-c9b4e1a816f0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8f9cf6fd-38a7-4691-8818-b0836a852107"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("8869f3e4-0359-4e31-9721-ab585e012b35"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c84b4c5e-ffdd-458a-9219-aac5ae52b65b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("6bdb4c26-0de4-4578-8fcc-516fd7d5ec21"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("cfe541f3-2339-4ca2-9bfd-59d504381e5c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("646e3ba1-541f-4a80-a143-10261531c996"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValue: new Guid("794c439d-e9be-4207-9f6e-9658bb09041d"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                nullable: false,
                defaultValue: new Guid("e1639d82-8734-4e51-8552-3832409fa33a"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScholarTerms",
                nullable: false,
                defaultValue: new Guid("70009968-85b7-4aad-9684-6154d6070c88"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("3667b75b-8e66-4895-966b-702f6aad02bb"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Grades",
                nullable: false,
                defaultValue: new Guid("a70a6923-90fd-4ce9-8c3f-f220a2c019c5"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GradeHistory",
                nullable: false,
                defaultValue: new Guid("cd193f0a-06f1-4963-a632-2d0fd61f6ecd"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Frequencies",
                nullable: true,
                defaultValue: new Guid("d324557b-e224-48dc-a81f-6d97765038ce"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: new Guid("fcf1c87f-e6ec-433d-9fb3-c9b4e1a816f0"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculums",
                nullable: false,
                defaultValue: new Guid("8f9cf6fd-38a7-4691-8818-b0836a852107"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Curriculum_Subject",
                nullable: true,
                defaultValue: new Guid("8869f3e4-0359-4e31-9721-ab585e012b35"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("c84b4c5e-ffdd-458a-9219-aac5ae52b65b"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Subject",
                nullable: true,
                defaultValue: new Guid("6bdb4c26-0de4-4578-8fcc-516fd7d5ec21"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CourseClass_Student",
                nullable: true,
                defaultValue: new Guid("cfe541f3-2339-4ca2-9bfd-59d504381e5c"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Configurations",
                nullable: false,
                defaultValue: new Guid("646e3ba1-541f-4a80-a143-10261531c996"),
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                nullable: true,
                defaultValue: new Guid("794c439d-e9be-4207-9f6e-9658bb09041d"),
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "NEWID()");
        }
    }
}
