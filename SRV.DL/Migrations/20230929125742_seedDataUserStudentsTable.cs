using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class seedDataUserStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserStudent",
                columns: new[] { "StudentId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "UserStudent",
                columns: new[] { "StudentId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserStudent",
                columns: new[] { "StudentId", "UserId" },
                values: new object[] { 3, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserStudent",
                keyColumns: new[] { "StudentId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserStudent",
                keyColumns: new[] { "StudentId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserStudent",
                keyColumns: new[] { "StudentId", "UserId" },
                keyValues: new object[] { 3, 1 });
        }
    }
}
