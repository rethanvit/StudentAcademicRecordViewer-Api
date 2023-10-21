using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class addQuarterAndUpdateAcademicTermNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Programs_Code",
                table: "Programs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Programs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Programs_Code_Name",
                table: "Programs",
                columns: new[] { "Code", "Name" });

            migrationBuilder.UpdateData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 2,
                column: "Name",
                value: "Bi-Semester");

            migrationBuilder.UpdateData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 3,
                column: "Name",
                value: "Tri-Semester");

            migrationBuilder.InsertData(
                table: "RefAcademicTerms",
                columns: new[] { "AcademicTermId", "Active", "Name", "Terms" },
                values: new object[] { 4, false, "Quarter", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Programs_Code_Name",
                table: "Programs");

            migrationBuilder.DeleteData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Programs_Code",
                table: "Programs",
                column: "Code");

            migrationBuilder.UpdateData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 2,
                column: "Name",
                value: "Semester");

            migrationBuilder.UpdateData(
                table: "RefAcademicTerms",
                keyColumn: "AcademicTermId",
                keyValue: 3,
                column: "Name",
                value: "Quarter");
        }
    }
}
