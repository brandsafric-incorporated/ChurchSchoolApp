using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations.ApplicationDb
{
    public partial class UpdateAspNetUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordRecoveryRequestedDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordRecoveryToken",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordRecoveryRequestedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordRecoveryToken",
                table: "AspNetUsers");
        }
    }
}
