using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59441cdd-e751-49fa-8459-385a0f9a7167",
                column: "ConcurrencyStamp",
                value: "afe6c1c8-1bab-48f1-8284-4077b82f641d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca30d05-5dc6-4a0c-95ed-537048384a1e",
                column: "ConcurrencyStamp",
                value: "f59b8d3d-8e6c-4261-8ec8-20d879adc03c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                column: "ConcurrencyStamp",
                value: "093b13f8-3177-462f-b3e6-42c946abb908");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-4789-9012-3456789abcde",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d12a829-120b-4a32-9fcf-dfe201c2ddf7", new DateOnly(1994, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEJU5pg7Qv4dPEs0ZfCKBJLjL+69vWOsCCjn16e4Rpl70NeMa7DzHtb8qA3Ve9P6saA==", "ebfa0e84-7dc0-40a1-af4b-81110c40bad3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59441cdd-e751-49fa-8459-385a0f9a7167",
                column: "ConcurrencyStamp",
                value: "a3a841f8-232d-49e4-b4ff-1e4bcdc2fc42");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca30d05-5dc6-4a0c-95ed-537048384a1e",
                column: "ConcurrencyStamp",
                value: "39535d6c-9131-4c3b-9c29-f3dc52b27d35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                column: "ConcurrencyStamp",
                value: "912c93e1-5f01-436d-a0f6-ebdc32a71016");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-4789-9012-3456789abcde",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d27ce85-96fe-4001-956a-867ab2696e94", "AQAAAAIAAYagAAAAEM6l5BxIA+BBMDHMwiamq9BJ/yBOF6VxCS5xGlJHDHMFA6dkNlBv+4gQ/W0iAig+qA==", "8208b041-9ff8-4127-a600-14653194832f" });
        }
    }
}
