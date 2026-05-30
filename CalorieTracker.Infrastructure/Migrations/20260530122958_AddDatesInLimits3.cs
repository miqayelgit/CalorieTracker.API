using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatesInLimits3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DailyNutrientsIntakeAmounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DailyNutrientsIntakeAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 542, DateTimeKind.Utc).AddTicks(5502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 698, DateTimeKind.Utc).AddTicks(1070));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 542, DateTimeKind.Utc).AddTicks(2868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 697, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 543, DateTimeKind.Utc).AddTicks(9224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 699, DateTimeKind.Utc).AddTicks(4322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 543, DateTimeKind.Utc).AddTicks(7654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 699, DateTimeKind.Utc).AddTicks(2792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 543, DateTimeKind.Utc).AddTicks(7311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 699, DateTimeKind.Utc).AddTicks(2447));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DailyNutrientsIntakeAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DailyNutrientsIntakeAmounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 698, DateTimeKind.Utc).AddTicks(1070),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 542, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DailyCalorieLimits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 697, DateTimeKind.Utc).AddTicks(8606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 542, DateTimeKind.Utc).AddTicks(2868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 699, DateTimeKind.Utc).AddTicks(4322),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 543, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 699, DateTimeKind.Utc).AddTicks(2792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 543, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 12, 22, 1, 699, DateTimeKind.Utc).AddTicks(2447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 12, 29, 58, 543, DateTimeKind.Utc).AddTicks(7311));
        }
    }
}
