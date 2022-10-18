using System;
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terms = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAcademicTerms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicTermDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    StopDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RefAcademicTermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicTermDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicTermDetails_RefAcademicTerms_RefAcademicTermId",
                        column: x => x.RefAcademicTermId,
                        principalTable: "RefAcademicTerms",
                        principalColumn: "Id");
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
                        principalColumn: "Id");
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
                name: "OfferedCoursesInTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AcademicTermDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferedCoursesInTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferedCoursesInTerms_AcademicTermDetails_AcademicTermDetailId",
                        column: x => x.AcademicTermDetailId,
                        principalTable: "AcademicTermDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferedCoursesInTerms_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<double>(type: "float", nullable: false),
                    OfferedCoursesInTermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_OfferedCoursesInTerms_OfferedCoursesInTermId",
                        column: x => x.OfferedCoursesInTermId,
                        principalTable: "OfferedCoursesInTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicTermDetails_RefAcademicTermId",
                table: "AcademicTermDetails",
                column: "RefAcademicTermId");

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
                name: "IX_EnrolledCourses_OfferedCoursesInTermId",
                table: "EnrolledCourses",
                column: "OfferedCoursesInTermId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourses_StudentId",
                table: "EnrolledCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedCoursesInTerms_AcademicTermDetailId",
                table: "OfferedCoursesInTerms",
                column: "AcademicTermDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferedCoursesInTerms_CourseId",
                table: "OfferedCoursesInTerms",
                column: "CourseId");

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
                name: "OfferedCoursesInTerms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicTermDetails");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "RefAcademicTerms");
        }
    }
}
