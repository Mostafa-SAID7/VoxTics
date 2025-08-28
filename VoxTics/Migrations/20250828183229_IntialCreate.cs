using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    News = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "FirstName", "LastName", "Name", "News", "ProfilePicture" },
                values: new object[,]
                {
                    { 1, "American actor and film producer.", "Leonardo", "DiCaprio", null, "Best known for Inception and Titanic.", "leo.png" },
                    { 2, "American actor and filmmaker.", "Joseph", "Gordon-Levitt", null, "Starred in Inception.", "jgl.png" },
                    { 3, "Australian actor, best known for Avatar.", "Sam", "Worthington", null, "Will reprise his role in Avatar 3.", "sam.png" },
                    { 4, "English actress, known for Titanic.", "Kate", "Winslet", null, "Won Academy Award for The Reader.", "kate.png" },
                    { 5, "Irish actor, known for Oppenheimer and Peaky Blinders.", "Cillian", "Murphy", null, "Portrayed J. Robert Oppenheimer.", "cillian.png" },
                    { 6, "English actor, known for Batman trilogy.", "Christian", "Bale", null, "Played Bruce Wayne in The Dark Knight.", "bale.png" },
                    { 7, "American actor, voiced Simba in The Lion King.", "Matthew", "Broderick", null, "Tony Award-winning stage actor.", "broderick.png" },
                    { 8, "American actor, known for Interstellar.", "Matthew", "McConaughey", null, "Won Academy Award for Dallas Buyers Club.", "mcconaughey.png" },
                    { 25, "American actor, known for Joker.", "Joaquin", "Phoenix", null, "Won Academy Award for Joker.", "phoenix.png" },
                    { 29, "American actor, starred in The Conjuring.", "Patrick", "Wilson", null, "Also starred in Insidious franchise.", "wilson.png" },
                    { 41, "American actress and singer, voice of Elsa in Frozen.", "Idina", "Menzel", null, "Famous for singing Let It Go.", "idina.png" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Documentary" },
                    { 5, "Cartoon" },
                    { 6, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "CinemaLogo", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "395 Welch Junction", "Quis.tiff", "Duis aliquam convallis nunc...", "Photospace" },
                    { 2, "6958 Debra Avenue", "Sagittis.tiff", "Fusce posuere felis sed lacus...", "Trilith" },
                    { 3, "710 Weeping Birch Junction", "DisParturientMontes.jpeg", "Praesent id massa id nisl venenatis lacinia...", "Oozz" },
                    { 4, "1200 Sunset Blvd", "Cinemark.png", "State-of-the-art cinema experience...", "Cinemark" },
                    { 5, "45 Main Street", "Regal.jpg", "Family-friendly movie theatre...", "Regal Theatres" },
                    { 6, "88 Broadway Ave", "AMC.png", "Luxury recliners and IMAX screens...", "AMC Theatres" },
                    { 7, "200 City Center Plaza", "IMAX.jpg", "Immersive cinema with giant screens...", "IMAX Experience" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CinemaId", "Description", "EndDate", "ImgUrl", "MovieStatus", "Price", "StartDate", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, 1, 1, "A mind-bending thriller", new DateTime(2011, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available", 50m, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", null },
                    { 2, 2, 2, "The next epic sci-fi adventure", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ComingSoon", 60m, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar 3", null },
                    { 3, 3, 3, "A tragic love story", new DateTime(1998, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Expired", 40m, new DateTime(1997, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic", null },
                    { 4, 3, 1, "The story of J. Robert Oppenheimer", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available", 55m, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oppenheimer", null },
                    { 5, 1, 4, "Batman faces the Joker in Gotham", new DateTime(2009, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Expired", 45m, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", null },
                    { 6, 5, 5, "A young lion prince flees his kingdom", new DateTime(1995, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Expired", 35m, new DateTime(1994, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lion King", null },
                    { 7, 1, 6, "A journey through space and time", new DateTime(2015, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available", 65m, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar", null },
                    { 8, 3, 7, "The origin story of Gotham’s villain", new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available", 50m, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joker", null },
                    { 9, 6, 6, "A chilling horror story", new DateTime(2014, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Expired", 40m, new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Conjuring", null },
                    { 10, 5, 5, "A magical Disney animated film", new DateTime(2014, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available", 30m, new DateTime(2013, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frozen", null },
                    { 21, 6, 6, "A terrifying sequel to the horror hit", new DateTime(2017, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Expired", 45m, new DateTime(2016, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Conjuring 2", null },
                    { 26, 5, 5, "Elsa and Anna’s new magical journey", new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Available", 35m, new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frozen II", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 1, 3 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 },
                    { 8, 7 },
                    { 25, 8 },
                    { 29, 9 },
                    { 41, 10 },
                    { 29, 21 },
                    { 41, 26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
