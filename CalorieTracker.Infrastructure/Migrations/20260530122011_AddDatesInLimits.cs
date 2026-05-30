using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatesInLimits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DailyCalorieLimits");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DailyNutrientsIntakeAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 191, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DailyNutrientsIntakeAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 191, DateTimeKind.Utc).AddTicks(5362));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 191, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 193, DateTimeKind.Utc).AddTicks(1191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(1495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 192, DateTimeKind.Utc).AddTicks(9594),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 192, DateTimeKind.Utc).AddTicks(9293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 899, DateTimeKind.Utc).AddTicks(9782));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DailyNutrientsIntakeAmounts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DailyNutrientsIntakeAmounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DailyCalorieLimits");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DailyCalorieLimits");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(1495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 193, DateTimeKind.Utc).AddTicks(1191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 192, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 899, DateTimeKind.Utc).AddTicks(9782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 20, 11, 192, DateTimeKind.Utc).AddTicks(9293));
        }
    }
}
