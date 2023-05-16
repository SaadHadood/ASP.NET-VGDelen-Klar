using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "ebe44bf1-247a-4675-9842-aba29f77084f", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "31010c31-de57-4e50-a5ce-532b0339f071", 0, null, "e47eb1ac-f6f5-4793-a1ca-8cba7ea59d02", "administrator@domain.com", false, "", null, "", false, null, null, null, "AQAAAAIAAYagAAAAEES/S9yuOK+jovECy7TOZ1r4keGDbfw6M0QLebGUqfRRV4yOoc84XbLDW+9g+DgGMQ==", null, false, "07220e96-2f64-47aa-8d4d-fc795e502257", false, "administrator@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ebe44bf1-247a-4675-9842-aba29f77084f", "31010c31-de57-4e50-a5ce-532b0339f071" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ebe44bf1-247a-4675-9842-aba29f77084f", "31010c31-de57-4e50-a5ce-532b0339f071" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe44bf1-247a-4675-9842-aba29f77084f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31010c31-de57-4e50-a5ce-532b0339f071");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d62d223-654f-40e2-94db-71274c5af50e", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de1dfb1d-ac28-4036-a1b0-9c410ba1a576", 0, null, "2bfb4a89-ac42-46d3-93d8-04fb5aa079bc", null, false, "System", null, "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAEKtc2kxPlfvtpX8gHeZY75b9y/C2PlArMWh8tFqbRbtrL0Dspg6VGrklOlTO6qukuQ==", null, false, "3eef57d2-edaf-4e5d-a2c3-f75abd814236", false, "administrator" });
        }
    }
}
