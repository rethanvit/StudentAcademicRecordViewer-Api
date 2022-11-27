using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class seedAdditionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId" },
                values: new object[,]
                {
                    { 2, 4 },
                    { 3, 4 },
                    { 9, 4 },
                    { 14, 4 },
                    { 15, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 8, 5 },
                    { 14, 5 },
                    { 15, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 15, 5 });
        }
    }
}
