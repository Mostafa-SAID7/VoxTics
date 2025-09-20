using System;
using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class ShowtimeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var showtimes = new List<Showtime>
            {
                new Showtime
                {
                    Id = 1,
                    MovieId = 1,
                    HallId = 1,
                    CinemaId = 1,
                    StartTime = new DateTime(2025, 9, 21, 10, 0, 0),
                    Duration = 126,
                    Price = 10.00m,
                    Status = ShowtimeStatus.Scheduled,
                    Is3D = false,
                    Language = "EN",
                    ScreenType = "Standard",
                    AvailableSeats = 150,
                    IsCancelled = false
                },
                new Showtime
                {
                    Id = 2,
                    MovieId = 2,
                    HallId = 2,
                    CinemaId = 1,
                    StartTime = new DateTime(2025, 9, 21, 13, 0, 0),
                    Duration = 143,
                    Price = 12.00m,
                    Status = ShowtimeStatus.Scheduled,
                    Is3D = true,
                    Language = "EN",
                    ScreenType = "3D",
                    AvailableSeats = 200,
                    IsCancelled = false
                },
                new Showtime
                {
                    Id = 3,
                    MovieId = 3,
                    HallId = 3,
                    CinemaId = 2,
                    StartTime = new DateTime(2025, 9, 21, 15, 0, 0),
                    Duration = 134,
                    Price = 11.50m,
                    Status = ShowtimeStatus.Scheduled,
                    Is3D = false,
                    Language = "EN",
                    ScreenType = "Standard",
                    AvailableSeats = 250,
                    IsCancelled = false
                },
                new Showtime
                {
                    Id = 4,
                    MovieId = 4,
                    HallId = 4,
                    CinemaId = 2,
                    StartTime = new DateTime(2025, 9, 21, 18, 0, 0),
                    Duration = 126,
                    Price = 13.00m,
                    Status = ShowtimeStatus.Scheduled,
                    Is3D = true,
                    Language = "EN",
                    ScreenType = "3D",
                    AvailableSeats = 180,
                    IsCancelled = false
                },
                new Showtime
                {
                    Id = 5,
                    MovieId = 5,
                    HallId = 5,
                    CinemaId = 3,
                    StartTime = new DateTime(2025, 9, 21, 20, 0, 0),
                    Duration = 150,
                    Price = 14.00m,
                    Status = ShowtimeStatus.Scheduled,
                    Is3D = false,
                    Language = "EN",
                    ScreenType = "Standard",
                    AvailableSeats = 120,
                    IsCancelled = false
                },
                new Showtime
                {
                    Id = 6,
                    MovieId = 6,
                    HallId = 6,
                    CinemaId = 3,
                    StartTime = new DateTime(2025, 9, 22, 10, 0, 0),
                    Duration = 130,
                    Price = 11.00m,
                    Status = ShowtimeStatus.Scheduled,
                    Is3D = true,
                    Language = "EN",
                    ScreenType = "3D",
                    AvailableSeats = 200,
                    IsCancelled = false
                }
            };

            modelBuilder.Entity<Showtime>().HasData(showtimes);
        }
    }
}
