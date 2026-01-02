using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateToLeaveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59441cdd-e751-49fa-8459-385a0f9a7167",
                column: "ConcurrencyStamp",
                value: "7a4597af-2645-4a1b-ab0b-5763d2a89350");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca30d05-5dc6-4a0c-95ed-537048384a1e",
                column: "ConcurrencyStamp",
                value: "09fb2118-e1ac-45bc-8790-2344ef1cb5fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                column: "ConcurrencyStamp",
                value: "b5c35263-e44a-4997-bdce-e2f312acf12f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-4789-9012-3456789abcde",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "281c4365-426a-405b-9aec-696cec0a419e", "AQAAAAIAAYagAAAAEK0pst5SCECO8Ha4cRAE0uFYxsZRR72anO0MuX4lR81YqzGvW5PeT4OvOKP+dQUYFw==", "8696a930-d337-4fdd-8547-0055c69b57b2" });

            migrationBuilder.InsertData(
                table: "LeaveRequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Cancelled" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequestStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59441cdd-e751-49fa-8459-385a0f9a7167",
                column: "ConcurrencyStamp",
                value: "0fe46269-3153-48a4-b9a2-33573b8b1ac6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca30d05-5dc6-4a0c-95ed-537048384a1e",
                column: "ConcurrencyStamp",
                value: "a3506abd-8cc5-41c4-af0f-0cceabb0a842");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                column: "ConcurrencyStamp",
                value: "1a730b02-f6a0-4abf-bba0-6393f4871b24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-4789-9012-3456789abcde",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8c447bf-71e3-484c-9068-18b306e09b99", "AQAAAAIAAYagAAAAENUAay6wRLLGE6F66fOOhYomS9SsvCuFyc6lsLEmBQsRmi/oU7XfMyO4uHLllG3Wkw==", "639a702d-7f64-425c-a86b-bff9f29cdc2a" });
        }
    }
}
