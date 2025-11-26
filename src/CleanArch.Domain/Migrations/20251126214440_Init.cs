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
                    { 1L, 100.50m, new DateTime(2025, 11, 26, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(6968), new DateTime(2025, 11, 25, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7108), null },
                    { 2L, 200.75m, new DateTime(2025, 11, 26, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7417), new DateTime(2025, 11, 24, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7418), null },
                    { 3L, 50.00m, new DateTime(2025, 11, 26, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7420), new DateTime(2025, 11, 23, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7421), null },
                    { 4L, 300.20m, new DateTime(2025, 11, 26, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7421), new DateTime(2025, 11, 22, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7422), null },
                    { 5L, 150.00m, new DateTime(2025, 11, 26, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7422), new DateTime(2025, 11, 21, 21, 44, 38, 648, DateTimeKind.Utc).AddTicks(7423), null }
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
