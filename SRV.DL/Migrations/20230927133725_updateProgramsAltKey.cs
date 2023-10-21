using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class updateProgramsAltKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Programs_Code_Name",
                table: "Programs");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Programs_Code_Name_DepartmentId",
                table: "Programs",
                columns: new[] { "Code", "Name", "DepartmentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Programs_Code_Name_DepartmentId",
                table: "Programs");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Programs_Code_Name",
                table: "Programs",
                columns: new[] { "Code", "Name" });
        }
    }
}
