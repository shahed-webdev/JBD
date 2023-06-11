using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JBD.DATA.Migrations
{
    public partial class CreateExcludeKeywordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcludeKeyword",
                columns: table => new
                {
                    ExcludeKeywordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRegistrationId = table.Column<int>(type: "int", nullable: false),
                    KeywordType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludeKeyword", x => x.ExcludeKeywordId);
                    table.ForeignKey(
                        name: "FK_ExcludeKeyword_UserRegistration_UserRegistrationId",
                        column: x => x.UserRegistrationId,
                        principalTable: "UserRegistration",
                        principalColumn: "UserRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcludeKeyword_UserRegistrationId",
                table: "ExcludeKeyword",
                column: "UserRegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcludeKeyword");

        }
    }
}
