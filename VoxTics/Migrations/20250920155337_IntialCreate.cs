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
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOTPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OTPNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTPType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOTPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOTPs_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Default"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watchlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "EN"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MainImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Halls_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMediaLink_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMediaLink_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MovieImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieImages_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchlistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WatchlistId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchlistItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchlistItems_Watchlists_WatchlistId",
                        column: x => x.WatchlistId,
                        principalTable: "Watchlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Showtimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Is3D = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "EN"),
                    ScreenType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Standard"),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showtimes_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Showtimes_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Showtimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShowtimeId = table.Column<int>(type: "int", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    FinalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsCheckedIn = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Showtimes_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "Showtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    SeatPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingSeats_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ShowtimeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Showtimes_ShowtimeId",
                        column: x => x.ShowtimeId,
                        principalTable: "Showtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    NumberInRow = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SeatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CartItemId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_CartItems_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seats_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsageLimit = table.Column<int>(type: "int", nullable: true),
                    UsedCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsApplied = table.Column<bool>(type: "bit", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TransactionId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "CreatedAt", "DateOfBirth", "DeletedAt", "FullName", "ImageUrl", "IsActive", "IsDeleted", "Nationality", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "American actor known for Iron Man.", new DateTime(2025, 9, 20, 15, 53, 34, 638, DateTimeKind.Utc).AddTicks(9521), null, null, "Robert Downey Jr.", null, true, false, null, null },
                    { 2, "American actress and singer.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2123), null, null, "Gwyneth Paltrow", null, true, false, null, null },
                    { 3, "American actor known for Captain America.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2129), null, null, "Chris Evans", null, true, false, null, null },
                    { 4, "American actress known for Black Widow.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2132), null, null, "Scarlett Johansson", null, true, false, null, null },
                    { 5, "Australian actor known for Thor.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2134), null, null, "Chris Hemsworth", null, true, false, null, null },
                    { 6, "American actor known for Hulk.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2153), null, null, "Mark Ruffalo", null, true, false, null, null },
                    { 7, "English actor known for Spider-Man.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2166), null, null, "Tom Holland", null, true, false, null, null },
                    { 8, "American actress known for MJ.", new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2182), null, null, "Zendaya", null, true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "City", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { "user1", 0, "", null, null, "f14fab1d-a8be-4154-a98d-7f634b2e68e2", new DateTime(2025, 9, 20, 15, 53, 33, 999, DateTimeKind.Utc).AddTicks(4127), null, "user1@example.com", true, 0, false, null, "", "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOak2MH4R8ynq+48ZaswmOLu2mqQEpVthSmTx7CwvWpSiwKzkyFiNb6OEmrAD1J4nQ==", null, false, "", null, null, false, "user1@example.com", null },
                    { "user2", 0, "", null, null, "259712d8-a61d-491c-a39f-d60e405e8902", new DateTime(2025, 9, 20, 15, 53, 34, 106, DateTimeKind.Utc).AddTicks(1941), null, "user2@example.com", true, 0, false, null, "", "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPNUTie2QBo2eHkdrv8ZzN0HKiSncc/Rdt7z+zfdcj55Hr7Ec+TLAb13pj2fEXWf9A==", null, false, "", null, null, false, "user2@example.com", null },
                    { "user3", 0, "", null, null, "7631d569-5214-49c0-bea3-a696db5dc95e", new DateTime(2025, 9, 20, 15, 53, 34, 207, DateTimeKind.Utc).AddTicks(8700), null, "user3@example.com", true, 0, false, null, "", "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHHQJT+Wlm/EHd3pKWeLcwWdBE9oJ0ydRKjMCadkA8rX7DD5IV6XCgaSpT63u8GbyA==", null, false, "", null, null, false, "user3@example.com", null },
                    { "user4", 0, "", null, null, "deea2382-8543-48bd-ac4d-8121912ac209", new DateTime(2025, 9, 20, 15, 53, 34, 310, DateTimeKind.Utc).AddTicks(7991), null, "user4@example.com", true, 0, false, null, "", "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", "AQAAAAIAAYagAAAAED+ZmfIcUZnlZb2H2EdzGA2OfM9/ekNBY8w2z3mMWinAQzTRxVXzBo5sBUAs8czNDw==", null, false, "", null, null, false, "user4@example.com", null },
                    { "user5", 0, "", null, null, "a5b3ef2e-bfde-4bf5-b04f-d9294e92489c", new DateTime(2025, 9, 20, 15, 53, 34, 451, DateTimeKind.Utc).AddTicks(561), null, "user5@example.com", true, 0, false, null, "", "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", "AQAAAAIAAYagAAAAELfOqGJTQPABcnoDHm7IbHWyR7aOrq6RfSxrdHhhpTmpBLsVgFAg/STnPlnLtIFgnw==", null, false, "", null, null, false, "user5@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(9709), null, "Action-packed movies", true, false, "Action", "action", null },
                    { 2, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(1992), null, "Funny and entertaining movies", true, false, "Comedy", "comedy", null },
                    { 3, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(1998), null, "Dramatic and emotional stories", true, false, "Drama", "drama", null },
                    { 4, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2000), null, "Scary and thrilling movies", true, false, "Horror", "horror", null },
                    { 5, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2002), null, "Science fiction movies", true, false, "Sci-Fi", "sci-fi", null },
                    { 6, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2013), null, "Romantic movies", true, false, "Romance", "romance", null },
                    { 7, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2026), null, "Animated movies for all ages", true, false, "Animation", "animation", null },
                    { 8, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2027), null, "Exciting adventure movies", true, false, "Adventure", "adventure", null },
                    { 9, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2029), null, "Fantasy worlds and stories", true, false, "Fantasy", "fantasy", null },
                    { 10, new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2032), null, "Suspenseful and thrilling movies", true, false, "Thriller", "thriller", null }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Description", "Email", "ImageUrl", "IsActive", "IsDeleted", "Name", "Phone", "PostalCode", "State", "UpdatedAt", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "Metropolis", "USA", new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(9882), null, "A modern cinema located in the heart of the city with multiple halls and premium services.", "contact@voxcity.com", "https://example.com/images/cinema1.jpg", true, false, "Vox City Center", "+1-555-1234", "10001", "NY", null, "https://www.voxcitycinema.com" },
                    { 2, "456 Elm Street", "Gotham", "USA", new DateTime(2025, 9, 20, 15, 53, 34, 641, DateTimeKind.Utc).AddTicks(5920), null, "Popular cinema known for IMAX and 3D showings.", "info@galaxy.com", "https://example.com/images/cinema2.jpg", true, false, "Galaxy Multiplex", "+1-555-5678", "60601", "IL", null, "https://www.galaxycinema.com" },
                    { 3, "789 Oak Avenue", "Star City", "USA", new DateTime(2025, 9, 20, 15, 53, 34, 641, DateTimeKind.Utc).AddTicks(5928), null, "Premium cinema experience with luxury seating and gourmet snacks.", "support@cinestar.com", "https://example.com/images/cinema3.jpg", true, false, "CineStar Premium", "+1-555-7890", "90001", "CA", null, "https://www.cinestar.com" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "BookingId", "CartId", "Code", "CreatedAt", "DeletedAt", "DiscountPercentage", "ExpiryDate", "IsActive", "IsApplied", "IsDeleted", "MaxDiscountAmount", "UpdatedAt", "UsageLimit", "UsedCount" },
                values: new object[,]
                {
                    { 1, null, null, "DISC10", new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(356), null, 10m, null, true, false, false, null, null, null, 0 },
                    { 2, null, null, "DISC20", new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(2123), null, 20m, null, true, false, false, null, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "CinemaId", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "TotalSeats", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(5128), null, "Standard screen hall with surround sound", true, false, "Hall A", 150, null },
                    { 2, 1, new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7843), null, "3D projection hall with premium seating", true, false, "Hall B", 200, null },
                    { 3, 2, new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7849), null, "IMAX hall with ultra-large screen and Dolby Atmos", true, false, "IMAX", 250, null },
                    { 4, 2, new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7852), null, "Standard projection hall with comfortable seating", true, false, "Galaxy Standard", 180, null },
                    { 5, 3, new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7855), null, "Premium lounge with recliners and in-seat service", true, false, "VIP Lounge", 120, null },
                    { 6, 3, new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7858), null, "Large hall with state-of-the-art sound and visuals", true, false, "CineStar Deluxe", 200, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "EndDate", "IsDeleted", "IsFeatured", "Language", "MainImage", "Price", "Rating", "ReleaseDate", "Slug", "Status", "Title", "TrailerUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 645, DateTimeKind.Utc).AddTicks(2108), null, "Billionaire Tony Stark builds a high-tech suit to fight evil.", "Jon Favreau", 126, new DateTime(2008, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "EN", "https://example.com/images/ironman.jpg", 10.00m, 8.5m, new DateTime(2008, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "iron-man", 1, "Iron Man", "https://www.youtube.com/watch?v=8hYlB38asDY", null },
                    { 2, 1, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1950), null, "Earth’s mightiest heroes unite against a common enemy.", "Joss Whedon", 143, new DateTime(2012, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "EN", "https://example.com/images/avengers.jpg", 12.00m, 9.0m, new DateTime(2012, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "avengers", 2, "The Avengers", "https://www.youtube.com/watch?v=eOrNdBpGMv8", null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "EndDate", "IsDeleted", "Language", "MainImage", "Price", "Rating", "ReleaseDate", "Slug", "Status", "Title", "TrailerUrl", "UpdatedAt" },
                values: new object[] { 3, 2, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1967), null, "T'Challa fights for his kingdom of Wakanda.", "Ryan Coogler", 134, new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "EN", "https://example.com/images/blackpanther.jpg", 11.50m, 8.2m, new DateTime(2018, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "black-panther", 2, "Black Panther", "https://www.youtube.com/watch?v=xjDjIWPwcPU", null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "EndDate", "IsDeleted", "IsFeatured", "Language", "MainImage", "Price", "Rating", "ReleaseDate", "Slug", "Status", "Title", "TrailerUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, 3, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1975), null, "Strange explores the multiverse with dangerous consequences.", "Sam Raimi", 126, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "EN", "https://example.com/images/doctorstrange2.jpg", 13.00m, 7.8m, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "doctor-strange-mom", 1, "Doctor Strange in the Multiverse of Madness", "https://www.youtube.com/watch?v=aWzlQ2N6qqg", null },
                    { 5, 2, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1980), null, "The misfit heroes face a new cosmic challenge.", "James Gunn", 150, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "EN", "https://example.com/images/guardians3.jpg", 14.00m, 8.3m, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "guardians-of-the-galaxy-vol-3", 0, "Guardians of the Galaxy Vol. 3", "https://www.youtube.com/watch?v=u3V5KDHRQvk", null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "EndDate", "IsDeleted", "Language", "MainImage", "Price", "Rating", "ReleaseDate", "Slug", "Status", "Title", "TrailerUrl", "UpdatedAt" },
                values: new object[] { 6, 3, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2056), null, "Thor faces Hela to save Asgard.", "Taika Waititi", 130, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "EN", "https://example.com/images/thor-ragnarok.jpg", 11.00m, 7.9m, new DateTime(2017, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "thor-ragnarok", 2, "Thor: Ragnarok", "https://www.youtube.com/watch?v=ue80QwXMRHg", null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "EndDate", "IsDeleted", "IsFeatured", "Language", "MainImage", "Price", "Rating", "ReleaseDate", "Slug", "Status", "Title", "TrailerUrl", "UpdatedAt" },
                values: new object[] { 7, 1, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2062), null, "Peter Parker faces the multiverse's chaos.", "Jon Watts", 148, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "EN", "https://example.com/images/spiderman-nwh.jpg", 14.50m, 8.7m, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "spider-man-no-way-home", 2, "Spider-Man: No Way Home", "https://www.youtube.com/watch?v=JfVOs4VSpmA", null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "EndDate", "IsDeleted", "Language", "MainImage", "Price", "Rating", "ReleaseDate", "Slug", "Status", "Title", "TrailerUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 8, 2, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2068), null, "Carol Danvers becomes Captain Marvel.", "Anna Boden & Ryan Fleck", 123, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "EN", "https://example.com/images/captainmarvel.jpg", 10.50m, 7.1m, new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "captain-marvel", 2, "Captain Marvel", "https://www.youtube.com/watch?v=Z1BCujX3pw8", null },
                    { 9, 3, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2074), null, "Scott Lang explores the Quantum Realm.", "Peyton Reed", 125, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "EN", "https://example.com/images/antman-quantumania.jpg", 13.50m, 7.4m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ant-man-quantumania", 1, "Ant-Man and the Wasp: Quantumania", "https://www.youtube.com/watch?v=ZlNFpri-Y40", null },
                    { 10, 2, "USA", new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2080), null, "Immortal beings reunite to save humanity.", "Chloé Zhao", 156, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "EN", "https://example.com/images/eternals.jpg", 12.50m, 6.9m, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "eternals", 2, "Eternals", "https://www.youtube.com/watch?v=x_me3xsvDgk", null }
                });

            migrationBuilder.InsertData(
                table: "Watchlists",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(7243), null, false, "Favorites", null, "user1" },
                    { 2, new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8431), null, false, "Must Watch", null, "user2" },
                    { 3, new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8435), null, false, "Weekend Picks", null, "user3" },
                    { 4, new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8437), null, false, "Top Movies", null, "user4" },
                    { 5, new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8438), null, false, "Action Collection", null, "user5" }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CartItemId", "CreatedAt", "DeletedAt", "HallId", "IsActive", "IsAvailable", "IsDeleted", "NumberInRow", "Row", "SeatNumber", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 9, 20, 15, 53, 34, 649, DateTimeKind.Utc).AddTicks(9707), null, 1, true, true, false, 1, "A", "A1", 1, null },
                    { 2, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5790), null, 1, true, true, false, 2, "A", "A2", 1, null },
                    { 3, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5846), null, 1, true, true, false, 3, "A", "A3", 1, null },
                    { 4, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5861), null, 1, true, true, false, 4, "A", "A4", 1, null },
                    { 5, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5872), null, 1, true, true, false, 5, "A", "A5", 1, null },
                    { 6, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5900), null, 1, true, true, false, 6, "A", "A6", 1, null },
                    { 7, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5912), null, 1, true, true, false, 7, "A", "A7", 1, null },
                    { 8, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5923), null, 1, true, true, false, 8, "A", "A8", 1, null },
                    { 9, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5935), null, 1, true, true, false, 9, "A", "A9", 1, null },
                    { 10, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5952), null, 1, true, true, false, 10, "A", "A10", 1, null },
                    { 11, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5987), null, 1, true, true, false, 1, "B", "B1", 1, null },
                    { 12, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6001), null, 1, true, true, false, 2, "B", "B2", 1, null },
                    { 13, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6013), null, 1, true, true, false, 3, "B", "B3", 1, null },
                    { 14, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6024), null, 1, true, true, false, 4, "B", "B4", 1, null },
                    { 15, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6034), null, 1, true, true, false, 5, "B", "B5", 1, null },
                    { 16, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6064), null, 1, true, true, false, 6, "B", "B6", 1, null },
                    { 17, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6077), null, 1, true, true, false, 7, "B", "B7", 1, null },
                    { 18, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6095), null, 1, true, true, false, 8, "B", "B8", 1, null },
                    { 19, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6107), null, 1, true, true, false, 9, "B", "B9", 1, null },
                    { 20, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6119), null, 1, true, true, false, 10, "B", "B10", 1, null },
                    { 21, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6173), null, 1, true, true, false, 1, "C", "C1", 1, null },
                    { 22, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6189), null, 1, true, true, false, 2, "C", "C2", 1, null },
                    { 23, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6199), null, 1, true, true, false, 3, "C", "C3", 1, null },
                    { 24, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6228), null, 1, true, true, false, 4, "C", "C4", 1, null },
                    { 25, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6250), null, 1, true, true, false, 5, "C", "C5", 1, null },
                    { 26, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6261), null, 1, true, true, false, 6, "C", "C6", 1, null },
                    { 27, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6272), null, 1, true, true, false, 7, "C", "C7", 1, null },
                    { 28, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6285), null, 1, true, true, false, 8, "C", "C8", 1, null },
                    { 29, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6294), null, 1, true, true, false, 9, "C", "C9", 1, null },
                    { 30, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6313), null, 1, true, true, false, 10, "C", "C10", 1, null },
                    { 31, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6437), null, 1, true, true, false, 1, "D", "D1", 1, null },
                    { 32, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6451), null, 1, true, true, false, 2, "D", "D2", 1, null },
                    { 33, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6463), null, 1, true, true, false, 3, "D", "D3", 1, null },
                    { 34, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6481), null, 1, true, true, false, 4, "D", "D4", 1, null },
                    { 35, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6494), null, 1, true, true, false, 5, "D", "D5", 1, null },
                    { 36, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6506), null, 1, true, true, false, 6, "D", "D6", 1, null },
                    { 37, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6519), null, 1, true, true, false, 7, "D", "D7", 1, null },
                    { 38, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6530), null, 1, true, true, false, 8, "D", "D8", 1, null },
                    { 39, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6542), null, 1, true, true, false, 9, "D", "D9", 1, null },
                    { 40, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6553), null, 1, true, true, false, 10, "D", "D10", 1, null },
                    { 41, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6564), null, 1, true, true, false, 1, "E", "E1", 1, null },
                    { 42, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6575), null, 1, true, true, false, 2, "E", "E2", 1, null },
                    { 43, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6586), null, 1, true, true, false, 3, "E", "E3", 1, null },
                    { 44, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6597), null, 1, true, true, false, 4, "E", "E4", 1, null },
                    { 45, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6608), null, 1, true, true, false, 5, "E", "E5", 1, null },
                    { 46, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6619), null, 1, true, true, false, 6, "E", "E6", 1, null },
                    { 47, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6630), null, 1, true, true, false, 7, "E", "E7", 1, null },
                    { 48, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6641), null, 1, true, true, false, 8, "E", "E8", 1, null },
                    { 49, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6652), null, 1, true, true, false, 9, "E", "E9", 1, null },
                    { 50, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6662), null, 1, true, true, false, 10, "E", "E10", 1, null },
                    { 51, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6674), null, 2, true, true, false, 1, "A", "A1", 1, null },
                    { 52, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6684), null, 2, true, true, false, 2, "A", "A2", 1, null },
                    { 53, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6722), null, 2, true, true, false, 3, "A", "A3", 1, null },
                    { 54, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6737), null, 2, true, true, false, 4, "A", "A4", 1, null },
                    { 55, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6747), null, 2, true, true, false, 5, "A", "A5", 1, null },
                    { 56, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6756), null, 2, true, true, false, 6, "A", "A6", 1, null },
                    { 57, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6768), null, 2, true, true, false, 7, "A", "A7", 1, null },
                    { 58, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6778), null, 2, true, true, false, 8, "A", "A8", 1, null },
                    { 59, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6789), null, 2, true, true, false, 9, "A", "A9", 1, null },
                    { 60, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6799), null, 2, true, true, false, 10, "A", "A10", 1, null },
                    { 61, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6810), null, 2, true, true, false, 1, "B", "B1", 1, null },
                    { 62, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6820), null, 2, true, true, false, 2, "B", "B2", 1, null },
                    { 63, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6831), null, 2, true, true, false, 3, "B", "B3", 1, null },
                    { 64, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6840), null, 2, true, true, false, 4, "B", "B4", 1, null },
                    { 65, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6851), null, 2, true, true, false, 5, "B", "B5", 1, null },
                    { 66, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6872), null, 2, true, true, false, 6, "B", "B6", 1, null },
                    { 67, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6884), null, 2, true, true, false, 7, "B", "B7", 1, null },
                    { 68, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6895), null, 2, true, true, false, 8, "B", "B8", 1, null },
                    { 69, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6905), null, 2, true, true, false, 9, "B", "B9", 1, null },
                    { 70, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6915), null, 2, true, true, false, 10, "B", "B10", 1, null },
                    { 71, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6927), null, 2, true, true, false, 1, "C", "C1", 1, null },
                    { 72, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6936), null, 2, true, true, false, 2, "C", "C2", 1, null },
                    { 73, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6947), null, 2, true, true, false, 3, "C", "C3", 1, null },
                    { 74, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6957), null, 2, true, true, false, 4, "C", "C4", 1, null },
                    { 75, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6968), null, 2, true, true, false, 5, "C", "C5", 1, null },
                    { 76, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6978), null, 2, true, true, false, 6, "C", "C6", 1, null },
                    { 77, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6988), null, 2, true, true, false, 7, "C", "C7", 1, null },
                    { 78, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6998), null, 2, true, true, false, 8, "C", "C8", 1, null },
                    { 79, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7009), null, 2, true, true, false, 9, "C", "C9", 1, null },
                    { 80, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7019), null, 2, true, true, false, 10, "C", "C10", 1, null },
                    { 81, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7031), null, 2, true, true, false, 1, "D", "D1", 1, null },
                    { 82, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7042), null, 2, true, true, false, 2, "D", "D2", 1, null },
                    { 83, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7079), null, 2, true, true, false, 3, "D", "D3", 1, null },
                    { 84, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7098), null, 2, true, true, false, 4, "D", "D4", 1, null },
                    { 85, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7108), null, 2, true, true, false, 5, "D", "D5", 1, null },
                    { 86, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7118), null, 2, true, true, false, 6, "D", "D6", 1, null },
                    { 87, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7128), null, 2, true, true, false, 7, "D", "D7", 1, null },
                    { 88, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7138), null, 2, true, true, false, 8, "D", "D8", 1, null },
                    { 89, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7148), null, 2, true, true, false, 9, "D", "D9", 1, null },
                    { 90, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7158), null, 2, true, true, false, 10, "D", "D10", 1, null },
                    { 91, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7167), null, 2, true, true, false, 1, "E", "E1", 1, null },
                    { 92, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7177), null, 2, true, true, false, 2, "E", "E2", 1, null },
                    { 93, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7187), null, 2, true, true, false, 3, "E", "E3", 1, null },
                    { 94, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7197), null, 2, true, true, false, 4, "E", "E4", 1, null },
                    { 95, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7206), null, 2, true, true, false, 5, "E", "E5", 1, null },
                    { 96, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7215), null, 2, true, true, false, 6, "E", "E6", 1, null },
                    { 97, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7225), null, 2, true, true, false, 7, "E", "E7", 1, null },
                    { 98, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7237), null, 2, true, true, false, 8, "E", "E8", 1, null },
                    { 99, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7248), null, 2, true, true, false, 9, "E", "E9", 1, null },
                    { 100, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7257), null, 2, true, true, false, 10, "E", "E10", 1, null },
                    { 101, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7266), null, 3, true, true, false, 1, "A", "A1", 1, null },
                    { 102, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7275), null, 3, true, true, false, 2, "A", "A2", 1, null },
                    { 103, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7285), null, 3, true, true, false, 3, "A", "A3", 1, null },
                    { 104, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7296), null, 3, true, true, false, 4, "A", "A4", 1, null },
                    { 105, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7306), null, 3, true, true, false, 5, "A", "A5", 1, null },
                    { 106, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7316), null, 3, true, true, false, 6, "A", "A6", 1, null },
                    { 107, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7326), null, 3, true, true, false, 7, "A", "A7", 1, null },
                    { 108, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7335), null, 3, true, true, false, 8, "A", "A8", 1, null },
                    { 109, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7345), null, 3, true, true, false, 9, "A", "A9", 1, null },
                    { 110, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7357), null, 3, true, true, false, 10, "A", "A10", 1, null },
                    { 111, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7368), null, 3, true, true, false, 1, "B", "B1", 1, null },
                    { 112, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7378), null, 3, true, true, false, 2, "B", "B2", 1, null },
                    { 113, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7390), null, 3, true, true, false, 3, "B", "B3", 1, null },
                    { 114, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7401), null, 3, true, true, false, 4, "B", "B4", 1, null },
                    { 115, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7412), null, 3, true, true, false, 5, "B", "B5", 1, null },
                    { 116, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7422), null, 3, true, true, false, 6, "B", "B6", 1, null },
                    { 117, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7455), null, 3, true, true, false, 7, "B", "B7", 1, null },
                    { 118, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7471), null, 3, true, true, false, 8, "B", "B8", 1, null },
                    { 119, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7481), null, 3, true, true, false, 9, "B", "B9", 1, null },
                    { 120, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7490), null, 3, true, true, false, 10, "B", "B10", 1, null },
                    { 121, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7501), null, 3, true, true, false, 1, "C", "C1", 1, null },
                    { 122, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7511), null, 3, true, true, false, 2, "C", "C2", 1, null },
                    { 123, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7521), null, 3, true, true, false, 3, "C", "C3", 1, null },
                    { 124, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7535), null, 3, true, true, false, 4, "C", "C4", 1, null },
                    { 125, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7546), null, 3, true, true, false, 5, "C", "C5", 1, null },
                    { 126, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7557), null, 3, true, true, false, 6, "C", "C6", 1, null },
                    { 127, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7567), null, 3, true, true, false, 7, "C", "C7", 1, null },
                    { 128, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7577), null, 3, true, true, false, 8, "C", "C8", 1, null },
                    { 129, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7587), null, 3, true, true, false, 9, "C", "C9", 1, null },
                    { 130, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7634), null, 3, true, true, false, 10, "C", "C10", 1, null },
                    { 131, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7652), null, 3, true, true, false, 1, "D", "D1", 1, null },
                    { 132, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7663), null, 3, true, true, false, 2, "D", "D2", 1, null },
                    { 133, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7672), null, 3, true, true, false, 3, "D", "D3", 1, null },
                    { 134, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7683), null, 3, true, true, false, 4, "D", "D4", 1, null },
                    { 135, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7694), null, 3, true, true, false, 5, "D", "D5", 1, null },
                    { 136, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7703), null, 3, true, true, false, 6, "D", "D6", 1, null },
                    { 137, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7714), null, 3, true, true, false, 7, "D", "D7", 1, null },
                    { 138, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7725), null, 3, true, true, false, 8, "D", "D8", 1, null },
                    { 139, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7738), null, 3, true, true, false, 9, "D", "D9", 1, null },
                    { 140, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7749), null, 3, true, true, false, 10, "D", "D10", 1, null },
                    { 141, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7761), null, 3, true, true, false, 1, "E", "E1", 1, null },
                    { 142, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7771), null, 3, true, true, false, 2, "E", "E2", 1, null },
                    { 143, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7808), null, 3, true, true, false, 3, "E", "E3", 1, null },
                    { 144, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7818), null, 3, true, true, false, 4, "E", "E4", 1, null },
                    { 145, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7828), null, 3, true, true, false, 5, "E", "E5", 1, null },
                    { 146, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7838), null, 3, true, true, false, 6, "E", "E6", 1, null },
                    { 147, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7848), null, 3, true, true, false, 7, "E", "E7", 1, null },
                    { 148, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7859), null, 3, true, true, false, 8, "E", "E8", 1, null },
                    { 149, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7873), null, 3, true, true, false, 9, "E", "E9", 1, null },
                    { 150, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7883), null, 3, true, true, false, 10, "E", "E10", 1, null },
                    { 151, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7894), null, 4, true, true, false, 1, "A", "A1", 1, null },
                    { 152, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7905), null, 4, true, true, false, 2, "A", "A2", 1, null },
                    { 153, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7914), null, 4, true, true, false, 3, "A", "A3", 1, null },
                    { 154, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7925), null, 4, true, true, false, 4, "A", "A4", 1, null },
                    { 155, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7935), null, 4, true, true, false, 5, "A", "A5", 1, null },
                    { 156, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7946), null, 4, true, true, false, 6, "A", "A6", 1, null },
                    { 157, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7957), null, 4, true, true, false, 7, "A", "A7", 1, null },
                    { 158, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7968), null, 4, true, true, false, 8, "A", "A8", 1, null },
                    { 159, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7978), null, 4, true, true, false, 9, "A", "A9", 1, null },
                    { 160, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7988), null, 4, true, true, false, 10, "A", "A10", 1, null },
                    { 161, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7998), null, 4, true, true, false, 1, "B", "B1", 1, null },
                    { 162, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8009), null, 4, true, true, false, 2, "B", "B2", 1, null },
                    { 163, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8020), null, 4, true, true, false, 3, "B", "B3", 1, null },
                    { 164, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8030), null, 4, true, true, false, 4, "B", "B4", 1, null },
                    { 165, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8042), null, 4, true, true, false, 5, "B", "B5", 1, null },
                    { 166, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8052), null, 4, true, true, false, 6, "B", "B6", 1, null },
                    { 167, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8062), null, 4, true, true, false, 7, "B", "B7", 1, null },
                    { 168, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8071), null, 4, true, true, false, 8, "B", "B8", 1, null },
                    { 169, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8081), null, 4, true, true, false, 9, "B", "B9", 1, null },
                    { 170, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8091), null, 4, true, true, false, 10, "B", "B10", 1, null },
                    { 171, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8101), null, 4, true, true, false, 1, "C", "C1", 1, null },
                    { 172, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8110), null, 4, true, true, false, 2, "C", "C2", 1, null },
                    { 173, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8122), null, 4, true, true, false, 3, "C", "C3", 1, null },
                    { 174, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8131), null, 4, true, true, false, 4, "C", "C4", 1, null },
                    { 175, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8142), null, 4, true, true, false, 5, "C", "C5", 1, null },
                    { 176, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8152), null, 4, true, true, false, 6, "C", "C6", 1, null },
                    { 177, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8186), null, 4, true, true, false, 7, "C", "C7", 1, null },
                    { 178, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8200), null, 4, true, true, false, 8, "C", "C8", 1, null },
                    { 179, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8213), null, 4, true, true, false, 9, "C", "C9", 1, null },
                    { 180, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8222), null, 4, true, true, false, 10, "C", "C10", 1, null },
                    { 181, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8234), null, 4, true, true, false, 1, "D", "D1", 1, null },
                    { 182, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8245), null, 4, true, true, false, 2, "D", "D2", 1, null },
                    { 183, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8255), null, 4, true, true, false, 3, "D", "D3", 1, null },
                    { 184, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8265), null, 4, true, true, false, 4, "D", "D4", 1, null },
                    { 185, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8275), null, 4, true, true, false, 5, "D", "D5", 1, null },
                    { 186, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8284), null, 4, true, true, false, 6, "D", "D6", 1, null },
                    { 187, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8295), null, 4, true, true, false, 7, "D", "D7", 1, null },
                    { 188, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8304), null, 4, true, true, false, 8, "D", "D8", 1, null },
                    { 189, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8315), null, 4, true, true, false, 9, "D", "D9", 1, null },
                    { 190, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8325), null, 4, true, true, false, 10, "D", "D10", 1, null },
                    { 191, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8336), null, 4, true, true, false, 1, "E", "E1", 1, null },
                    { 192, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8346), null, 4, true, true, false, 2, "E", "E2", 1, null },
                    { 193, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8357), null, 4, true, true, false, 3, "E", "E3", 1, null },
                    { 194, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8366), null, 4, true, true, false, 4, "E", "E4", 1, null },
                    { 195, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8375), null, 4, true, true, false, 5, "E", "E5", 1, null },
                    { 196, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8386), null, 4, true, true, false, 6, "E", "E6", 1, null },
                    { 197, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8397), null, 4, true, true, false, 7, "E", "E7", 1, null },
                    { 198, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8408), null, 4, true, true, false, 8, "E", "E8", 1, null },
                    { 199, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8418), null, 4, true, true, false, 9, "E", "E9", 1, null },
                    { 200, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8428), null, 4, true, true, false, 10, "E", "E10", 1, null },
                    { 201, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8438), null, 5, true, true, false, 1, "A", "A1", 1, null },
                    { 202, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8450), null, 5, true, true, false, 2, "A", "A2", 1, null },
                    { 203, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8460), null, 5, true, true, false, 3, "A", "A3", 1, null },
                    { 204, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8470), null, 5, true, true, false, 4, "A", "A4", 1, null },
                    { 205, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8482), null, 5, true, true, false, 5, "A", "A5", 1, null },
                    { 206, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8492), null, 5, true, true, false, 6, "A", "A6", 1, null },
                    { 207, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8502), null, 5, true, true, false, 7, "A", "A7", 1, null },
                    { 208, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8513), null, 5, true, true, false, 8, "A", "A8", 1, null },
                    { 209, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8524), null, 5, true, true, false, 9, "A", "A9", 1, null },
                    { 210, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8535), null, 5, true, true, false, 10, "A", "A10", 1, null },
                    { 211, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8569), null, 5, true, true, false, 1, "B", "B1", 1, null },
                    { 212, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8585), null, 5, true, true, false, 2, "B", "B2", 1, null },
                    { 213, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8595), null, 5, true, true, false, 3, "B", "B3", 1, null },
                    { 214, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8605), null, 5, true, true, false, 4, "B", "B4", 1, null },
                    { 215, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8615), null, 5, true, true, false, 5, "B", "B5", 1, null },
                    { 216, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8625), null, 5, true, true, false, 6, "B", "B6", 1, null },
                    { 217, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8635), null, 5, true, true, false, 7, "B", "B7", 1, null },
                    { 218, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8646), null, 5, true, true, false, 8, "B", "B8", 1, null },
                    { 219, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8656), null, 5, true, true, false, 9, "B", "B9", 1, null },
                    { 220, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8667), null, 5, true, true, false, 10, "B", "B10", 1, null },
                    { 221, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8680), null, 5, true, true, false, 1, "C", "C1", 1, null },
                    { 222, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8690), null, 5, true, true, false, 2, "C", "C2", 1, null },
                    { 223, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8700), null, 5, true, true, false, 3, "C", "C3", 1, null },
                    { 224, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8711), null, 5, true, true, false, 4, "C", "C4", 1, null },
                    { 225, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8721), null, 5, true, true, false, 5, "C", "C5", 1, null },
                    { 226, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8731), null, 5, true, true, false, 6, "C", "C6", 1, null },
                    { 227, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8744), null, 5, true, true, false, 7, "C", "C7", 1, null },
                    { 228, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8755), null, 5, true, true, false, 8, "C", "C8", 1, null },
                    { 229, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8764), null, 5, true, true, false, 9, "C", "C9", 1, null },
                    { 230, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8773), null, 5, true, true, false, 10, "C", "C10", 1, null },
                    { 231, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8784), null, 5, true, true, false, 1, "D", "D1", 1, null },
                    { 232, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8796), null, 5, true, true, false, 2, "D", "D2", 1, null },
                    { 233, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8808), null, 5, true, true, false, 3, "D", "D3", 1, null },
                    { 234, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8818), null, 5, true, true, false, 4, "D", "D4", 1, null },
                    { 235, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8830), null, 5, true, true, false, 5, "D", "D5", 1, null },
                    { 236, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8840), null, 5, true, true, false, 6, "D", "D6", 1, null },
                    { 237, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8851), null, 5, true, true, false, 7, "D", "D7", 1, null },
                    { 238, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8861), null, 5, true, true, false, 8, "D", "D8", 1, null },
                    { 239, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8873), null, 5, true, true, false, 9, "D", "D9", 1, null },
                    { 240, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8883), null, 5, true, true, false, 10, "D", "D10", 1, null },
                    { 241, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8894), null, 5, true, true, false, 1, "E", "E1", 1, null },
                    { 242, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8904), null, 5, true, true, false, 2, "E", "E2", 1, null },
                    { 243, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8915), null, 5, true, true, false, 3, "E", "E3", 1, null },
                    { 244, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8925), null, 5, true, true, false, 4, "E", "E4", 1, null },
                    { 245, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8956), null, 5, true, true, false, 5, "E", "E5", 1, null },
                    { 246, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8969), null, 5, true, true, false, 6, "E", "E6", 1, null },
                    { 247, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8980), null, 5, true, true, false, 7, "E", "E7", 1, null },
                    { 248, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8990), null, 5, true, true, false, 8, "E", "E8", 1, null },
                    { 249, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9000), null, 5, true, true, false, 9, "E", "E9", 1, null },
                    { 250, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9011), null, 5, true, true, false, 10, "E", "E10", 1, null },
                    { 251, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9022), null, 6, true, true, false, 1, "A", "A1", 1, null },
                    { 252, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9032), null, 6, true, true, false, 2, "A", "A2", 1, null },
                    { 253, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9042), null, 6, true, true, false, 3, "A", "A3", 1, null },
                    { 254, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9052), null, 6, true, true, false, 4, "A", "A4", 1, null },
                    { 255, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9063), null, 6, true, true, false, 5, "A", "A5", 1, null },
                    { 256, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9074), null, 6, true, true, false, 6, "A", "A6", 1, null },
                    { 257, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9084), null, 6, true, true, false, 7, "A", "A7", 1, null },
                    { 258, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9109), null, 6, true, true, false, 8, "A", "A8", 1, null },
                    { 259, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9123), null, 6, true, true, false, 9, "A", "A9", 1, null },
                    { 260, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9133), null, 6, true, true, false, 10, "A", "A10", 1, null },
                    { 261, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9145), null, 6, true, true, false, 1, "B", "B1", 1, null },
                    { 262, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9174), null, 6, true, true, false, 2, "B", "B2", 1, null },
                    { 263, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9187), null, 6, true, true, false, 3, "B", "B3", 1, null },
                    { 264, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9197), null, 6, true, true, false, 4, "B", "B4", 1, null },
                    { 265, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9209), null, 6, true, true, false, 5, "B", "B5", 1, null },
                    { 266, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9220), null, 6, true, true, false, 6, "B", "B6", 1, null },
                    { 267, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9230), null, 6, true, true, false, 7, "B", "B7", 1, null },
                    { 268, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9241), null, 6, true, true, false, 8, "B", "B8", 1, null },
                    { 269, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9252), null, 6, true, true, false, 9, "B", "B9", 1, null },
                    { 270, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9263), null, 6, true, true, false, 10, "B", "B10", 1, null },
                    { 271, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9273), null, 6, true, true, false, 1, "C", "C1", 1, null },
                    { 272, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9283), null, 6, true, true, false, 2, "C", "C2", 1, null },
                    { 273, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9293), null, 6, true, true, false, 3, "C", "C3", 1, null },
                    { 274, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9304), null, 6, true, true, false, 4, "C", "C4", 1, null },
                    { 275, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9314), null, 6, true, true, false, 5, "C", "C5", 1, null },
                    { 276, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9325), null, 6, true, true, false, 6, "C", "C6", 1, null },
                    { 277, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9337), null, 6, true, true, false, 7, "C", "C7", 1, null },
                    { 278, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9348), null, 6, true, true, false, 8, "C", "C8", 1, null },
                    { 279, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9359), null, 6, true, true, false, 9, "C", "C9", 1, null },
                    { 280, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9369), null, 6, true, true, false, 10, "C", "C10", 1, null },
                    { 281, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9379), null, 6, true, true, false, 1, "D", "D1", 1, null },
                    { 282, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9391), null, 6, true, true, false, 2, "D", "D2", 1, null },
                    { 283, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9401), null, 6, true, true, false, 3, "D", "D3", 1, null },
                    { 284, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9412), null, 6, true, true, false, 4, "D", "D4", 1, null },
                    { 285, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9424), null, 6, true, true, false, 5, "D", "D5", 1, null },
                    { 286, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9434), null, 6, true, true, false, 6, "D", "D6", 1, null },
                    { 287, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9445), null, 6, true, true, false, 7, "D", "D7", 1, null },
                    { 288, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9455), null, 6, true, true, false, 8, "D", "D8", 1, null },
                    { 289, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9466), null, 6, true, true, false, 9, "D", "D9", 1, null },
                    { 290, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9476), null, 6, true, true, false, 10, "D", "D10", 1, null },
                    { 291, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9488), null, 6, true, true, false, 1, "E", "E1", 1, null },
                    { 292, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9498), null, 6, true, true, false, 2, "E", "E2", 1, null },
                    { 293, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9511), null, 6, true, true, false, 3, "E", "E3", 1, null },
                    { 294, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9522), null, 6, true, true, false, 4, "E", "E4", 1, null },
                    { 295, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9534), null, 6, true, true, false, 5, "E", "E5", 1, null },
                    { 296, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9562), null, 6, true, true, false, 6, "E", "E6", 1, null },
                    { 297, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9576), null, 6, true, true, false, 7, "E", "E7", 1, null },
                    { 298, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9587), null, 6, true, true, false, 8, "E", "E8", 1, null },
                    { 299, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9599), null, 6, true, true, false, 9, "E", "E9", 1, null },
                    { 300, null, new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9610), null, 6, true, true, false, 10, "E", "E10", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "HallId", "IsDeleted", "Language", "MovieId", "Price", "ScreenType", "StartTime", "UpdatedAt" },
                values: new object[] { 1, 150, 1, new DateTime(2025, 9, 20, 15, 53, 34, 647, DateTimeKind.Utc).AddTicks(8259), null, 126, 1, false, "EN", 1, 10.00m, "Standard", new DateTime(2025, 9, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "HallId", "Is3D", "IsDeleted", "Language", "MovieId", "Price", "ScreenType", "StartTime", "UpdatedAt" },
                values: new object[] { 2, 200, 1, new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8751), null, 143, 2, true, false, "EN", 2, 12.00m, "3D", new DateTime(2025, 9, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "HallId", "IsDeleted", "Language", "MovieId", "Price", "ScreenType", "StartTime", "UpdatedAt" },
                values: new object[] { 3, 250, 2, new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8771), null, 134, 3, false, "EN", 3, 11.50m, "Standard", new DateTime(2025, 9, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "HallId", "Is3D", "IsDeleted", "Language", "MovieId", "Price", "ScreenType", "StartTime", "UpdatedAt" },
                values: new object[] { 4, 180, 2, new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8781), null, 126, 4, true, false, "EN", 4, 13.00m, "3D", new DateTime(2025, 9, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "HallId", "IsDeleted", "Language", "MovieId", "Price", "ScreenType", "StartTime", "UpdatedAt" },
                values: new object[] { 5, 120, 3, new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8787), null, 150, 5, false, "EN", 5, 14.00m, "Standard", new DateTime(2025, 9, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "HallId", "Is3D", "IsDeleted", "Language", "MovieId", "Price", "ScreenType", "StartTime", "UpdatedAt" },
                values: new object[] { 6, 200, 3, new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8819), null, 130, 6, true, false, "EN", 6, 11.00m, "3D", new DateTime(2025, 9, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DeletedAt", "FinalAmount", "IsDeleted", "MovieId", "NumberOfTickets", "ShowtimeId", "Status", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateTime(2025, 9, 20, 15, 53, 34, 652, DateTimeKind.Utc).AddTicks(3157), new DateTime(2025, 9, 20, 15, 53, 34, 652, DateTimeKind.Utc).AddTicks(3350), null, 20.00m, false, null, 2, 1, 1, 20.00m, null, "user1" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DeletedAt", "FinalAmount", "IsDeleted", "MovieId", "NumberOfTickets", "ShowtimeId", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[] { 2, new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(447), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(456), null, 36.00m, false, null, 3, 2, 36.00m, null, "user2" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DeletedAt", "FinalAmount", "IsDeleted", "MovieId", "NumberOfTickets", "ShowtimeId", "Status", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[] { 3, new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(469), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(471), null, 11.50m, false, null, 1, 3, 1, 11.50m, null, "user3" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DeletedAt", "DiscountAmount", "FinalAmount", "IsDeleted", "MovieId", "NumberOfTickets", "ShowtimeId", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[] { 4, new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(476), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(477), null, 5.00m, 47.00m, false, null, 4, 4, 52.00m, null, "user4" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CreatedAt", "DeletedAt", "FinalAmount", "IsDeleted", "MovieId", "NumberOfTickets", "ShowtimeId", "Status", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[] { 5, new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(482), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(484), null, 28.00m, false, null, 2, 5, 1, 28.00m, null, "user5" });

            migrationBuilder.InsertData(
                table: "BookingSeats",
                columns: new[] { "Id", "BookingId", "CreatedAt", "DeletedAt", "IsDeleted", "SeatId", "SeatPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 20, 15, 53, 34, 654, DateTimeKind.Utc).AddTicks(8288), null, false, 1, 10.00m, null },
                    { 2, 1, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1158), null, false, 2, 10.00m, null },
                    { 3, 2, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1168), null, false, 11, 12.00m, null },
                    { 4, 2, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1172), null, false, 12, 12.00m, null },
                    { 5, 2, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1176), null, false, 13, 12.00m, null },
                    { 6, 3, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1218), null, false, 21, 11.50m, null },
                    { 7, 4, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1224), null, false, 31, 13.00m, null },
                    { 8, 4, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1227), null, false, 32, 13.00m, null },
                    { 9, 4, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1230), null, false, 33, 13.00m, null },
                    { 10, 4, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1240), null, false, 34, 13.00m, null },
                    { 11, 5, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1243), null, false, 41, 14.00m, null },
                    { 12, 5, new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1247), null, false, 42, 14.00m, null }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BookingId", "CouponId", "CreatedAt", "DeletedAt", "Method", "Notes", "PaidAt", "Status", "TransactionId", "UpdatedAt", "UserId" },
                values: new object[] { 1, 20m, 1, null, new DateTime(2025, 9, 20, 15, 53, 34, 656, DateTimeKind.Utc).AddTicks(384), null, 1, null, null, 2, null, null, "user1" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BookingId", "CouponId", "CreatedAt", "DeletedAt", "Method", "Notes", "PaidAt", "TransactionId", "UpdatedAt", "UserId" },
                values: new object[] { 2, 30m, 2, null, new DateTime(2025, 9, 20, 15, 53, 34, 656, DateTimeKind.Utc).AddTicks(5136), null, 2, null, null, null, null, "user2" });

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
                name: "IX_Bookings_MovieId",
                table: "Bookings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowtimeId",
                table: "Bookings",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSeats_BookingId_SeatId",
                table: "BookingSeats",
                columns: new[] { "BookingId", "SeatId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingSeats_SeatId",
                table: "BookingSeats",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_MovieId",
                table: "CartItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShowtimeId",
                table: "CartItems",
                column: "ShowtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CouponId",
                table: "Carts",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_BookingId",
                table: "Coupons",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_CartId",
                table: "Coupons",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieImages_MovieId",
                table: "MovieImages",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CouponId",
                table: "Payments",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CartItemId",
                table: "Seats",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_CinemaId",
                table: "Showtimes",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_HallId",
                table: "Showtimes",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLink_ActorId",
                table: "SocialMediaLink",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLink_CinemaId",
                table: "SocialMediaLink",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOTPs_ApplicationUserId",
                table: "UserOTPs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_MovieId",
                table: "WatchlistItems",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_WatchlistId_MovieId",
                table: "WatchlistItems",
                columns: new[] { "WatchlistId", "MovieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_UserId",
                table: "Watchlists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSeats_Seats_SeatId",
                table: "BookingSeats",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Coupons_CouponId",
                table: "Carts",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Movies_MovieId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieId",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Showtimes_ShowtimeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Bookings_BookingId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Carts_CartId",
                table: "Coupons");

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
                name: "BookingSeats");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieImages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SocialMediaLink");

            migrationBuilder.DropTable(
                name: "UserOTPs");

            migrationBuilder.DropTable(
                name: "WatchlistItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Watchlists");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Showtimes");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
