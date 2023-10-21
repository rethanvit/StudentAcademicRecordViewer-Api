using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class addAcademicCalendarsForQuarterSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AcademicCalendars",
                columns: new[] { "AcademicCalendarId", "AcademicTermId", "Name" },
                values: new object[,]
                {
                    { 7, 4, "Fall" },
                    { 8, 4, "Winter" },
                    { 9, 4, "Spring" },
                    { 10, 4, "Summer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AcademicCalendars",
                keyColumn: "AcademicCalendarId",
                keyValue: 10);
        }
    }
}
