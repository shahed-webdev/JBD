using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JBD.DATA.Migrations
{
    public partial class SeedSuperAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "A0456563-F978-4135-B563-97F23EA02FDA", 0, "A0456563-F978-4135-B563-97F23EA02FDA", "Authority@gmail.com", true, true, null, "AUTHORITY@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEFNGVSDhfcIWurTyD2d+eBrlztC0qkgQxaaTa7Rp/SOKmPyAQ5PdTS9cA65TWg7j6w==", null, false, "dd6f3199-3ee1-458b-bcb8-445dfe36460e", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "UserRegistration",
                columns: new[] { "UserRegistrationId", "Address", "Email", "Name", "Phone", "Type", "UserName" },
                values: new object[] { 1, null, null, "Super Admin", null, "SuperAdmin", "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb76a482-3d73-4e28-9155-581a1a2cbea4", "A0456563-F978-4135-B563-97F23EA02FDA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb76a482-3d73-4e28-9155-581a1a2cbea4", "A0456563-F978-4135-B563-97F23EA02FDA" });

            migrationBuilder.DeleteData(
                table: "UserRegistration",
                keyColumn: "UserRegistrationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA");
        }
    }
}
