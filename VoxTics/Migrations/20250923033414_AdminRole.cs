using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoxTics.Migrations
{
    /// <inheritdoc />
    public partial class AdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 638, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "f14fab1d-a8be-4154-a98d-7f634b2e68e2", new DateTime(2025, 9, 20, 15, 53, 33, 999, DateTimeKind.Utc).AddTicks(4127), "AQAAAAIAAYagAAAAEOak2MH4R8ynq+48ZaswmOLu2mqQEpVthSmTx7CwvWpSiwKzkyFiNb6OEmrAD1J4nQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "259712d8-a61d-491c-a39f-d60e405e8902", new DateTime(2025, 9, 20, 15, 53, 34, 106, DateTimeKind.Utc).AddTicks(1941), "AQAAAAIAAYagAAAAEPNUTie2QBo2eHkdrv8ZzN0HKiSncc/Rdt7z+zfdcj55Hr7Ec+TLAb13pj2fEXWf9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "7631d569-5214-49c0-bea3-a696db5dc95e", new DateTime(2025, 9, 20, 15, 53, 34, 207, DateTimeKind.Utc).AddTicks(8700), "AQAAAAIAAYagAAAAEHHQJT+Wlm/EHd3pKWeLcwWdBE9oJ0ydRKjMCadkA8rX7DD5IV6XCgaSpT63u8GbyA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "deea2382-8543-48bd-ac4d-8121912ac209", new DateTime(2025, 9, 20, 15, 53, 34, 310, DateTimeKind.Utc).AddTicks(7991), "AQAAAAIAAYagAAAAED+ZmfIcUZnlZb2H2EdzGA2OfM9/ekNBY8w2z3mMWinAQzTRxVXzBo5sBUAs8czNDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "a5b3ef2e-bfde-4bf5-b04f-d9294e92489c", new DateTime(2025, 9, 20, 15, 53, 34, 451, DateTimeKind.Utc).AddTicks(561), "AQAAAAIAAYagAAAAELfOqGJTQPABcnoDHm7IbHWyR7aOrq6RfSxrdHhhpTmpBLsVgFAg/STnPlnLtIFgnw==" });

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 654, DateTimeKind.Utc).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "BookingSeats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 655, DateTimeKind.Utc).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 15, 53, 34, 652, DateTimeKind.Utc).AddTicks(3157), new DateTime(2025, 9, 20, 15, 53, 34, 652, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(447), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(469), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(471) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(476), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(477) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BookingDate", "CreatedAt" },
                values: new object[] { new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(482), new DateTime(2025, 9, 20, 15, 53, 34, 653, DateTimeKind.Utc).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 639, DateTimeKind.Utc).AddTicks(9709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 640, DateTimeKind.Utc).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 641, DateTimeKind.Utc).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 641, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 642, DateTimeKind.Utc).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 645, DateTimeKind.Utc).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 646, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 656, DateTimeKind.Utc).AddTicks(384));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 656, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 649, DateTimeKind.Utc).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8585));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 251,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 252,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 253,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 254,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 255,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 256,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 257,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 258,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 259,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 260,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 261,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 262,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 263,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 264,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 265,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 266,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 267,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 268,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 269,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 270,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 271,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 272,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 273,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 274,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 275,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 276,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 277,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 278,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 279,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 280,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 281,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 282,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 283,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 284,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 285,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 286,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 287,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 288,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 289,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 290,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 291,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 292,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 293,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 294,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 295,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 296,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 297,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 298,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 299,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 650, DateTimeKind.Utc).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 647, DateTimeKind.Utc).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 648, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Watchlists",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 15, 53, 34, 657, DateTimeKind.Utc).AddTicks(8438));
        }
    }
}
