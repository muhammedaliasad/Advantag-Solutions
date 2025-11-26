using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dropdowns",
                columns: new[] { "Id", "CreatedAt", "Key", "Label", "ParentId", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(280), "BusinessUnit", "Business Unit 1", null, null, "BU1" },
                    { 2L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(818), "BusinessUnit", "Business Unit 2", null, null, "BU2" },
                    { 3L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(820), "BusinessUnit", "Business Unit 3", null, null, "BU3" },
                    { 4L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(821), "BusinessUnit", "Business Unit 4", null, null, "BU4" },
                    { 5L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(822), "BusinessUnit", "Business Unit 5", null, null, "BU5" },
                    { 6L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(822), "Division", "Division 1", null, null, "Div1" },
                    { 7L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(823), "Division", "Division 2", null, null, "Div2" },
                    { 8L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(824), "Division", "Division 3", null, null, "Div3" },
                    { 9L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(825), "Division", "Division 4", null, null, "Div4" },
                    { 10L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(825), "Division", "Division 5", null, null, "Div5" },
                    { 11L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(826), "Market", "Market 1", null, null, "Mkt1" },
                    { 12L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(827), "Market", "Market 2", null, null, "Mkt2" },
                    { 13L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(827), "Market", "Market 3", null, null, "Mkt3" },
                    { 14L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(835), "Market", "Market 4", null, null, "Mkt4" },
                    { 15L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(836), "Market", "Market 5", null, null, "Mkt5" },
                    { 16L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(837), "DepartmentName", "Department Name 1", null, null, "DeptName1" },
                    { 17L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(837), "DepartmentName", "Department Name 2", null, null, "DeptName2" },
                    { 18L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(838), "DepartmentName", "Department Name 3", null, null, "DeptName3" },
                    { 19L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(839), "DepartmentName", "Department Name 4", null, null, "DeptName4" },
                    { 20L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(839), "DepartmentName", "Department Name 5", null, null, "DeptName5" },
                    { 21L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(840), "DepartmentRange", "Department Range 1", null, null, "DeptRange1" },
                    { 22L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(841), "DepartmentRange", "Department Range 2", null, null, "DeptRange2" },
                    { 23L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(846), "DepartmentRange", "Department Range 3", null, null, "DeptRange3" },
                    { 24L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(847), "DepartmentRange", "Department Range 4", null, null, "DeptRange4" },
                    { 25L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(848), "DepartmentRange", "Department Range 5", null, null, "DeptRange5" },
                    { 26L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(848), "AccountExternalReport", "Account External Report 1", null, null, "AccExt1" },
                    { 27L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(849), "AccountExternalReport", "Account External Report 2", null, null, "AccExt2" },
                    { 28L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(850), "AccountExternalReport", "Account External Report 3", null, null, "AccExt3" },
                    { 29L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(851), "AccountExternalReport", "Account External Report 4", null, null, "AccExt4" },
                    { 30L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(851), "AccountExternalReport", "Account External Report 5", null, null, "AccExt5" },
                    { 31L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(852), "AccountGroup", "Account Group 1", null, null, "AccGroup1" },
                    { 32L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(853), "AccountGroup", "Account Group 2", null, null, "AccGroup2" },
                    { 33L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(859), "AccountGroup", "Account Group 3", null, null, "AccGroup3" },
                    { 34L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(860), "AccountGroup", "Account Group 4", null, null, "AccGroup4" },
                    { 35L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(860), "AccountGroup", "Account Group 5", null, null, "AccGroup5" },
                    { 36L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(861), "AccountSubGroup", "Account SubGroup 1", null, null, "AccSub1" },
                    { 37L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(862), "AccountSubGroup", "Account SubGroup 2", null, null, "AccSub2" },
                    { 38L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(862), "AccountSubGroup", "Account SubGroup 3", null, null, "AccSub3" },
                    { 39L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(863), "AccountSubGroup", "Account SubGroup 4", null, null, "AccSub4" },
                    { 40L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(864), "AccountSubGroup", "Account SubGroup 5", null, null, "AccSub5" },
                    { 41L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(864), "AccountName", "Account Name 1", null, null, "AccName1" },
                    { 42L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(865), "AccountName", "Account Name 2", null, null, "AccName2" },
                    { 43L, new DateTime(2025, 11, 26, 22, 43, 52, 367, DateTimeKind.Utc).AddTicks(867), "AccountName", "Account Name 3", null, null, "AccName3" },
                    { 44L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2485), "AccountName", "Account Name 4", null, null, "AccName4" },
                    { 45L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2492), "AccountName", "Account Name 5", null, null, "AccName5" },
                    { 46L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2494), "AccountRange", "Account Range 1", null, null, "AccRange1" },
                    { 47L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2500), "AccountRange", "Account Range 2", null, null, "AccRange2" },
                    { 48L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2501), "AccountRange", "Account Range 3", null, null, "AccRange3" },
                    { 49L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2502), "AccountRange", "Account Range 4", null, null, "AccRange4" },
                    { 50L, new DateTime(2025, 11, 26, 22, 43, 52, 369, DateTimeKind.Utc).AddTicks(2503), "AccountRange", "Account Range 5", null, null, "AccRange5" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Amount", "CreatedAt", "Date", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 100.50m, new DateTime(2025, 11, 26, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(6793), new DateTime(2025, 11, 25, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(6944), null },
                    { 2L, 200.75m, new DateTime(2025, 11, 26, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7292), new DateTime(2025, 11, 24, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7293), null },
                    { 3L, 50.00m, new DateTime(2025, 11, 26, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7295), new DateTime(2025, 11, 23, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7296), null },
                    { 4L, 300.20m, new DateTime(2025, 11, 26, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7297), new DateTime(2025, 11, 22, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7297), null },
                    { 5L, 150.00m, new DateTime(2025, 11, 26, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7298), new DateTime(2025, 11, 21, 22, 43, 52, 366, DateTimeKind.Utc).AddTicks(7298), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dropdowns_ParentId",
                table: "Dropdowns",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dropdowns");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
