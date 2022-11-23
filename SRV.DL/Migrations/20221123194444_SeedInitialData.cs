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
                values: new object[] { 1, true, "LLP School of Business", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "DepartmentId", "Active", "Code", "MaxMarks", "MinMarks", "Name", "OrganizationId", "StartDate", "StopDate" },
                values: new object[] { 1, true, "BUS", 100, 40, "School of Business", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                    { 6, 6, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2020 },
                    { 7, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2021 },
                    { 8, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2021 },
                    { 9, 3, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2021 },
                    { 10, 4, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2021 },
                    { 11, 5, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2021 },
                    { 12, 6, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2021 },
                    { 13, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 14, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 15, 3, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 16, 4, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 17, 5, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 },
                    { 18, 6, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022 }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "AcademicTermId", "Active", "Code", "DepartmentId", "Name" },
                values: new object[] { 1, 1, true, "MBA", 1, "Masters in Business Administration" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Active", "Code", "Level", "Name", "ProgramId", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, true, "BA", 101, "Business Administration", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "ACC", 101, "Accounts", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, "FIN", 101, "Finance", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AcademicCalendarDetailStartId", "FirstName", "LastName", "ProgramId", "StartDate", "StopDate" },
                values: new object[] { 1, 7, "Johnny", "Patty", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 1 },
                    { 13, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 13, 3 }
                });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId", "Marks" },
                values: new object[,]
                {
                    { 1, 1, 1, 45.0 },
                    { 7, 1, 1, 45.0 },
                    { 13, 1, 1, 45.0 },
                    { 7, 2, 1, 45.0 },
                    { 13, 3, 1, 45.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 2);

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
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 7, 1, 1 });

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 13, 1, 1 });

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 7, 2, 1 });

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId", "StudentId" },
                keyValues: new object[] { 13, 3, 1 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
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
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumns: new[] { "AcademicCalendarDetailId", "CourseId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AcademicCalendarDetails",
                keyColumn: "AcademicCalendarDetailId",
                keyValue: 13);

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
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "OrganizationId",
                keyValue: 1);
        }
    }
}
