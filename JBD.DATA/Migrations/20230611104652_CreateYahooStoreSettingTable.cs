using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JBD.DATA.Migrations
{
    public partial class CreateYahooStoreSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YahooStoreSetting",
                columns: table => new
                {
                    YahooStoreSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRegistrationId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ApprovalEmailTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingEmailTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancellationEmailTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Publickey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YahooStoreSetting", x => x.YahooStoreSettingId);
                    table.ForeignKey(
                        name: "FK_YahooStoreSetting_UserRegistration_UserRegistrationId",
                        column: x => x.UserRegistrationId,
                        principalTable: "UserRegistration",
                        principalColumn: "UserRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YahooStoreSetting_UserRegistrationId",
                table: "YahooStoreSetting",
                column: "UserRegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YahooStoreSetting");
        }
    }
}
