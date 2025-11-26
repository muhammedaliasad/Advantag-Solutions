using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Sales",
                columns: new[] { "Id", "Amount", "CreatedAt", "Date", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 100.50m, new DateTime(2025, 11, 26, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9162), new DateTime(2025, 11, 25, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9290), null },
                    { 2L, 200.75m, new DateTime(2025, 11, 26, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9591), new DateTime(2025, 11, 24, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9592), null },
                    { 3L, 50.00m, new DateTime(2025, 11, 26, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9594), new DateTime(2025, 11, 23, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9594), null },
                    { 4L, 300.20m, new DateTime(2025, 11, 26, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9595), new DateTime(2025, 11, 22, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9596), null },
                    { 5L, 150.00m, new DateTime(2025, 11, 26, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9596), new DateTime(2025, 11, 21, 22, 8, 40, 877, DateTimeKind.Utc).AddTicks(9597), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
