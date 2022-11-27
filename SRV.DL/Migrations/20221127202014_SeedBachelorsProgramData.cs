using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class SeedBachelorsProgramData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "AcademicTermId", "Active", "Code", "DepartmentId", "Name" },
                values: new object[] { 3, 3, true, "BCS", 2, "Bachelors in Computer Science" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Active", "Code", "Level", "Name", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 6, true, "FJ", 101, "Fundamental Java", 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Active", "Code", "Level", "Name", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 7, true, "AJ", 101, "Advanced Java", 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AcademicCalendarDetailStartId", "FirstName", "LastName", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 3, 8, "Benny", "Johns", 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId" },
                values: new object[,]
                {
                    { 4, 6 },
                    { 5, 6 },
                    { 6, 6 },
                    { 10, 6 },
                    { 11, 6 },
                    { 12, 6 },
                    { 16, 6 },
                    { 17, 6 },
                    { 18, 6 },
                    { 10, 7 },
                    { 11, 7 },
                    { 12, 7 },
                    { 16, 7 },
                    { 17, 7 },
                    { 18, 7 }
                });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId", "Marks" },
                values: new object[] { 10, 6, 3, 45.0 });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId", "Marks" },
                values: new object[] { 11, 7, 3, 45.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 10, 6, 3 });

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 11, 7, 3 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 17, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 18, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 16, 7 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 18, 7 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId" },
                values: new object[] { 15, 5 });
        }
    }
}
