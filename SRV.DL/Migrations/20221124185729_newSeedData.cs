using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class newSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Active", "Code", "MaxMarks", "MinMarks", "Name", "OrganizationId", "StartDate", "StopDate" },
                values: new object[] { 2, true, "CSE", 100, 40, "School of Computer Science", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationId",
                keyValue: 1,
                column: "Name",
                value: "LLP Institute of Business & Technology");

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "AcademicTermId", "Active", "Code", "DepartmentId", "Name" },
                values: new object[] { 2, 2, true, "MCS", 2, "Masters in Computer Science" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Active", "Code", "Level", "Name", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 4, true, "DS", 101, "Data Structures", 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Active", "Code", "Level", "Name", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 5, true, "OOP", 101, "Object Oriented Prog", 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AcademicCalendarDetailStartId", "FirstName", "LastName", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 2, 8, "Uma", "Putta", 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId" },
                values: new object[] { 8, 4 });

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId" },
                values: new object[] { 9, 5 });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId", "Marks" },
                values: new object[] { 8, 4, 2, 45.0 });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId", "Marks" },
                values: new object[] { 9, 5, 2, 45.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 8, 4, 2 });

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 9, 5, 2 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationId",
                keyValue: 1,
                column: "Name",
                value: "LLP School of Business");
        }
    }
}
