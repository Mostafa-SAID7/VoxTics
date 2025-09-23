using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieCountToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieCount",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 668, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "b56c4c1f-797e-42a4-bf6a-555be2e4baaa", new DateTime(2025, 9, 23, 21, 38, 45, 947, DateTimeKind.Utc).AddTicks(3446), "AQAAAAIAAYagAAAAEI/5w1fpX/dqg6y+U2+omwELbKf+FJEltEhbXQjycrWiAwR6m45gKW4YiU4YLS2pjg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "81deadcc-3b81-4ab9-bd98-750f416358c1", new DateTime(2025, 9, 23, 21, 38, 46, 161, DateTimeKind.Utc).AddTicks(1837), "AQAAAAIAAYagAAAAED14VoIeuu3V/CgSYA0i+p9Z3xFErj9yPVjtHuWPgPw3ippGrJ2caKqGzhQ84CDyAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "d0d4f17e-0470-4277-ad1d-010520b943d8", new DateTime(2025, 9, 23, 21, 38, 46, 331, DateTimeKind.Utc).AddTicks(7159), "AQAAAAIAAYagAAAAEMQgrV8FvpTTSJQsaZkBpa46Ct8mY3O3zhdhdiAzzyzKvISDmij+Ff1fDWbkBKbWbw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "4c74219b-8596-45a7-8649-cc84b0ce88ea", new DateTime(2025, 9, 23, 21, 38, 46, 438, DateTimeKind.Utc).AddTicks(7372), "AQAAAAIAAYagAAAAEFpNep0Zxcf3Ja2fFs2DkTciYCC0q3nOX3BO2GnEriXALrpUVi4ZIhVbBFEoHSzj+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "f8897a34-6ab1-40f4-8078-0f84262d325f", new DateTime(2025, 9, 23, 21, 38, 46, 537, DateTimeKind.Utc).AddTicks(62), "AQAAAAIAAYagAAAAEOn7DjEtK1RlwRdmZLNrBioVaMOTG+i2bvBl9aX+0mHojjYfmMhMkQbj0n+E9B4JCA==" });

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 685, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 682, DateTimeKind.Utc).AddTicks(8286), new DateTime(2025, 9, 23, 21, 38, 46, 682, DateTimeKind.Utc).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6025), new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6044), new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6045) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6049), new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6051) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6055), new DateTime(2025, 9, 23, 21, 38, 46, 683, DateTimeKind.Utc).AddTicks(6056) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 669, DateTimeKind.Utc).AddTicks(7716), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1040), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1046), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1048), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1049), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1071), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1073), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1075), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1077), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "MovieCount" },
                values: new object[] { new DateTime(2025, 9, 23, 21, 38, 46, 670, DateTimeKind.Utc).AddTicks(1080), 0 });

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 671, DateTimeKind.Utc).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 671, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 671, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 687, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 687, DateTimeKind.Utc).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 672, DateTimeKind.Utc).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 673, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 673, DateTimeKind.Utc).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 673, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 673, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 673, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 676, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 677, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 686, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 686, DateTimeKind.Utc).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 680, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2477));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2699));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2849));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2924));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3209));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3238));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3291));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3312));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3316));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3324));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3465));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3548));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3693));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 681, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 678, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 679, DateTimeKind.Utc).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 679, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 679, DateTimeKind.Utc).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 679, DateTimeKind.Utc).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 679, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 688, DateTimeKind.Utc).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 688, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 688, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 688, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 21, 38, 46, 688, DateTimeKind.Utc).AddTicks(3501));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieCount",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 682, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 683, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "e1d9a557-57f0-41e9-8685-d3df6acb8a12", new DateTime(2025, 9, 23, 3, 34, 8, 968, DateTimeKind.Utc).AddTicks(6660), "AQAAAAIAAYagAAAAEBbLbnm97tfDvR/pXrd9dnEj10j1/5K74vvyKCj72HXdjsCZezJIA21q1IVIXkSd/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "01e46c61-5b8d-463c-83a6-186b63f2a89c", new DateTime(2025, 9, 23, 3, 34, 9, 108, DateTimeKind.Utc).AddTicks(6330), "AQAAAAIAAYagAAAAENxQR4MUwXM9+81Ss+4cKsyN2KQ74P3210ifjJNp/iFQxpSOL7933wy1LC60rDo3lg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "345e4c21-ecad-44f3-9f09-e235207ce289", new DateTime(2025, 9, 23, 3, 34, 9, 230, DateTimeKind.Utc).AddTicks(8161), "AQAAAAIAAYagAAAAEAG12bmyY6rx15bnTOpVuUHmEDCTsg3dKmJufVoiOLvV8tmwCZgB1vg4kUlNlumtTQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "06f85e0c-e0c4-40b2-893b-c30bd98c1f11", new DateTime(2025, 9, 23, 3, 34, 9, 345, DateTimeKind.Utc).AddTicks(5347), "AQAAAAIAAYagAAAAEHeGAU1/9gzhHyBbsIBQfFfCq9pyffG74yhzZluKHYsr/f2cLv3QdG6EjfmB2Ukl2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "7da80e60-d5b1-4bdd-8987-c80deee520a9", new DateTime(2025, 9, 23, 3, 34, 9, 551, DateTimeKind.Utc).AddTicks(3943), "AQAAAAIAAYagAAAAEG5yjHxizcKrC/B5H4K0llcSuzhc8yH3bSHnw3CpUaydpGdpTne/8tQHS2PFvR5Slw==" });

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9356));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 696, DateTimeKind.Utc).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(1342), new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(1488) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5868), new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5880), new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5883), new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5888), new DateTime(2025, 9, 23, 3, 34, 9, 695, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 684, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 685, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 686, DateTimeKind.Utc).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 686, DateTimeKind.Utc).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 698, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 698, DateTimeKind.Utc).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 686, DateTimeKind.Utc).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 687, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 687, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 687, DateTimeKind.Utc).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 687, DateTimeKind.Utc).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 687, DateTimeKind.Utc).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 689, DateTimeKind.Utc).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 690, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 697, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 698, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 693, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1537));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1666));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1718));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1735));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2458));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 694, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 692, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 693, DateTimeKind.Utc).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 693, DateTimeKind.Utc).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 693, DateTimeKind.Utc).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 693, DateTimeKind.Utc).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 693, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 699, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 699, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 699, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 699, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 23, 3, 34, 9, 699, DateTimeKind.Utc).AddTicks(5771));
        }
    }
}
