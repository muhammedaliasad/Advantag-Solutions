using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdvAsmPlanning.Domain.Migrations
{
    /// <inheritdoc />
    public partial class remove_dropdown_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dropdowns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dropdowns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Dropdowns",
                columns: new[] { "Id", "CreatedAt", "Key", "Label", "ParentId", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "BusinessUnit", "Business Unit 1", null, null, "BU1" },
                    { 2L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "BusinessUnit", "Business Unit 2", null, null, "BU2" },
                    { 3L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "BusinessUnit", "Business Unit 3", null, null, "BU3" },
                    { 4L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "BusinessUnit", "Business Unit 4", null, null, "BU4" },
                    { 5L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "BusinessUnit", "Business Unit 5", null, null, "BU5" },
                    { 6L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Division", "Division 1", null, null, "Div1" },
                    { 7L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Division", "Division 2", null, null, "Div2" },
                    { 8L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Division", "Division 3", null, null, "Div3" },
                    { 9L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Division", "Division 4", null, null, "Div4" },
                    { 10L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Division", "Division 5", null, null, "Div5" },
                    { 11L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Market", "Market 1", null, null, "Mkt1" },
                    { 12L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Market", "Market 2", null, null, "Mkt2" },
                    { 13L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Market", "Market 3", null, null, "Mkt3" },
                    { 14L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Market", "Market 4", null, null, "Mkt4" },
                    { 15L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "Market", "Market 5", null, null, "Mkt5" },
                    { 16L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentName", "Department Name 1", null, null, "DeptName1" },
                    { 17L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentName", "Department Name 2", null, null, "DeptName2" },
                    { 18L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentName", "Department Name 3", null, null, "DeptName3" },
                    { 19L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentName", "Department Name 4", null, null, "DeptName4" },
                    { 20L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentName", "Department Name 5", null, null, "DeptName5" },
                    { 21L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentRange", "Department Range 1", null, null, "DeptRange1" },
                    { 22L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentRange", "Department Range 2", null, null, "DeptRange2" },
                    { 23L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentRange", "Department Range 3", null, null, "DeptRange3" },
                    { 24L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentRange", "Department Range 4", null, null, "DeptRange4" },
                    { 25L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "DepartmentRange", "Department Range 5", null, null, "DeptRange5" },
                    { 26L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountExternalReport", "Account External Report 1", null, null, "AccExt1" },
                    { 27L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountExternalReport", "Account External Report 2", null, null, "AccExt2" },
                    { 28L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountExternalReport", "Account External Report 3", null, null, "AccExt3" },
                    { 29L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountExternalReport", "Account External Report 4", null, null, "AccExt4" },
                    { 30L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountExternalReport", "Account External Report 5", null, null, "AccExt5" },
                    { 31L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountGroup", "Account Group 1", null, null, "AccGroup1" },
                    { 32L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountGroup", "Account Group 2", null, null, "AccGroup2" },
                    { 33L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountGroup", "Account Group 3", null, null, "AccGroup3" },
                    { 34L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountGroup", "Account Group 4", null, null, "AccGroup4" },
                    { 35L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountGroup", "Account Group 5", null, null, "AccGroup5" },
                    { 36L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountSubGroup", "Account SubGroup 1", null, null, "AccSub1" },
                    { 37L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountSubGroup", "Account SubGroup 2", null, null, "AccSub2" },
                    { 38L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountSubGroup", "Account SubGroup 3", null, null, "AccSub3" },
                    { 39L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountSubGroup", "Account SubGroup 4", null, null, "AccSub4" },
                    { 40L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountSubGroup", "Account SubGroup 5", null, null, "AccSub5" },
                    { 41L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountName", "Account Name 1", null, null, "AccName1" },
                    { 42L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountName", "Account Name 2", null, null, "AccName2" },
                    { 43L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountName", "Account Name 3", null, null, "AccName3" },
                    { 44L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountName", "Account Name 4", null, null, "AccName4" },
                    { 45L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountName", "Account Name 5", null, null, "AccName5" },
                    { 46L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountRange", "Account Range 1", null, null, "AccRange1" },
                    { 47L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountRange", "Account Range 2", null, null, "AccRange2" },
                    { 48L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountRange", "Account Range 3", null, null, "AccRange3" },
                    { 49L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountRange", "Account Range 4", null, null, "AccRange4" },
                    { 50L, new DateTime(2025, 11, 27, 14, 30, 0, 0, DateTimeKind.Utc), "AccountRange", "Account Range 5", null, null, "AccRange5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dropdowns_ParentId",
                table: "Dropdowns",
                column: "ParentId");
        }
    }
}
