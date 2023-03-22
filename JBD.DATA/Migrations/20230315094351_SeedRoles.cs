using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JBD.DATA.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25205E51-C7F6-43E5-927A-8074AF61B966", "25205E51-C7F6-43E5-927A-8074AF61B966", "Seller", "SELLER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4", "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb76a482-3d73-4e28-9155-581a1a2cbea4", "fb76a482-3d73-4e28-9155-581a1a2cbea4", "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25205E51-C7F6-43E5-927A-8074AF61B966");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb76a482-3d73-4e28-9155-581a1a2cbea4");
        }
    }
}
