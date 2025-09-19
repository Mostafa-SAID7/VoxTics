using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class addSomeEdits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_BookingId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "BookingSeats");

            migrationBuilder.DropColumn(
                name: "BookingNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CancellationDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "TrailerImageUrl",
                table: "Movies",
                newName: "MainImage");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "MovieImages",
                newName: "VariantImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Watchlists",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WatchlistItems",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Showtimes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Seats",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Movies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Movies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieImages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "MovieImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "MovieImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieCategories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieActors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Halls",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cinemas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Carts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BookingSeats",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9624));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "080b5cca-6871-45dd-8068-fb3bdcced26e", new DateTime(2025, 9, 19, 0, 18, 8, 235, DateTimeKind.Utc).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "427e87a4-05e4-4770-a830-0e5ec102a0c6", new DateTime(2025, 9, 19, 0, 18, 8, 238, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "a74d2fbe-ddc2-465c-88d7-1f17660a565f", new DateTime(2025, 9, 19, 0, 18, 8, 238, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 239, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 240, DateTimeKind.Utc).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 248, DateTimeKind.Utc).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 249, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 242, DateTimeKind.Utc).AddTicks(4116), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1755), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1965), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1972), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1977), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1981), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1992), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(1997), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(2003), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CinemaId", "CreatedAt", "EndDate", "Rating", "Slug" },
                values: new object[] { 1, new DateTime(2025, 9, 19, 0, 18, 8, 243, DateTimeKind.Utc).AddTicks(2008), null, null, "" });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5586));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5678));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5715));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5722));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5794));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6495));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6502));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6853));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6932));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7337));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 245, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 247, DateTimeKind.Utc).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 248, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 248, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 248, DateTimeKind.Utc).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 0, 18, 8, 248, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_CinemaId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "MovieImages");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "MovieImages");

            migrationBuilder.RenameColumn(
                name: "MainImage",
                table: "Movies",
                newName: "TrailerImageUrl");

            migrationBuilder.RenameColumn(
                name: "VariantImages",
                table: "MovieImages",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Watchlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WatchlistItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Showtimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Seats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "Movies",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovieActors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Halls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Cinemas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BookingSeats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId",
                table: "BookingSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingNumber",
                table: "Bookings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancellationReason",
                table: "Bookings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Bookings",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Actors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(3200), "Robert", "Downey Jr." });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6455), "Scarlett", "Johansson" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6470), "Chris", "Hemsworth" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6476), "Mark", "Ruffalo" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6480), "Chris", "Evans" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6483), "Jeremy", "Renner" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6487), "Tom", "Holland" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6490), "Benedict", "Cumberbatch" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6494), "Elizabeth", "Olsen" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 9, 16, 10, 42, 23, 199, DateTimeKind.Utc).AddTicks(6498), "Paul", "Rudd" });

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt" },
                values: new object[] { "0500ffdf-f0d8-4d3c-a7d4-a7b3c561fb5f", new DateTime(2025, 9, 16, 10, 42, 23, 196, DateTimeKind.Utc).AddTicks(9900) });

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 198, DateTimeKind.Utc).AddTicks(7383));

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

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 202, DateTimeKind.Utc).AddTicks(1282));

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
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7269));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "MovieActors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(7273));

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
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "MovieCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 206, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 200, DateTimeKind.Utc).AddTicks(9448), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5463), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5635), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5640), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5643), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5647), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5656), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5660), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5664), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AgeRating", "CreatedAt", "ImageUrl", "Rating", "ShortDescription" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 201, DateTimeKind.Utc).AddTicks(5667), null, 0m, "" });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4175) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4195) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4201) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4222) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4295) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4315) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4337) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4343) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4349) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4355) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4358) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4367) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4375) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4378) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4381) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4384) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4404) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4422) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4428) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4431) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4437) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4443) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4446) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4448) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4452) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4455) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4458) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4461) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4464) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4467) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4493) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4496) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4499) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4502) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4504) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4521) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4524) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4533) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4539) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4548) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4565) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4594) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4612) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4616) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4618) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4624) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4627) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4632) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4635) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4638) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4661) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4664) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4669) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4673) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4679) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4682) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4688) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4697) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4699) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4702) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4714) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4729) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4736) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4739) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4748) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4756) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4765) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4774) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4777) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4782) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4785) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4797) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4812) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4814) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4817) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4826) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4832) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4835) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4838) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4858) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4866) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4876) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4887) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4893) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4899) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4902) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4905) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4908) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4911) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4914) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4943) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4949) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4958) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                columns: new[] { "BookingId", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 9, 16, 10, 42, 23, 203, DateTimeKind.Utc).AddTicks(4993) });

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

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 10, 42, 23, 205, DateTimeKind.Utc).AddTicks(389));

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BookingId",
                table: "Seats",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
