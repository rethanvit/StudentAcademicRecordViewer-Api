using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationId", "Active", "Name", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, true, "LLP School of Business", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "LLC School of Engineering", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RefAcademicTerms",
                columns: new[] { "AcademicTermId", "Active", "Name", "Terms" },
                values: new object[,]
                {
                    { 1, true, "Annual", 1 },
                    { 2, false, "Semester", 2 },
                    { 3, false, "Quarter", 3 }
                });

            migrationBuilder.InsertData(
                table: "AcademicCalendars",
                columns: new[] { "AcademicCalendarId", "AcademicTermId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Annual" },
                    { 2, 2, "Spring" },
                    { 3, 2, "Fall" },
                    { 4, 3, "Spring" },
                    { 5, 3, "Summer" },
                    { 6, 3, "Fall" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "AcademicTermId", "Active", "Code", "MaxMarks", "MinMarks", "Name", "OrganizationId", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, 1, true, "BUS", 100, 40, "School of Business", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, true, "ENG", 75, 40, "School of Computer Science", 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AcademicCalendarDetails",
                columns: new[] { "AcademicCalendarDetailId", "AcademicCalendarId", "StartDate", "StopDate", "Year" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 },
                    { 2, 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 },
                    { 3, 3, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 },
                    { 4, 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 },
                    { 5, 5, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 },
                    { 6, 6, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "Active", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, true, 1, "Masters in Business Administration" },
                    { 2, true, 2, "Masters in Computer Science" },
                    { 3, true, 2, "Bachelors in Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Active", "Code", "Name", "ProgramId", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, true, "MBA", "Business Administration 101", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "ACC", "Accounts 101", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, "FIN", "Finance 101", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, true, "CSE", "Data Structures", 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "LastName", "ProgramId", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, "Johnny", "Patty", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Alia", "Thomson", 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "EnrolledCourseId", "AcademicCalendarDetailId", "CourseId", "Marks", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1, 45.0, 1 },
                    { 2, 2, 1, 45.0, 1 },
                    { 3, 2, 2, 45.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "OfferedCourseId", "AcademicCalendarDetailId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumn: "EnrolledCourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumn: "EnrolledCourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumn: "EnrolledCourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumn: "OfferedCourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumn: "OfferedCourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumn: "OfferedCourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "OrganizationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "OrganizationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 1);
        }
    }
}
