using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class updateDepartmentsAltKeyToIncludeOrgId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Departments_Code_Name",
                table: "Departments");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Departments_Code_Name_OrganizationId",
                table: "Departments",
                columns: new[] { "Code", "Name", "OrganizationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Departments_Code_Name_OrganizationId",
                table: "Departments");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Departments_Code_Name",
                table: "Departments",
                columns: new[] { "Code", "Name" });
        }
    }
}
