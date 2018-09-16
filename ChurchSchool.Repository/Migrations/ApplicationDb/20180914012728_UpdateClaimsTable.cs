using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchSchool.Repository.Migrations.ApplicationDb
{
    public partial class UpdateClaimsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayValue",
                table: "AspNetUserClaims",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayValue",
                table: "AspNetUserClaims");
        }
    }
}
