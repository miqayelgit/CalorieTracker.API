using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 4, 6, 6, 57, 771, DateTimeKind.Utc).AddTicks(7590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 26, 14, 3, 57, 656, DateTimeKind.Utc).AddTicks(1713));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 26, 14, 3, 57, 656, DateTimeKind.Utc).AddTicks(1713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 4, 6, 6, 57, 771, DateTimeKind.Utc).AddTicks(7590));
        }
    }
}
