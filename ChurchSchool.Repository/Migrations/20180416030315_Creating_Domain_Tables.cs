using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class Creating_Domain_Tables : Migration
    {
        private string _addressTypeTable = "AddressType";
        private string _sexTable = "Sex";
        private string _enrollmentStatusTable = "EnrollmentStatus";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: _sexTable,
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStatus", x => x.Id);
                });


            //loading sex information
            migrationBuilder.InsertData(_sexTable, new string[] { "Id", "Description" }, new object[] { 0, "Não Definido" });
            migrationBuilder.InsertData(_sexTable, new string[] { "Id", "Description" }, new object[] { 1, "Masculino" });
            migrationBuilder.InsertData(_sexTable, new string[] { "Id", "Description" }, new object[] { 2, "Feminino" });

            //loading addres type data
            migrationBuilder.InsertData(_addressTypeTable, new string[] { "Id", "Description" }, new object[] { 0, "Não Definido" });
            migrationBuilder.InsertData(_addressTypeTable, new string[] { "Id", "Description" }, new object[] { 1, "Casa" });
            migrationBuilder.InsertData(_addressTypeTable, new string[] { "Id", "Description" }, new object[] { 2, "Trabalho" });

            //loading enrollment status
            migrationBuilder.InsertData(_enrollmentStatusTable, new string[] { "Id", "Description" }, new object[] { 0, "Não Definido" });
            migrationBuilder.InsertData(_enrollmentStatusTable, new string[] { "Id", "Description" }, new object[] { 1, "Ativo" });
            migrationBuilder.InsertData(_enrollmentStatusTable, new string[] { "Id", "Description" }, new object[] { 2, "Suspenso" });
            migrationBuilder.InsertData(_enrollmentStatusTable, new string[] { "Id", "Description" }, new object[] { 3, "Cancelado" });
            migrationBuilder.InsertData(_enrollmentStatusTable, new string[] { "Id", "Description" }, new object[] { 4, "Concluído" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Sex");
            migrationBuilder.DropTable("AddressType");
            migrationBuilder.DropTable("EnrollmentStatus");
        }
    }
}
