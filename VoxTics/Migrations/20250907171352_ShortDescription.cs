using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class ShortDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentNullException(nameof(migrationBuilder));
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new ArgumentNullException(nameof(migrationBuilder));
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Movies");
        }
    }
}
