using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class addAltKeyToStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Students_StudentId_ProgramId_AcademicCalendarDetailStartId",
                table: "Students",
                columns: new[] { "StudentId", "ProgramId", "AcademicCalendarDetailStartId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Students_StudentId_ProgramId_AcademicCalendarDetailStartId",
                table: "Students");
        }
    }
}
