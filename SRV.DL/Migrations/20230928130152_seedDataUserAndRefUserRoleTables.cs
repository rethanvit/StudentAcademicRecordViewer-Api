using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRV.DL.Migrations
{
    public partial class seedDataUserAndRefUserRoleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RefUserRoles",
                columns: new[] { "UserRoleCode", "UserRoleName" },
                values: new object[] { "ADMN", "Adminstrator" });

            migrationBuilder.InsertData(
                table: "RefUserRoles",
                columns: new[] { "UserRoleCode", "UserRoleName" },
                values: new object[] { "PROC", "Proctor" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ProgramId", "UserFirstName", "UserLastName", "UserRoleCode", "Username" },
                values: new object[] { 1, 2, "proc1Fname", "proc1Lname", "PROC", "proc1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ProgramId", "UserFirstName", "UserLastName", "UserRoleCode", "Username" },
                values: new object[] { 2, 3, "proc2Fname", "proc2Lname", "PROC", "proc2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ProgramId", "UserFirstName", "UserLastName", "UserRoleCode", "Username" },
                values: new object[] { 3, 2, "admin1Fname", "admin1Lname", "ADMN", "admin1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RefUserRoles",
                keyColumn: "UserRoleCode",
                keyValue: "ADMN");

            migrationBuilder.DeleteData(
                table: "RefUserRoles",
                keyColumn: "UserRoleCode",
                keyValue: "PROC");
        }
    }
}
