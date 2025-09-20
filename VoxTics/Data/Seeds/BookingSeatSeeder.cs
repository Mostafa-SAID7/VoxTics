using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class BookingSeatSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var bookingSeats = new List<BookingSeat>
            {
                new BookingSeat { Id = 1, BookingId = 1, SeatId = 1, SeatPrice = 10.00m },
                new BookingSeat { Id = 2, BookingId = 1, SeatId = 2, SeatPrice = 10.00m },
                new BookingSeat { Id = 3, BookingId = 2, SeatId = 11, SeatPrice = 12.00m },
                new BookingSeat { Id = 4, BookingId = 2, SeatId = 12, SeatPrice = 12.00m },
                new BookingSeat { Id = 5, BookingId = 2, SeatId = 13, SeatPrice = 12.00m },
                new BookingSeat { Id = 6, BookingId = 3, SeatId = 21, SeatPrice = 11.50m },
                new BookingSeat { Id = 7, BookingId = 4, SeatId = 31, SeatPrice = 13.00m },
                new BookingSeat { Id = 8, BookingId = 4, SeatId = 32, SeatPrice = 13.00m },
                new BookingSeat { Id = 9, BookingId = 4, SeatId = 33, SeatPrice = 13.00m },
                new BookingSeat { Id = 10, BookingId = 4, SeatId = 34, SeatPrice = 13.00m },
                new BookingSeat { Id = 11, BookingId = 5, SeatId = 41, SeatPrice = 14.00m },
                new BookingSeat { Id = 12, BookingId = 5, SeatId = 42, SeatPrice = 14.00m }
            };

            modelBuilder.Entity<BookingSeat>().HasData(bookingSeats);
        }
    }
}
