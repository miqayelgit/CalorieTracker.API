using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UQ_ActivityLevelName",
                table: "ActivityLevel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 11, 12, 14, 715, DateTimeKind.Utc).AddTicks(5002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 11, 9, 49, 605, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_FitnessGoals_GoalName",
                table: "FitnessGoals",
                column: "GoalName");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_ActivityLevel_ActivityLevelName",
                table: "ActivityLevel",
                column: "ActivityLevelName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UQ_FitnessGoals_GoalName",
                table: "FitnessGoals");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_ActivityLevel_ActivityLevelName",
                table: "ActivityLevel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 11, 9, 49, 605, DateTimeKind.Utc).AddTicks(1164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 11, 12, 14, 715, DateTimeKind.Utc).AddTicks(5002));

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_ActivityLevelName",
                table: "ActivityLevel",
                column: "ActivityLevelName");
        }
    }
}
