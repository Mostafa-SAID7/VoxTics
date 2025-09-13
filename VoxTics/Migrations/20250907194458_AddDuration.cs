using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class AddDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentNullException(nameof(migrationBuilder));
            migrationBuilder.RenameColumn(
                name: "DurationMinutes",
                table: "Movies",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentNullException(nameof(migrationBuilder));
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Movies",
                newName: "DurationMinutes");
        }
    }
}
