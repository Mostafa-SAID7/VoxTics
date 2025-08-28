using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class LastUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieImg_Movies_MovieId",
                table: "MovieImg");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieImg",
                table: "MovieImg");

            migrationBuilder.RenameTable(
                name: "MovieImg",
                newName: "MovieImgs");

            migrationBuilder.RenameIndex(
                name: "IX_MovieImg_MovieId",
                table: "MovieImgs",
                newName: "IX_MovieImgs_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieImgs",
                table: "MovieImgs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImgs_Movies_MovieId",
                table: "MovieImgs",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieImgs_Movies_MovieId",
                table: "MovieImgs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieImgs",
                table: "MovieImgs");

            migrationBuilder.RenameTable(
                name: "MovieImgs",
                newName: "MovieImg");

            migrationBuilder.RenameIndex(
                name: "IX_MovieImgs_MovieId",
                table: "MovieImg",
                newName: "IX_MovieImg_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieImg",
                table: "MovieImg",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImg_Movies_MovieId",
                table: "MovieImg",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
