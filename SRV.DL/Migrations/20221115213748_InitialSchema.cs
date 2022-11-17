using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StopDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefAcademicTerms",
                columns: table => new
                {
                    AcademicTermId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terms = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAcademicTerms", x => x.AcademicTermId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StopDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    AcademicTermId = table.Column<int>(type: "int", nullable: false),
                    MaxMarks = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    MinMarks = table.Column<int>(type: "int", nullable: false, defaultValue: 40),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_RefAcademicTerms_AcademicTermId",
                        column: x => x.AcademicTermId,
                        principalTable: "RefAcademicTerms",
                        principalColumn: "AcademicTermId");
                });

            migrationBuilder.CreateTable(
                name: "RefAcademicCalendars",
                columns: table => new
                {
                    AcademicCalendarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicTermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAcademicCalendars", x => x.AcademicCalendarId);
                    table.ForeignKey(
                        name: "FK_RefAcademicCalendars_RefAcademicTerms_AcademicTermId",
                        column: x => x.AcademicTermId,
                        principalTable: "RefAcademicTerms",
                        principalColumn: "AcademicTermId");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StopDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StopDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademicCalendarDetails",
                columns: table => new
                {
                    AcademicCalendarDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StopDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    AcademicCalendarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicCalendarDetails", x => x.AcademicCalendarDetailId);
                    table.ForeignKey(
                        name: "FK_AcademicCalendarDetails_RefAcademicCalendars_AcademicCalendarId",
                        column: x => x.AcademicCalendarId,
                        principalTable: "RefAcademicCalendars",
                        principalColumn: "AcademicCalendarId");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<double>(type: "float", nullable: false),
                    AcademicCalendarDetailId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_AcademicCalendarDetails_AcademicCalendarDetailId",
                        column: x => x.AcademicCalendarDetailId,
                        principalTable: "AcademicCalendarDetails",
                        principalColumn: "AcademicCalendarDetailId");
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferedCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AcademicCalendarDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferedCourses_AcademicCalendarDetails_AcademicCalendarDetailId",
                        column: x => x.AcademicCalendarDetailId,
                        principalTable: "AcademicCalendarDetails",
                        principalColumn: "AcademicCalendarDetailId");
                    table.ForeignKey(
                        name: "FK_OfferedCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCalendarDetails_AcademicCalendarId",
                table: "AcademicCalendarDetails",
                column: "AcademicCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OrganizationId",
                table: "Courses",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AcademicTermId",
                table: "Departments",
                column: "AcademicTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizationId",
                table: "Departments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_AcademicCalendarDetailId",
                table: "EnrolledCourses",
                column: "AcademicCalendarDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_CourseId",
                table: "EnrolledCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_StudentId",
                table: "EnrolledCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedCourses_AcademicCalendarDetailId",
                table: "OfferedCourses",
                column: "AcademicCalendarDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedCourses_CourseId",
                table: "OfferedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RefAcademicCalendars_AcademicTermId",
                table: "RefAcademicCalendars",
                column: "AcademicTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_OrganizationId",
                table: "Students",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolledCourses");

            migrationBuilder.DropTable(
                name: "OfferedCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicCalendarDetails");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "RefAcademicCalendars");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "RefAcademicTerms");
        }
    }
}
