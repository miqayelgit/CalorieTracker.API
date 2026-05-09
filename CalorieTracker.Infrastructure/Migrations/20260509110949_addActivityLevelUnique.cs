using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addActivityLevelUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserData_FitnessGoal_FitnessGoalId",
                table: "ApplicationUserData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessGoal",
                table: "FitnessGoal");

            migrationBuilder.RenameTable(
                name: "FitnessGoal",
                newName: "FitnessGoals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 11, 9, 49, 605, DateTimeKind.Utc).AddTicks(1164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 11, 2, 36, 140, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.AlterColumn<string>(
                name: "GoalName",
                table: "FitnessGoals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "UQ_ActivityLevelName",
                table: "ActivityLevel",
                column: "ActivityLevelName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessGoals",
                table: "FitnessGoals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserData_FitnessGoals_FitnessGoalId",
                table: "ApplicationUserData",
                column: "FitnessGoalId",
                principalTable: "FitnessGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserData_FitnessGoals_FitnessGoalId",
                table: "ApplicationUserData");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_ActivityLevelName",
                table: "ActivityLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessGoals",
                table: "FitnessGoals");

            migrationBuilder.RenameTable(
                name: "FitnessGoals",
                newName: "FitnessGoal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 11, 2, 36, 140, DateTimeKind.Utc).AddTicks(406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 11, 9, 49, 605, DateTimeKind.Utc).AddTicks(1164));

            migrationBuilder.AlterColumn<string>(
                name: "GoalName",
                table: "FitnessGoal",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessGoal",
                table: "FitnessGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserData_FitnessGoal_FitnessGoalId",
                table: "ApplicationUserData",
                column: "FitnessGoalId",
                principalTable: "FitnessGoal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
