using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDailyLimits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 14, 13, 47, 47, 220, DateTimeKind.Utc).AddTicks(6027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 14, 5, 28, 53, 369, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.CreateTable(
                name: "DailyCalorieLimits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DailyLimit = table.Column<short>(type: "smallint", nullable: false),
                    UsedLimit = table.Column<short>(type: "smallint", nullable: false),
                    RemainingLimit = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyCalorieLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyCalorieLimits_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyNutrientsIntakeAmounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Protein = table.Column<short>(type: "smallint", nullable: false),
                    Fat = table.Column<short>(type: "smallint", nullable: false),
                    Carbs = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNutrientsIntakeAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyNutrientsIntakeAmounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyCalorieLimits_UserId",
                table: "DailyCalorieLimits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyNutrientsIntakeAmounts_UserId",
                table: "DailyNutrientsIntakeAmounts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyCalorieLimits");

            migrationBuilder.DropTable(
                name: "DailyNutrientsIntakeAmounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 14, 5, 28, 53, 369, DateTimeKind.Utc).AddTicks(2472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 14, 13, 47, 47, 220, DateTimeKind.Utc).AddTicks(6027));
        }
    }
}
