using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatesInAppUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(1495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 14, 13, 47, 47, 220, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 899, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ApplicationUserData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(112));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ApplicationUserData");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ApplicationUserData");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 14, 13, 47, 47, 220, DateTimeKind.Utc).AddTicks(6027),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 30, 10, 19, 12, 900, DateTimeKind.Utc).AddTicks(1495));
        }
    }
}
