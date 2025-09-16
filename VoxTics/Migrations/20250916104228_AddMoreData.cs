using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6470));

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "CreatedAt", "DateOfBirth", "DeletedAt", "FirstName", "FullName", "ImageUrl", "IsActive", "IsDeleted", "LastName", "Nationality", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6476), null, null, "Mark", "Mark Ruffalo", null, true, false, "Ruffalo", null, null },
                    { 5, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6480), null, null, "Chris", "Chris Evans", null, true, false, "Evans", null, null },
                    { 6, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6483), null, null, "Jeremy", "Jeremy Renner", null, true, false, "Renner", null, null },
                    { 7, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6487), null, null, "Tom", "Tom Holland", null, true, false, "Holland", null, null },
                    { 8, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6490), null, null, "Benedict", "Benedict Cumberbatch", null, true, false, "Cumberbatch", null, null },
                    { 9, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6494), null, null, "Elizabeth", "Elizabeth Olsen", null, true, false, "Olsen", null, null },
                    { 10, null, new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6498), null, null, "Paul", "Paul Rudd", null, true, false, "Rudd", null, null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "f2b50f64-1178-4e6f-ac6b-ffe2a1514a20", new DateTime(2025, 9, 16, 10, 42, 23, 194, DateTimeKind.Utc).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "dd6323b2-534b-40a9-b718-9c7a819dd3af", new DateTime(2025, 9, 16, 10, 42, 23, 196, DateTimeKind.Utc).AddTicks(9863) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "City", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "user-2", 0, "", null, null, "0500ffdf-f0d8-4d3c-a7d4-a7b3c561fb5f", new DateTime(2025, 9, 16, 10, 42, 23, 196, DateTimeKind.Utc).AddTicks(9900), null, "jane.doe@voxtics.com", true, 0, false, null, "", "JANE.DOE@VOXTICS.COM", "JANE.DOE@VOXTICS.COM", "PASTE_USER_HASH_HERE", null, false, "33333333-3333-3333-3333-333333333333", null, null, false, "jane.doe@voxtics.com", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(7380), null, null, true, false, "Horror", "horror", null },
                    { 5, new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(7383), null, null, true, false, "Sci-Fi", "sci-fi", null }
                });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 202, DateTimeKind.Utc).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 202, DateTimeKind.Utc).AddTicks(1279));

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "DeletedAt", "Description", "Email", "ImageUrl", "IsActive", "IsDeleted", "Name", "Phone", "PostalCode", "State", "UpdatedAt", "Website" },
                values: new object[] { 3, null, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 202, DateTimeKind.Utc).AddTicks(1282), null, null, null, null, true, false, "City Lights Cinema", null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "CinemaId", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "TotalSeats", "UpdatedAt" },
                values: new object[] { 4, 2, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), null, null, true, false, "Hall B", 0, null });

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActorId", "CreatedAt", "MovieId" },
                values: new object[] { 3, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7262), 1 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[] { 4, 1, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7263), null, false, 2, null });

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 200, DateTimeKind.Utc).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ReleaseDate" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5463), new DateTime(2010, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRating", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "ImageUrl", "IsDeleted", "IsFeatured", "Language", "Price", "Rating", "ReleaseDate", "ShortDescription", "Status", "Title", "TrailerImageUrl", "TrailerUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, null, 1, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5643), null, "", "Cate Shortland", 134, null, false, false, "EN", 11m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 1, "Black Widow", null, null, null },
                    { 6, null, 1, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5647), null, "", "Taika Waititi", 130, null, false, false, "EN", 10m, 0m, new DateTime(2022, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 2, "Thor: Ragnarok", null, null, null },
                    { 7, null, 1, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5656), null, "", "Anthony Russo", 147, null, false, false, "EN", 9m, 0m, new DateTime(2021, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 2, "Captain America: Civil War", null, null, null },
                    { 9, null, 2, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5664), null, "", "Matt Shakman", 120, null, false, false, "EN", 15m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 1, "WandaVision", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4198));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4209));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4425));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4658));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 204, DateTimeKind.Utc).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "CinemaId", "CreatedAt", "DeletedAt", "Description", "IsActive", "IsDeleted", "Name", "TotalSeats", "UpdatedAt" },
                values: new object[] { 5, 3, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), null, null, true, false, "Hall Main", 0, null });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, 2, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7267), null, false, 5, null },
                    { 8, 3, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7268), null, false, 6, null },
                    { 9, 5, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7269), null, false, 7, null },
                    { 11, 9, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7271), null, false, 9, null }
                });

            migrationBuilder.InsertData(
                table: "MovieCategories",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3370), null, false, 5, null },
                    { 6, 1, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3372), null, false, 6, null },
                    { 7, 1, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3373), null, false, 7, null },
                    { 9, 2, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3375), null, false, 9, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRating", "CategoryId", "Country", "CreatedAt", "DeletedAt", "Description", "Director", "Duration", "ImageUrl", "IsDeleted", "IsFeatured", "Language", "Price", "Rating", "ReleaseDate", "ShortDescription", "Status", "Title", "TrailerImageUrl", "TrailerUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, null, 5, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5635), null, "", "Jon Watts", 148, null, false, false, "EN", 12m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 1, "Spider-Man: No Way Home", null, null, null },
                    { 4, null, 5, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5640), null, "", "Scott Derrickson", 115, null, false, false, "EN", 9m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 2, "Doctor Strange", null, null, null },
                    { 8, null, 5, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5660), null, "", "Peyton Reed", 117, null, false, false, "EN", 8m, 0m, new DateTime(2020, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 2, "Ant-Man", null, null, null },
                    { 10, null, 5, null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5667), null, "", "Sam Raimi", 150, null, false, false, "EN", 14m, 0m, new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc), "", 1, "Doctor Strange in the Multiverse of Madness", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "BookingId", "CartItemId", "CreatedAt", "DeletedAt", "HallId", "IsActive", "IsDeleted", "Row", "RowNumber", "SeatNumber", "SeatNumberInRow", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 151, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4673), null, 4, true, false, null, 0, "1A", 0, 1, null },
                    { 152, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4676), null, 4, true, false, null, 0, "1B", 0, 1, null },
                    { 153, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4679), null, 4, true, false, null, 0, "1C", 0, 1, null },
                    { 154, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4682), null, 4, true, false, null, 0, "1D", 0, 1, null },
                    { 155, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4685), null, 4, true, false, null, 0, "1E", 0, 1, null },
                    { 156, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4688), null, 4, true, false, null, 0, "1F", 0, 1, null },
                    { 157, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4691), null, 4, true, false, null, 0, "1G", 0, 1, null },
                    { 158, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4694), null, 4, true, false, null, 0, "1H", 0, 1, null },
                    { 159, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4697), null, 4, true, false, null, 0, "1I", 0, 1, null },
                    { 160, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4699), null, 4, true, false, null, 0, "1J", 0, 1, null },
                    { 161, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4702), null, 4, true, false, null, 0, "2A", 0, 1, null },
                    { 162, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4705), null, 4, true, false, null, 0, "2B", 0, 1, null },
                    { 163, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4708), null, 4, true, false, null, 0, "2C", 0, 1, null },
                    { 164, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4711), null, 4, true, false, null, 0, "2D", 0, 1, null },
                    { 165, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4714), null, 4, true, false, null, 0, "2E", 0, 1, null },
                    { 166, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4717), null, 4, true, false, null, 0, "2F", 0, 1, null },
                    { 167, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4729), null, 4, true, false, null, 0, "2G", 0, 1, null },
                    { 168, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4733), null, 4, true, false, null, 0, "2H", 0, 1, null },
                    { 169, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4736), null, 4, true, false, null, 0, "2I", 0, 1, null },
                    { 170, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4739), null, 4, true, false, null, 0, "2J", 0, 1, null },
                    { 171, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4742), null, 4, true, false, null, 0, "3A", 0, 1, null },
                    { 172, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4745), null, 4, true, false, null, 0, "3B", 0, 1, null },
                    { 173, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4748), null, 4, true, false, null, 0, "3C", 0, 1, null },
                    { 174, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4750), null, 4, true, false, null, 0, "3D", 0, 1, null },
                    { 175, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4753), null, 4, true, false, null, 0, "3E", 0, 1, null },
                    { 176, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4756), null, 4, true, false, null, 0, "3F", 0, 1, null },
                    { 177, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4759), null, 4, true, false, null, 0, "3G", 0, 1, null },
                    { 178, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4762), null, 4, true, false, null, 0, "3H", 0, 1, null },
                    { 179, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4765), null, 4, true, false, null, 0, "3I", 0, 1, null },
                    { 180, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4768), null, 4, true, false, null, 0, "3J", 0, 1, null },
                    { 181, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4771), null, 4, true, false, null, 0, "4A", 0, 1, null },
                    { 182, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4774), null, 4, true, false, null, 0, "4B", 0, 1, null },
                    { 183, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4777), null, 4, true, false, null, 0, "4C", 0, 1, null },
                    { 184, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4780), null, 4, true, false, null, 0, "4D", 0, 1, null },
                    { 185, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4782), null, 4, true, false, null, 0, "4E", 0, 1, null },
                    { 186, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4785), null, 4, true, false, null, 0, "4F", 0, 1, null },
                    { 187, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4788), null, 4, true, false, null, 0, "4G", 0, 1, null },
                    { 188, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4791), null, 4, true, false, null, 0, "4H", 0, 1, null },
                    { 189, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4794), null, 4, true, false, null, 0, "4I", 0, 1, null },
                    { 190, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4797), null, 4, true, false, null, 0, "4J", 0, 1, null },
                    { 191, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4800), null, 4, true, false, null, 0, "5A", 0, 1, null },
                    { 192, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4803), null, 4, true, false, null, 0, "5B", 0, 1, null },
                    { 193, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4806), null, 4, true, false, null, 0, "5C", 0, 1, null },
                    { 194, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4809), null, 4, true, false, null, 0, "5D", 0, 1, null },
                    { 195, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4812), null, 4, true, false, null, 0, "5E", 0, 1, null },
                    { 196, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4814), null, 4, true, false, null, 0, "5F", 0, 1, null },
                    { 197, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4817), null, 4, true, false, null, 0, "5G", 0, 1, null },
                    { 198, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4820), null, 4, true, false, null, 0, "5H", 0, 1, null },
                    { 199, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4823), null, 4, true, false, null, 0, "5I", 0, 1, null },
                    { 200, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4826), null, 4, true, false, null, 0, "5J", 0, 1, null }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, 7, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7265), null, false, 3, null },
                    { 6, 8, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7266), null, false, 4, null },
                    { 10, 10, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7270), null, false, 8, null },
                    { 12, 8, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7273), null, false, 10, null }
                });

            migrationBuilder.InsertData(
                table: "MovieCategories",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "IsDeleted", "MovieId", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, 5, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3368), null, false, 3, null },
                    { 4, 5, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3369), null, false, 4, null },
                    { 8, 5, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3374), null, false, 8, null },
                    { 10, 5, new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3376), null, false, 10, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "BookingId", "CartItemId", "CreatedAt", "DeletedAt", "HallId", "IsActive", "IsDeleted", "Row", "RowNumber", "SeatNumber", "SeatNumberInRow", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 201, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4829), null, 5, true, false, null, 0, "1A", 0, 1, null },
                    { 202, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4832), null, 5, true, false, null, 0, "1B", 0, 1, null },
                    { 203, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4835), null, 5, true, false, null, 0, "1C", 0, 1, null },
                    { 204, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4838), null, 5, true, false, null, 0, "1D", 0, 1, null },
                    { 205, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4851), null, 5, true, false, null, 0, "1E", 0, 1, null },
                    { 206, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4855), null, 5, true, false, null, 0, "1F", 0, 1, null },
                    { 207, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4858), null, 5, true, false, null, 0, "1G", 0, 1, null },
                    { 208, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4861), null, 5, true, false, null, 0, "1H", 0, 1, null },
                    { 209, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4863), null, 5, true, false, null, 0, "1I", 0, 1, null },
                    { 210, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4866), null, 5, true, false, null, 0, "1J", 0, 1, null },
                    { 211, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4870), null, 5, true, false, null, 0, "2A", 0, 1, null },
                    { 212, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4873), null, 5, true, false, null, 0, "2B", 0, 1, null },
                    { 213, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4876), null, 5, true, false, null, 0, "2C", 0, 1, null },
                    { 214, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4879), null, 5, true, false, null, 0, "2D", 0, 1, null },
                    { 215, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4882), null, 5, true, false, null, 0, "2E", 0, 1, null },
                    { 216, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4885), null, 5, true, false, null, 0, "2F", 0, 1, null },
                    { 217, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4887), null, 5, true, false, null, 0, "2G", 0, 1, null },
                    { 218, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4890), null, 5, true, false, null, 0, "2H", 0, 1, null },
                    { 219, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4893), null, 5, true, false, null, 0, "2I", 0, 1, null },
                    { 220, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4896), null, 5, true, false, null, 0, "2J", 0, 1, null },
                    { 221, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4899), null, 5, true, false, null, 0, "3A", 0, 1, null },
                    { 222, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4902), null, 5, true, false, null, 0, "3B", 0, 1, null },
                    { 223, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4905), null, 5, true, false, null, 0, "3C", 0, 1, null },
                    { 224, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4908), null, 5, true, false, null, 0, "3D", 0, 1, null },
                    { 225, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4911), null, 5, true, false, null, 0, "3E", 0, 1, null },
                    { 226, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4914), null, 5, true, false, null, 0, "3F", 0, 1, null },
                    { 227, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4917), null, 5, true, false, null, 0, "3G", 0, 1, null },
                    { 228, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4920), null, 5, true, false, null, 0, "3H", 0, 1, null },
                    { 229, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4923), null, 5, true, false, null, 0, "3I", 0, 1, null },
                    { 230, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4926), null, 5, true, false, null, 0, "3J", 0, 1, null },
                    { 231, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4929), null, 5, true, false, null, 0, "4A", 0, 1, null },
                    { 232, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4931), null, 5, true, false, null, 0, "4B", 0, 1, null },
                    { 233, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4934), null, 5, true, false, null, 0, "4C", 0, 1, null },
                    { 234, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4937), null, 5, true, false, null, 0, "4D", 0, 1, null },
                    { 235, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4940), null, 5, true, false, null, 0, "4E", 0, 1, null },
                    { 236, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4943), null, 5, true, false, null, 0, "4F", 0, 1, null },
                    { 237, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4946), null, 5, true, false, null, 0, "4G", 0, 1, null },
                    { 238, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4949), null, 5, true, false, null, 0, "4H", 0, 1, null },
                    { 239, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4952), null, 5, true, false, null, 0, "4I", 0, 1, null },
                    { 240, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4955), null, 5, true, false, null, 0, "4J", 0, 1, null },
                    { 241, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4958), null, 5, true, false, null, 0, "5A", 0, 1, null },
                    { 242, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4961), null, 5, true, false, null, 0, "5B", 0, 1, null },
                    { 243, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4973), null, 5, true, false, null, 0, "5C", 0, 1, null },
                    { 244, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4976), null, 5, true, false, null, 0, "5D", 0, 1, null },
                    { 245, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4979), null, 5, true, false, null, 0, "5E", 0, 1, null },
                    { 246, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4982), null, 5, true, false, null, 0, "5F", 0, 1, null },
                    { 247, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4985), null, 5, true, false, null, 0, "5G", 0, 1, null },
                    { 248, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4987), null, 5, true, false, null, 0, "5H", 0, 1, null },
                    { 249, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4990), null, 5, true, false, null, 0, "5I", 0, 1, null },
                    { 250, null, null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4993), null, 5, true, false, null, 0, "5J", 0, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "CinemaHallId", "CinemaId", "CreatedAt", "DeletedAt", "Duration", "EndTime", "HallId", "Is3D", "IsCancelled", "IsDeleted", "Language", "MovieId", "Price", "PricePerSeat", "ScreenType", "StartTime", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, 50, 3, 2, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(383), null, 120, new DateTime(2025, 9, 16, 17, 0, 0, 0, DateTimeKind.Utc), 3, false, false, false, "EN", 3, 15m, 0, "Standard", new DateTime(2025, 9, 16, 15, 0, 0, 0, DateTimeKind.Utc), 0, null },
                    { 4, 50, 4, 2, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(386), null, 120, new DateTime(2025, 9, 16, 20, 0, 0, 0, DateTimeKind.Utc), 4, false, false, false, "EN", 4, 9m, 0, "Standard", new DateTime(2025, 9, 16, 18, 0, 0, 0, DateTimeKind.Utc), 0, null },
                    { 5, 50, 5, 3, new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(389), null, 120, new DateTime(2025, 9, 16, 18, 0, 0, 0, DateTimeKind.Utc), 5, false, false, false, "EN", 5, 11m, 0, "Standard", new DateTime(2025, 9, 16, 16, 0, 0, 0, DateTimeKind.Utc), 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 976, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 977, DateTimeKind.Utc).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 977, DateTimeKind.Utc).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "5a4c7982-8ca7-4cd3-a9e6-eda39b793d2a", new DateTime(2025, 9, 16, 10, 35, 26, 966, DateTimeKind.Utc).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "57d8273a-ae50-4330-b05a-a124ae797f17", new DateTime(2025, 9, 16, 10, 35, 26, 969, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 970, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 970, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 970, DateTimeKind.Utc).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 972, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 972, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActorId", "CreatedAt", "MovieId" },
                values: new object[] { 1, new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(9922), 2 });

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 976, DateTimeKind.Utc).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 976, DateTimeKind.Utc).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 971, DateTimeKind.Utc).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ReleaseDate" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 35, 26, 972, DateTimeKind.Utc).AddTicks(4015), new DateTime(2025, 9, 16, 12, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3192));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3243));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3259));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3268));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3293));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3326));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3332));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3345));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3417));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3464));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3577));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 974, DateTimeKind.Utc).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 35, 26, 975, DateTimeKind.Utc).AddTicks(5648));
        }
    }
}
