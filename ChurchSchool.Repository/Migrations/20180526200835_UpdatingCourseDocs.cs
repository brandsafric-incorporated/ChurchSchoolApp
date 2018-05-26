using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class UpdatingCourseDocs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseConfigurationId",
                table: "CourseDocuments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments",
                column: "CourseConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseConfigurationId",
                table: "CourseDocuments",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDocuments_Configurations_CourseConfigurationId",
                table: "CourseDocuments",
                column: "CourseConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
