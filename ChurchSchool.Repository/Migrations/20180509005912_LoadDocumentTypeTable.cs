using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Migrations
{
    public partial class LoadDocumentTypeTable : Migration
    {
        private string _documentTypeTable = "DocumentType";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //loading addres type data
            migrationBuilder.InsertData(_documentTypeTable, new string[] { "Id", "Description" }, new object[] { 0, "Não Definido" });
            migrationBuilder.InsertData(_documentTypeTable, new string[] { "Id", "Description" }, new object[] { 1, "CPF" });
            migrationBuilder.InsertData(_documentTypeTable, new string[] { "Id", "Description" }, new object[] { 2, "RG" });
            migrationBuilder.InsertData(_documentTypeTable, new string[] { "Id", "Description" }, new object[] { 3, "Carteira de Trabalho" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {_documentTypeTable};");
        }
    }
}
