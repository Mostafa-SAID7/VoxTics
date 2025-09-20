using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Seeds
{
    public static class HallSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(
                // Halls for Cinema 1 (Vox City Center)
                new Hall
                {
                    Id = 1,
                    Name = "Hall A",
                    TotalSeats = 150,
                    CinemaId = 1,
                    Description = "Standard screen hall with surround sound",
                    IsActive = true
                },
                new Hall
                {
                    Id = 2,
                    Name = "Hall B",
                    TotalSeats = 200,
                    CinemaId = 1,
                    Description = "3D projection hall with premium seating",
                    IsActive = true
                },

                // Halls for Cinema 2 (Galaxy Multiplex)
                new Hall
                {
                    Id = 3,
                    Name = "IMAX",
                    TotalSeats = 250,
                    CinemaId = 2,
                    Description = "IMAX hall with ultra-large screen and Dolby Atmos",
                    IsActive = true
                },
                new Hall
                {
                    Id = 4,
                    Name = "Galaxy Standard",
                    TotalSeats = 180,
                    CinemaId = 2,
                    Description = "Standard projection hall with comfortable seating",
                    IsActive = true
                },

                // Halls for Cinema 3 (CineStar Premium)
                new Hall
                {
                    Id = 5,
                    Name = "VIP Lounge",
                    TotalSeats = 120,
                    CinemaId = 3,
                    Description = "Premium lounge with recliners and in-seat service",
                    IsActive = true
                },
                new Hall
                {
                    Id = 6,
                    Name = "CineStar Deluxe",
                    TotalSeats = 200,
                    CinemaId = 3,
                    Description = "Large hall with state-of-the-art sound and visuals",
                    IsActive = true
                }
            );
        }
    }
}
