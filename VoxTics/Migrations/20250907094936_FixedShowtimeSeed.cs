using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class FixedShowtimeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 12, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 8, 14, 30, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 9, 7, 9, 42, 54, 834, DateTimeKind.Utc).AddTicks(4246), new DateTime(2025, 9, 7, 12, 42, 54, 834, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartTime" },
                values: new object[] { new DateTime(2025, 9, 7, 9, 42, 54, 834, DateTimeKind.Utc).AddTicks(4308), new DateTime(2025, 9, 7, 14, 42, 54, 834, DateTimeKind.Utc).AddTicks(4284) });
        }
    }
}
