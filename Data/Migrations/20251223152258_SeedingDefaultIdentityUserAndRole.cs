using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultIdentityUserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59441cdd-e751-49fa-8459-385a0f9a7167", "a3a841f8-232d-49e4-b4ff-1e4bcdc2fc42", "Employee", "EMPLOYEE" },
                    { "8ca30d05-5dc6-4a0c-95ed-537048384a1e", "39535d6c-9131-4c3b-9c29-f3dc52b27d35", "Supervisor", "SUPERVISOR" },
                    { "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b", "912c93e1-5f01-436d-a0f6-ebdc32a71016", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1b2c3d4-e5f6-4789-9012-3456789abcde", 0, "2d27ce85-96fe-4001-956a-867ab2696e94", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEM6l5BxIA+BBMDHMwiamq9BJ/yBOF6VxCS5xGlJHDHMFA6dkNlBv+4gQ/W0iAig+qA==", null, false, "8208b041-9ff8-4127-a600-14653194832f", false, "test@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b", "a1b2c3d4-e5f6-4789-9012-3456789abcde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59441cdd-e751-49fa-8459-385a0f9a7167");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca30d05-5dc6-4a0c-95ed-537048384a1e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b", "a1b2c3d4-e5f6-4789-9012-3456789abcde" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-4789-9012-3456789abcde");
        }
    }
}
