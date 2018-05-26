using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class CourseConfigurationCorretion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Configurations_CurrentConfigurationId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CurrentConfigurationId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationCurriculum_ConfigurationId",
                table: "ConfigurationCurriculum");

            migrationBuilder.DropColumn(
                name: "CurrentConfigurationId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCurriculum_ConfigurationId",
                table: "ConfigurationCurriculum",
                column: "ConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Courses_CourseId",
                table: "Configurations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Courses_CourseId",
                table: "Configurations");

            migrationBuilder.DropIndex(
                name: "IX_Configurations_CourseId",
                table: "Configurations");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationCurriculum_ConfigurationId",
                table: "ConfigurationCurriculum");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentConfigurationId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CurrentConfigurationId",
                table: "Courses",
                column: "CurrentConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCurriculum_ConfigurationId",
                table: "ConfigurationCurriculum",
                column: "ConfigurationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Configurations_CurrentConfigurationId",
                table: "Courses",
                column: "CurrentConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
