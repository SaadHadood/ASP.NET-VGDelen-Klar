using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad953421-8569-4497-bbb5-aa99f468c02f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d62d223-654f-40e2-94db-71274c5af50e", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de1dfb1d-ac28-4036-a1b0-9c410ba1a576", 0, null, "2bfb4a89-ac42-46d3-93d8-04fb5aa079bc", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAEKtc2kxPlfvtpX8gHeZY75b9y/C2PlArMWh8tFqbRbtrL0Dspg6VGrklOlTO6qukuQ==", null, false, "3eef57d2-edaf-4e5d-a2c3-f75abd814236", false, "administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d62d223-654f-40e2-94db-71274c5af50e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de1dfb1d-ac28-4036-a1b0-9c410ba1a576");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad953421-8569-4497-bbb5-aa99f468c02f", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }
    }
}
