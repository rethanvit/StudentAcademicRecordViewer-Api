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
                columns: new[] { "Id", "Active", "Name", "StartDate", "StopDate" },
                values: new object[] { 1, true, "LLC School of Business", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                table: "Departments",
                columns: new[] { "Id", "AcademicTermId", "Active", "Code", "MaxMarks", "MinMarks", "Name", "OrganizationId", "StartDate", "StopDate" },
                values: new object[] { 1, 1, true, "BUS", 100, 40, "School of Business", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RefAcademicCalendars",
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
                table: "Courses",
                columns: new[] { "Id", "Active", "Code", "DepartmentId", "Name", "OrganizationId", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, true, "MBA", 1, "Masters in Business Administration", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "ACC", 1, "Masters in Accounts", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, "FIN", 1, "Masters in Finanace", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName", "OrganizationId", "StartDate", "StopDate" },
                values: new object[,]
                {
                    { 1, 1, "Johnny", "Patty", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Alia", "Thomson", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2079, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EnrolledCourses",
                columns: new[] { "Id", "AcademicCalendarDetailId", "CourseId", "Marks", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1, 45.0, 1 },
                    { 2, 2, 1, 45.0, 1 },
                    { 3, 2, 2, 45.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "OfferedCourses",
                columns: new[] { "Id", "AcademicCalendarDetailId", "CourseId" },
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
                table: "EnrolledCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EnrolledCourses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OfferedCourses",
                keyColumn: "Id",
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
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RefAcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RefAcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RefAcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RefAcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RefAcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RefAcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 2);
        }
    }
}
