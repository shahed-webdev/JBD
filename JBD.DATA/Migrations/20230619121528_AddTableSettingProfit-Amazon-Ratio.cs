using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JBD.DATA.Migrations
{
    public partial class AddTableSettingProfitAmazonRatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SettingProfitAmazon",
                columns: table => new
                {
                    SettingProfitAmazonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRegistrationId = table.Column<int>(type: "int", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Expense = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingUnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinimumShippingFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingProfitAmazon", x => x.SettingProfitAmazonId);
                    table.ForeignKey(
                        name: "FK_SettingProfitAmazon_UserRegistration_UserRegistrationId",
                        column: x => x.UserRegistrationId,
                        principalTable: "UserRegistration",
                        principalColumn: "UserRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingProfitRatio",
                columns: table => new
                {
                    SettingProfitRatioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRegistrationId = table.Column<int>(type: "int", nullable: false),
                    AmazonSellingPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PercentageWithPriceAndProfit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PlusAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinusAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ProfitAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingProfitRatio", x => x.SettingProfitRatioId);
                    table.ForeignKey(
                        name: "FK_SettingProfitRatio_UserRegistration_UserRegistrationId",
                        column: x => x.UserRegistrationId,
                        principalTable: "UserRegistration",
                        principalColumn: "UserRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingShippingFeeRation",
                columns: table => new
                {
                    SettingShippingFeeRatioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRegistrationId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingShippingFeeRation", x => x.SettingShippingFeeRatioId);
                    table.ForeignKey(
                        name: "FK_SettingShippingFeeRation_UserRegistration_UserRegistrationId",
                        column: x => x.UserRegistrationId,
                        principalTable: "UserRegistration",
                        principalColumn: "UserRegistrationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingProfitAmazon_UserRegistrationId",
                table: "SettingProfitAmazon",
                column: "UserRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingProfitRatio_UserRegistrationId",
                table: "SettingProfitRatio",
                column: "UserRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingShippingFeeRation_UserRegistrationId",
                table: "SettingShippingFeeRation",
                column: "UserRegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingProfitAmazon");

            migrationBuilder.DropTable(
                name: "SettingProfitRatio");

            migrationBuilder.DropTable(
                name: "SettingShippingFeeRation");

        }
    }
}
