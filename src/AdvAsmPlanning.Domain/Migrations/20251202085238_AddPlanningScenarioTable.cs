using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvAsmPlanning.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanningScenarioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningScenarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CubeScenarioId = table.Column<int>(type: "int", nullable: true),
                    StartMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsolidationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualScenario = table.Column<bool>(type: "bit", nullable: false),
                    FxFlag = table.Column<bool>(type: "bit", nullable: false),
                    PlanningScenarioGroupId = table.Column<int>(type: "int", nullable: false),
                    PostingLayerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningScenarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningScenarios");
        }
    }
}
