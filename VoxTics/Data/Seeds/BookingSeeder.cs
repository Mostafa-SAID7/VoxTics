using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class BookingSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var bookings = new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    UserId = "user1",
                    ShowtimeId = 1,
                    NumberOfTickets = 2,
                    TotalAmount = 20.00m,
                    DiscountAmount = 0m,
                    FinalAmount = 20.00m,
                    Status = Models.Enums.BookingStatus.Confirmed,
                    IsCheckedIn = false
                },
                new Booking
                {
                    Id = 2,
                    UserId = "user2",
                    ShowtimeId = 2,
                    NumberOfTickets = 3,
                    TotalAmount = 36.00m,
                    DiscountAmount = 0m,
                    FinalAmount = 36.00m,
                    Status = Models.Enums.BookingStatus.Pending,
                    IsCheckedIn = false
                },
                new Booking
                {
                    Id = 3,
                    UserId = "user3",
                    ShowtimeId = 3,
                    NumberOfTickets = 1,
                    TotalAmount = 11.50m,
                    DiscountAmount = 0m,
                    FinalAmount = 11.50m,
                    Status = Models.Enums.BookingStatus.Confirmed,
                    IsCheckedIn = false
                },
                new Booking
                {
                    Id = 4,
                    UserId = "user4",
                    ShowtimeId = 4,
                    NumberOfTickets = 4,
                    TotalAmount = 52.00m,
                    DiscountAmount = 5.00m,
                    FinalAmount = 47.00m,
                    Status = Models.Enums.BookingStatus.Pending,
                    IsCheckedIn = false
                },
                new Booking
                {
                    Id = 5,
                    UserId = "user5",
                    ShowtimeId = 5,
                    NumberOfTickets = 2,
                    TotalAmount = 28.00m,
                    DiscountAmount = 0m,
                    FinalAmount = 28.00m,
                    Status = Models.Enums.BookingStatus.Confirmed,
                    IsCheckedIn = false
                }
            };

            modelBuilder.Entity<Booking>().HasData(bookings);
        }
    }
}
