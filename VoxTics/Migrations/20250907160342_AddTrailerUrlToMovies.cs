using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class AddTrailerUrlToMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentNullException(nameof(migrationBuilder));
            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentNullException(nameof(migrationBuilder));
            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Movies");
        }
    }
}
