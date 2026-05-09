using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addActivityLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 11, 2, 36, 140, DateTimeKind.Utc).AddTicks(406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 4, 6, 6, 57, 771, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.CreateTable(
                name: "ActivityLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityLevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActivityLevelRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessGoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProteinPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    FatPercent = table.Column<byte>(type: "tinyint", nullable: false),
                    CarbsPercent = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessGoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FitnessGoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Height = table.Column<short>(type: "smallint", nullable: false),
                    Weight = table.Column<short>(type: "smallint", nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUserData_ActivityLevel_ActivityLevelId",
                        column: x => x.ActivityLevelId,
                        principalTable: "ActivityLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserData_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserData_FitnessGoal_FitnessGoalId",
                        column: x => x.FitnessGoalId,
                        principalTable: "FitnessGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserData_ActivityLevelId",
                table: "ApplicationUserData",
                column: "ActivityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserData_FitnessGoalId",
                table: "ApplicationUserData",
                column: "FitnessGoalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserData");

            migrationBuilder.DropTable(
                name: "ActivityLevel");

            migrationBuilder.DropTable(
                name: "FitnessGoal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 4, 6, 6, 57, 771, DateTimeKind.Utc).AddTicks(7590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 11, 2, 36, 140, DateTimeKind.Utc).AddTicks(406));
        }
    }
}
