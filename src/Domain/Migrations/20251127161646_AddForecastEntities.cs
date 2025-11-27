using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddForecastEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dropdowns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dropdowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dropdowns_Dropdowns_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Dropdowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoFind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastActuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ForecastId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastActuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForecastActuals_Forecasts_ForecastId",
                        column: x => x.ForecastId,
                        principalTable: "Forecasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dropdowns",
                columns: new[] { "Id", "CreatedAt", "Key", "Label", "ParentId", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(7977), "BusinessUnit", "Business Unit 1", null, null, "BU1" },
                    { 2L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8893), "BusinessUnit", "Business Unit 2", null, null, "BU2" },
                    { 3L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8896), "BusinessUnit", "Business Unit 3", null, null, "BU3" },
                    { 4L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8898), "BusinessUnit", "Business Unit 4", null, null, "BU4" },
                    { 5L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8899), "BusinessUnit", "Business Unit 5", null, null, "BU5" },
                    { 6L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8900), "Division", "Division 1", null, null, "Div1" },
                    { 7L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8901), "Division", "Division 2", null, null, "Div2" },
                    { 8L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8902), "Division", "Division 3", null, null, "Div3" },
                    { 9L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8903), "Division", "Division 4", null, null, "Div4" },
                    { 10L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8904), "Division", "Division 5", null, null, "Div5" },
                    { 11L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8905), "Market", "Market 1", null, null, "Mkt1" },
                    { 12L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8906), "Market", "Market 2", null, null, "Mkt2" },
                    { 13L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8907), "Market", "Market 3", null, null, "Mkt3" },
                    { 14L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8920), "Market", "Market 4", null, null, "Mkt4" },
                    { 15L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8921), "Market", "Market 5", null, null, "Mkt5" },
                    { 16L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8922), "DepartmentName", "Department Name 1", null, null, "DeptName1" },
                    { 17L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8923), "DepartmentName", "Department Name 2", null, null, "DeptName2" },
                    { 18L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8924), "DepartmentName", "Department Name 3", null, null, "DeptName3" },
                    { 19L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8925), "DepartmentName", "Department Name 4", null, null, "DeptName4" },
                    { 20L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8926), "DepartmentName", "Department Name 5", null, null, "DeptName5" },
                    { 21L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8927), "DepartmentRange", "Department Range 1", null, null, "DeptRange1" },
                    { 22L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8928), "DepartmentRange", "Department Range 2", null, null, "DeptRange2" },
                    { 23L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8929), "DepartmentRange", "Department Range 3", null, null, "DeptRange3" },
                    { 24L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8930), "DepartmentRange", "Department Range 4", null, null, "DeptRange4" },
                    { 25L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8932), "DepartmentRange", "Department Range 5", null, null, "DeptRange5" },
                    { 26L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8933), "AccountExternalReport", "Account External Report 1", null, null, "AccExt1" },
                    { 27L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8934), "AccountExternalReport", "Account External Report 2", null, null, "AccExt2" },
                    { 28L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8935), "AccountExternalReport", "Account External Report 3", null, null, "AccExt3" },
                    { 29L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8936), "AccountExternalReport", "Account External Report 4", null, null, "AccExt4" },
                    { 30L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8937), "AccountExternalReport", "Account External Report 5", null, null, "AccExt5" },
                    { 31L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8938), "AccountGroup", "Account Group 1", null, null, "AccGroup1" },
                    { 32L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8940), "AccountGroup", "Account Group 2", null, null, "AccGroup2" },
                    { 33L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8948), "AccountGroup", "Account Group 3", null, null, "AccGroup3" },
                    { 34L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8950), "AccountGroup", "Account Group 4", null, null, "AccGroup4" },
                    { 35L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8951), "AccountGroup", "Account Group 5", null, null, "AccGroup5" },
                    { 36L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8966), "AccountSubGroup", "Account SubGroup 1", null, null, "AccSub1" },
                    { 37L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8967), "AccountSubGroup", "Account SubGroup 2", null, null, "AccSub2" },
                    { 38L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8968), "AccountSubGroup", "Account SubGroup 3", null, null, "AccSub3" },
                    { 39L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8969), "AccountSubGroup", "Account SubGroup 4", null, null, "AccSub4" },
                    { 40L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8970), "AccountSubGroup", "Account SubGroup 5", null, null, "AccSub5" },
                    { 41L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8971), "AccountName", "Account Name 1", null, null, "AccName1" },
                    { 42L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8972), "AccountName", "Account Name 2", null, null, "AccName2" },
                    { 43L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8973), "AccountName", "Account Name 3", null, null, "AccName3" },
                    { 44L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8974), "AccountName", "Account Name 4", null, null, "AccName4" },
                    { 45L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8975), "AccountName", "Account Name 5", null, null, "AccName5" },
                    { 46L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8976), "AccountRange", "Account Range 1", null, null, "AccRange1" },
                    { 47L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8977), "AccountRange", "Account Range 2", null, null, "AccRange2" },
                    { 48L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8979), "AccountRange", "Account Range 3", null, null, "AccRange3" },
                    { 49L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8980), "AccountRange", "Account Range 4", null, null, "AccRange4" },
                    { 50L, new DateTime(2025, 11, 27, 16, 16, 45, 644, DateTimeKind.Utc).AddTicks(8981), "AccountRange", "Account Range 5", null, null, "AccRange5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dropdowns_ParentId",
                table: "Dropdowns",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastActuals_ForecastId",
                table: "ForecastActuals",
                column: "ForecastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dropdowns");

            migrationBuilder.DropTable(
                name: "ForecastActuals");

            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
