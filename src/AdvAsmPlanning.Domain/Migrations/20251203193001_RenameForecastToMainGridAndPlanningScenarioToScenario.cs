using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvAsmPlanning.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RenameForecastToMainGridAndPlanningScenarioToScenario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraint first
            migrationBuilder.DropForeignKey(
                name: "FK_ForecastActuals_Forecasts_ForecastId",
                table: "ForecastActuals");

            // Rename column in ForecastActuals table
            migrationBuilder.RenameColumn(
                name: "ForecastId",
                table: "ForecastActuals",
                newName: "MainGridId");

            // Rename tables (this preserves data)
            migrationBuilder.RenameTable(
                name: "Forecasts",
                schema: null,
                newName: "MainGrids",
                newSchema: null);

            migrationBuilder.RenameTable(
                name: "ForecastActuals",
                schema: null,
                newName: "MainGridActuals",
                newSchema: null);

            migrationBuilder.RenameTable(
                name: "PlanningScenarios",
                schema: null,
                newName: "Scenarios",
                newSchema: null);

            // Rename primary key constraints using SQL
            migrationBuilder.Sql("EXEC sp_rename 'PK_Forecasts', 'PK_MainGrids'");
            migrationBuilder.Sql("EXEC sp_rename 'PK_ForecastActuals', 'PK_MainGridActuals'");
            migrationBuilder.Sql("EXEC sp_rename 'PK_PlanningScenarios', 'PK_Scenarios'");

            // Rename foreign key index
            migrationBuilder.RenameIndex(
                name: "IX_ForecastActuals_ForecastId",
                table: "MainGridActuals",
                newName: "IX_MainGridActuals_MainGridId");

            // Recreate foreign key with new name
            migrationBuilder.AddForeignKey(
                name: "FK_MainGridActuals_MainGrids_MainGridId",
                table: "MainGridActuals",
                column: "MainGridId",
                principalTable: "MainGrids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_MainGridActuals_MainGrids_MainGridId",
                table: "MainGridActuals");

            // Rename column back
            migrationBuilder.RenameColumn(
                name: "MainGridId",
                table: "MainGridActuals",
                newName: "ForecastId");

            // Rename tables back
            migrationBuilder.RenameTable(
                name: "MainGrids",
                schema: null,
                newName: "Forecasts",
                newSchema: null);

            migrationBuilder.RenameTable(
                name: "MainGridActuals",
                schema: null,
                newName: "ForecastActuals",
                newSchema: null);

            migrationBuilder.RenameTable(
                name: "Scenarios",
                schema: null,
                newName: "PlanningScenarios",
                newSchema: null);

            // Rename primary key constraints back using SQL
            migrationBuilder.Sql("EXEC sp_rename 'PK_MainGrids', 'PK_Forecasts'");
            migrationBuilder.Sql("EXEC sp_rename 'PK_MainGridActuals', 'PK_ForecastActuals'");
            migrationBuilder.Sql("EXEC sp_rename 'PK_Scenarios', 'PK_PlanningScenarios'");

            // Rename foreign key index back
            migrationBuilder.RenameIndex(
                name: "IX_MainGridActuals_MainGridId",
                table: "ForecastActuals",
                newName: "IX_ForecastActuals_ForecastId");

            // Recreate foreign key with old name
            migrationBuilder.AddForeignKey(
                name: "FK_ForecastActuals_Forecasts_ForecastId",
                table: "ForecastActuals",
                column: "ForecastId",
                principalTable: "Forecasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
