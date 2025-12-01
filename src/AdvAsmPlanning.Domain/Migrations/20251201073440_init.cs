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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                    Delta = table.Column<int>(type: "int", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForecastActuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1001L, "6A1E2C53-874C-4710-9828-5C761B5919BD", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1002L, 0, "B0A3D1CF-679E-4C9E-92A7-2FDFB5C01F44", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEFj9Zqgbi0FbS0mMGtPpXyQt1K2dI4XFa7Q0Jm4ByfgfH5AjFq5RZkGW9xO+fAO3KA==", null, false, "C88FA612-1790-4B5B-9AA0-560F50FC7B72", false, "admin" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1001L, 1002L });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Dropdowns");

            migrationBuilder.DropTable(
                name: "ForecastActuals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
