using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "BookingSeats");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Showtimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "CreatedAt", "DateOfBirth", "DeletedAt", "FirstName", "FullName", "ImageUrl", "IsActive", "IsDeleted", "LastName", "Nationality", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 9, 16, 10, 35, 26, 976, DateTimeKind.Utc).AddTicks(8616), null, null, "Robert", "Robert Downey Jr.", null, true, false, "Downey Jr.", null, null },
                    { 2, null, new DateTime(2025, 9, 16, 10, 35, 26, 977, DateTimeKind.Utc).AddTicks(1831), null, null, "Scarlett", "Scarlett Johansson", null, true, false, "Johansson", null, null },
                    { 3, null, new DateTime(2025, 9, 16, 10, 35, 26, 977, DateTimeKind.Utc).AddTicks(1848), null, null, "Chris", "Chris Hemsworth", null, true, false, "Hemsworth", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "City", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { "admin-1", 0, "", null, null, "5a4c7982-8ca7-4cd3-a9e6-eda39b793d2a", new DateTime(2025, 9, 16, 10, 35, 26, 966, DateTimeKind.Utc).AddTicks(9837), null, "admin@voxtics.com", true, 0, false, null, "", "ADMIN@VOXTICS.COM", "ADMIN@VOXTICS.COM", "PASTE_ADMIN_HASH_HERE", null, false, "11111111-1111-1111-1111-111111111111", null, null, false, "admin@voxtics.com", null },
                    { "user-1", 0, "", null, null, "57d8273a-ae50-4330-b05a-a124ae797f17", new DateTime(2025, 9, 16, 10, 35, 26, 969, DateTimeKind.Utc).AddTicks(1653), null, "user@voxtics.com", true, 0, false, null, "", "USER@VOXTICS.COM", "USER@VOXTICS.COM", "PASTE_USER_HASH_HERE", null, false, "22222222-2222-2222-2222-222222222222", null, null, false, "user@voxtics.com", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 16, 10, 35, 26, 970, DateTimeKind.Utc).AddTicks(7411), null, null, true, false, "Action", "action", null },
                    { 2, new DateTime(2025, 9, 16, 10, 35, 26, 970, DateTimeKind.Utc).AddTicks(9627), null, null, true, false, "Drama", "drama", null },
                    { 3, new DateTime(2025, 9, 16, 10, 35, 26, 970, DateTimeKind.Utc).AddTicks(9631), null, null, true, false, "Comedy", "comedy", null }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Description", "Email", "ImageUrl", "IsActive", "IsDeleted", "Name", "Phone", "PostalCode", "State", "UpdatedAt", "Website" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 972, DateTimeKind.Utc).AddTicks(8851), null, null, null, null, true, false, "Grand Cinema", null, null, null, null, null },
                    { 2, null, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 972, DateTimeKind.Utc).AddTicks(9990), null, null, null, null, true, false, "Downtown Cinema", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "CinemaId", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "TotalSeats", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), null, null, true, false, "Hall 1", 0, null },
                    { 2, 1, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), null, null, true, false, "Hall 2", 0, null },
                    { 3, 2, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), null, null, true, false, "Hall A", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRating", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "ImageUrl", "IsDeleted", "IsFeatured", "Language", "Price", "Rating", "ReleaseDate", "ShortDescription", "Status", "Title", "TrailerImageUrl", "TrailerUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, 1, null, new DateTime(2025, 9, 16, 10, 35, 26, 971, DateTimeKind.Utc).AddTicks(7401), null, "", "Russo Brothers", 181, null, false, false, "EN", 10m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 1, "Avengers: Endgame", null, null, null },
                    { 2, null, 1, null, new DateTime(2025, 9, 16, 10, 35, 26, 972, DateTimeKind.Utc).AddTicks(4015), null, "", "Jon Favreau", 126, null, false, false, "EN", 8m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 2, "Iron Man", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(8929), null, false, 1, null },
                    { 2, 2, new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(9919), null, false, 1, null },
                    { 3, 1, new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(9922), null, false, 2, null }
                });

            migrationBuilder.InsertData(
                table: "MovieCategories",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 16, 10, 35, 26, 976, DateTimeKind.Utc).AddTicks(2783), null, false, 1, null },
                    { 2, 1, new DateTime(2025, 9, 16, 10, 35, 26, 976, DateTimeKind.Utc).AddTicks(3958), null, false, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "BookingId", "CartItemId", "CreatedAt", "DeletedAt", "HallId", "IsActive", "IsDeleted", "Row", "RowNumber", "SeatNumber", "SeatNumberInRow", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(1428), null, 1, true, false, null, 0, "1A", 0, 1, null },
                    { 2, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(2846), null, 1, true, false, null, 0, "1B", 0, 1, null },
                    { 3, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3019), null, 1, true, false, null, 0, "1C", 0, 1, null },
                    { 4, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3027), null, 1, true, false, null, 0, "1D", 0, 1, null },
                    { 5, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3031), null, 1, true, false, null, 0, "1E", 0, 1, null },
                    { 6, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3048), null, 1, true, false, null, 0, "1F", 0, 1, null },
                    { 7, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3052), null, 1, true, false, null, 0, "1G", 0, 1, null },
                    { 8, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3081), null, 1, true, false, null, 0, "1H", 0, 1, null },
                    { 9, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3085), null, 1, true, false, null, 0, "1I", 0, 1, null },
                    { 10, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3090), null, 1, true, false, null, 0, "1J", 0, 1, null },
                    { 11, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3095), null, 1, true, false, null, 0, "2A", 0, 1, null },
                    { 12, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3098), null, 1, true, false, null, 0, "2B", 0, 1, null },
                    { 13, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3101), null, 1, true, false, null, 0, "2C", 0, 1, null },
                    { 14, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3105), null, 1, true, false, null, 0, "2D", 0, 1, null },
                    { 15, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3108), null, 1, true, false, null, 0, "2E", 0, 1, null },
                    { 16, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3111), null, 1, true, false, null, 0, "2F", 0, 1, null },
                    { 17, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3114), null, 1, true, false, null, 0, "2G", 0, 1, null },
                    { 18, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3119), null, 1, true, false, null, 0, "2H", 0, 1, null },
                    { 19, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3123), null, 1, true, false, null, 0, "2I", 0, 1, null },
                    { 20, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3126), null, 1, true, false, null, 0, "2J", 0, 1, null },
                    { 21, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3130), null, 1, true, false, null, 0, "3A", 0, 1, null },
                    { 22, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3133), null, 1, true, false, null, 0, "3B", 0, 1, null },
                    { 23, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3136), null, 1, true, false, null, 0, "3C", 0, 1, null },
                    { 24, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3139), null, 1, true, false, null, 0, "3D", 0, 1, null },
                    { 25, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3142), null, 1, true, false, null, 0, "3E", 0, 1, null },
                    { 26, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3146), null, 1, true, false, null, 0, "3F", 0, 1, null },
                    { 27, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3149), null, 1, true, false, null, 0, "3G", 0, 1, null },
                    { 28, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3152), null, 1, true, false, null, 0, "3H", 0, 1, null },
                    { 29, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3155), null, 1, true, false, null, 0, "3I", 0, 1, null },
                    { 30, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3158), null, 1, true, false, null, 0, "3J", 0, 1, null },
                    { 31, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3162), null, 1, true, false, null, 0, "4A", 0, 1, null },
                    { 32, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3165), null, 1, true, false, null, 0, "4B", 0, 1, null },
                    { 33, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3168), null, 1, true, false, null, 0, "4C", 0, 1, null },
                    { 34, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3173), null, 1, true, false, null, 0, "4D", 0, 1, null },
                    { 35, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3176), null, 1, true, false, null, 0, "4E", 0, 1, null },
                    { 36, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3180), null, 1, true, false, null, 0, "4F", 0, 1, null },
                    { 37, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3183), null, 1, true, false, null, 0, "4G", 0, 1, null },
                    { 38, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3186), null, 1, true, false, null, 0, "4H", 0, 1, null },
                    { 39, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3189), null, 1, true, false, null, 0, "4I", 0, 1, null },
                    { 40, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3192), null, 1, true, false, null, 0, "4J", 0, 1, null },
                    { 41, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3195), null, 1, true, false, null, 0, "5A", 0, 1, null },
                    { 42, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3211), null, 1, true, false, null, 0, "5B", 0, 1, null },
                    { 43, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3214), null, 1, true, false, null, 0, "5C", 0, 1, null },
                    { 44, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3218), null, 1, true, false, null, 0, "5D", 0, 1, null },
                    { 45, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3221), null, 1, true, false, null, 0, "5E", 0, 1, null },
                    { 46, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3224), null, 1, true, false, null, 0, "5F", 0, 1, null },
                    { 47, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3227), null, 1, true, false, null, 0, "5G", 0, 1, null },
                    { 48, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3230), null, 1, true, false, null, 0, "5H", 0, 1, null },
                    { 49, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3233), null, 1, true, false, null, 0, "5I", 0, 1, null },
                    { 50, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3236), null, 1, true, false, null, 0, "5J", 0, 1, null },
                    { 51, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3240), null, 2, true, false, null, 0, "1A", 0, 1, null },
                    { 52, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3243), null, 2, true, false, null, 0, "1B", 0, 1, null },
                    { 53, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3246), null, 2, true, false, null, 0, "1C", 0, 1, null },
                    { 54, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3249), null, 2, true, false, null, 0, "1D", 0, 1, null },
                    { 55, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3252), null, 2, true, false, null, 0, "1E", 0, 1, null },
                    { 56, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3256), null, 2, true, false, null, 0, "1F", 0, 1, null },
                    { 57, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3259), null, 2, true, false, null, 0, "1G", 0, 1, null },
                    { 58, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3262), null, 2, true, false, null, 0, "1H", 0, 1, null },
                    { 59, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3265), null, 2, true, false, null, 0, "1I", 0, 1, null },
                    { 60, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3268), null, 2, true, false, null, 0, "1J", 0, 1, null },
                    { 61, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3271), null, 2, true, false, null, 0, "2A", 0, 1, null },
                    { 62, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3274), null, 2, true, false, null, 0, "2B", 0, 1, null },
                    { 63, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3277), null, 2, true, false, null, 0, "2C", 0, 1, null },
                    { 64, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3281), null, 2, true, false, null, 0, "2D", 0, 1, null },
                    { 65, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3284), null, 2, true, false, null, 0, "2E", 0, 1, null },
                    { 66, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3289), null, 2, true, false, null, 0, "2F", 0, 1, null },
                    { 67, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3293), null, 2, true, false, null, 0, "2G", 0, 1, null },
                    { 68, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3296), null, 2, true, false, null, 0, "2H", 0, 1, null },
                    { 69, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3299), null, 2, true, false, null, 0, "2I", 0, 1, null },
                    { 70, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3302), null, 2, true, false, null, 0, "2J", 0, 1, null },
                    { 71, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3305), null, 2, true, false, null, 0, "3A", 0, 1, null },
                    { 72, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3308), null, 2, true, false, null, 0, "3B", 0, 1, null },
                    { 73, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3311), null, 2, true, false, null, 0, "3C", 0, 1, null },
                    { 74, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3314), null, 2, true, false, null, 0, "3D", 0, 1, null },
                    { 75, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3326), null, 2, true, false, null, 0, "3E", 0, 1, null },
                    { 76, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3329), null, 2, true, false, null, 0, "3F", 0, 1, null },
                    { 77, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3332), null, 2, true, false, null, 0, "3G", 0, 1, null },
                    { 78, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3335), null, 2, true, false, null, 0, "3H", 0, 1, null },
                    { 79, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3338), null, 2, true, false, null, 0, "3I", 0, 1, null },
                    { 80, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3342), null, 2, true, false, null, 0, "3J", 0, 1, null },
                    { 81, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3345), null, 2, true, false, null, 0, "4A", 0, 1, null },
                    { 82, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3348), null, 2, true, false, null, 0, "4B", 0, 1, null },
                    { 83, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3351), null, 2, true, false, null, 0, "4C", 0, 1, null },
                    { 84, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3354), null, 2, true, false, null, 0, "4D", 0, 1, null },
                    { 85, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3357), null, 2, true, false, null, 0, "4E", 0, 1, null },
                    { 86, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3360), null, 2, true, false, null, 0, "4F", 0, 1, null },
                    { 87, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3364), null, 2, true, false, null, 0, "4G", 0, 1, null },
                    { 88, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3367), null, 2, true, false, null, 0, "4H", 0, 1, null },
                    { 89, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3370), null, 2, true, false, null, 0, "4I", 0, 1, null },
                    { 90, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3373), null, 2, true, false, null, 0, "4J", 0, 1, null },
                    { 91, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3376), null, 2, true, false, null, 0, "5A", 0, 1, null },
                    { 92, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3379), null, 2, true, false, null, 0, "5B", 0, 1, null },
                    { 93, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3382), null, 2, true, false, null, 0, "5C", 0, 1, null },
                    { 94, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3385), null, 2, true, false, null, 0, "5D", 0, 1, null },
                    { 95, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3389), null, 2, true, false, null, 0, "5E", 0, 1, null },
                    { 96, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3392), null, 2, true, false, null, 0, "5F", 0, 1, null },
                    { 97, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3395), null, 2, true, false, null, 0, "5G", 0, 1, null },
                    { 98, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3398), null, 2, true, false, null, 0, "5H", 0, 1, null },
                    { 99, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3402), null, 2, true, false, null, 0, "5I", 0, 1, null },
                    { 100, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3405), null, 2, true, false, null, 0, "5J", 0, 1, null },
                    { 101, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3408), null, 3, true, false, null, 0, "1A", 0, 1, null },
                    { 102, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3411), null, 3, true, false, null, 0, "1B", 0, 1, null },
                    { 103, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3414), null, 3, true, false, null, 0, "1C", 0, 1, null },
                    { 104, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3417), null, 3, true, false, null, 0, "1D", 0, 1, null },
                    { 105, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3421), null, 3, true, false, null, 0, "1E", 0, 1, null },
                    { 106, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3424), null, 3, true, false, null, 0, "1F", 0, 1, null },
                    { 107, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3427), null, 3, true, false, null, 0, "1G", 0, 1, null },
                    { 108, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3430), null, 3, true, false, null, 0, "1H", 0, 1, null },
                    { 109, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3433), null, 3, true, false, null, 0, "1I", 0, 1, null },
                    { 110, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3436), null, 3, true, false, null, 0, "1J", 0, 1, null },
                    { 111, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3440), null, 3, true, false, null, 0, "2A", 0, 1, null },
                    { 112, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3443), null, 3, true, false, null, 0, "2B", 0, 1, null },
                    { 113, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3455), null, 3, true, false, null, 0, "2C", 0, 1, null },
                    { 114, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3458), null, 3, true, false, null, 0, "2D", 0, 1, null },
                    { 115, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3461), null, 3, true, false, null, 0, "2E", 0, 1, null },
                    { 116, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3464), null, 3, true, false, null, 0, "2F", 0, 1, null },
                    { 117, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3467), null, 3, true, false, null, 0, "2G", 0, 1, null },
                    { 118, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3471), null, 3, true, false, null, 0, "2H", 0, 1, null },
                    { 119, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3474), null, 3, true, false, null, 0, "2I", 0, 1, null },
                    { 120, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3477), null, 3, true, false, null, 0, "2J", 0, 1, null },
                    { 121, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3480), null, 3, true, false, null, 0, "3A", 0, 1, null },
                    { 122, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3484), null, 3, true, false, null, 0, "3B", 0, 1, null },
                    { 123, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3487), null, 3, true, false, null, 0, "3C", 0, 1, null },
                    { 124, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3490), null, 3, true, false, null, 0, "3D", 0, 1, null },
                    { 125, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3493), null, 3, true, false, null, 0, "3E", 0, 1, null },
                    { 126, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3496), null, 3, true, false, null, 0, "3F", 0, 1, null },
                    { 127, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3499), null, 3, true, false, null, 0, "3G", 0, 1, null },
                    { 128, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3502), null, 3, true, false, null, 0, "3H", 0, 1, null },
                    { 129, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3505), null, 3, true, false, null, 0, "3I", 0, 1, null },
                    { 130, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3511), null, 3, true, false, null, 0, "3J", 0, 1, null },
                    { 131, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3515), null, 3, true, false, null, 0, "4A", 0, 1, null },
                    { 132, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3518), null, 3, true, false, null, 0, "4B", 0, 1, null },
                    { 133, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3521), null, 3, true, false, null, 0, "4C", 0, 1, null },
                    { 134, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3524), null, 3, true, false, null, 0, "4D", 0, 1, null },
                    { 135, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3527), null, 3, true, false, null, 0, "4E", 0, 1, null },
                    { 136, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3530), null, 3, true, false, null, 0, "4F", 0, 1, null },
                    { 137, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3534), null, 3, true, false, null, 0, "4G", 0, 1, null },
                    { 138, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3537), null, 3, true, false, null, 0, "4H", 0, 1, null },
                    { 139, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3540), null, 3, true, false, null, 0, "4I", 0, 1, null },
                    { 140, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3543), null, 3, true, false, null, 0, "4J", 0, 1, null },
                    { 141, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3562), null, 3, true, false, null, 0, "5A", 0, 1, null },
                    { 142, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3565), null, 3, true, false, null, 0, "5B", 0, 1, null },
                    { 143, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3568), null, 3, true, false, null, 0, "5C", 0, 1, null },
                    { 144, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3571), null, 3, true, false, null, 0, "5D", 0, 1, null },
                    { 145, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3574), null, 3, true, false, null, 0, "5E", 0, 1, null },
                    { 146, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3577), null, 3, true, false, null, 0, "5F", 0, 1, null },
                    { 147, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3581), null, 3, true, false, null, 0, "5G", 0, 1, null },
                    { 148, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3584), null, 3, true, false, null, 0, "5H", 0, 1, null },
                    { 149, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3587), null, 3, true, false, null, 0, "5I", 0, 1, null },
                    { 150, null, null, new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3590), null, 3, true, false, null, 0, "5J", 0, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaHallId", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "EndTime", "HallId", "Is3D", "IsCancelled", "IsDeleted", "Language", "MovieId", "Price", "PricePerSeat", "ScreenType", "StartTime", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 50, 1, 1, new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(972), null, 120, new DateTime(2025, 9, 16, 16, 0, 0, 0, DateTimeKind.Utc), 1, false, false, false, "EN", 1, 10m, 0, "Standard", new DateTime(2025, 9, 16, 14, 0, 0, 0, DateTimeKind.Utc), 0, null },
                    { 2, 50, 2, 1, new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(5648), null, 120, new DateTime(2025, 9, 16, 19, 0, 0, 0, DateTimeKind.Utc), 2, false, false, false, "EN", 2, 12m, 0, "Standard", new DateTime(2025, 9, 16, 17, 0, 0, 0, DateTimeKind.Utc), 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BookingId",
                table: "Seats",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_BookingId",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Seats");

            migrationBuilder.AddColumn<string>(
                name: "SeatNumber",
                table: "BookingSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seats",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
