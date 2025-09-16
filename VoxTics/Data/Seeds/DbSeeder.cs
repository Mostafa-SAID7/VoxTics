using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using System;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class DbSeeder
    {
        // ----------------------
        // Static constants
        // ----------------------
        private static readonly DateTime STATIC_NOW = new DateTime(2025, 9, 16, 12, 0, 0, DateTimeKind.Utc);

        // Replace with precomputed password hashes
        private const string PASSWORD_HASH_ADMIN = "PASTE_ADMIN_HASH_HERE";
        private const string PASSWORD_HASH_USER = "PASTE_USER_HASH_HERE";

        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedCategories(modelBuilder);
            SeedMovies(modelBuilder);
            SeedCinemas(modelBuilder);
            SeedHalls(modelBuilder);
            SeedSeats(modelBuilder);
            SeedShowtimes(modelBuilder);
            SeedMovieActors(modelBuilder);
            SeedMovieCategories(modelBuilder);
            SeedActors(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new[]
            {
                new ApplicationUser
                {
                    Id = "admin-1",
                    UserName = "admin@voxtics.com",
                    NormalizedUserName = "ADMIN@VOXTICS.COM",
                    Email = "admin@voxtics.com",
                    NormalizedEmail = "ADMIN@VOXTICS.COM",
                    EmailConfirmed = true,
                    PasswordHash = PASSWORD_HASH_ADMIN,
                    SecurityStamp = "11111111-1111-1111-1111-111111111111"
                },
                new ApplicationUser
                {
                    Id = "user-1",
                    UserName = "user@voxtics.com",
                    NormalizedUserName = "USER@VOXTICS.COM",
                    Email = "user@voxtics.com",
                    NormalizedEmail = "USER@VOXTICS.COM",
                    EmailConfirmed = true,
                    PasswordHash = PASSWORD_HASH_USER,
                    SecurityStamp = "22222222-2222-2222-2222-222222222222"
                }
            });
        }

        private static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Slug = "action", IsActive = true },
                new Category { Id = 2, Name = "Drama", Slug = "drama", IsActive = true },
                new Category { Id = 3, Name = "Comedy", Slug = "comedy", IsActive = true }
            );
        }

        private static void SeedMovies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Avengers: Endgame", Director = "Russo Brothers", ReleaseDate = STATIC_NOW, Duration = 181, Price = 10m, Status = MovieStatus.NowShowing, Language = "EN", CategoryId = 1 },
                new Movie { Id = 2, Title = "Iron Man", Director = "Jon Favreau", ReleaseDate = STATIC_NOW, Duration = 126, Price = 8m, Status = MovieStatus.Ended, Language = "EN", CategoryId = 1 }
            );
        }
        private static void SeedActors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FullName = "Robert Downey Jr." },
                new Actor { Id = 2, FullName = "Scarlett Johansson" },
                new Actor { Id = 3, FullName = "Chris Hemsworth" }
            );
        }
        private static void SeedCinemas(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema { Id = 1, Name = "Grand Cinema", IsActive = true },
                new Cinema { Id = 2, Name = "Downtown Cinema", IsActive = true }
            );
        }

        private static void SeedHalls(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(
                new Hall { Id = 1, Name = "Hall 1", CinemaId = 1, CreatedAt = STATIC_NOW },
                new Hall { Id = 2, Name = "Hall 2", CinemaId = 1, CreatedAt = STATIC_NOW },
                new Hall { Id = 3, Name = "Hall A", CinemaId = 2, CreatedAt = STATIC_NOW }
            );
        }

        private static void SeedSeats(ModelBuilder modelBuilder)
        {
            var seats = new List<Seat>();
            int seatId = 1;
            for (int hallId = 1; hallId <= 3; hallId++)
                for (int row = 1; row <= 5; row++)
                    for (int col = 1; col <= 10; col++)
                        seats.Add(new Seat { Id = seatId++, HallId = hallId, SeatNumber = $"{row}{(char)(64 + col)}" });

            modelBuilder.Entity<Seat>().HasData(seats);
        }

        private static void SeedShowtimes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Showtime>().HasData(
                new Showtime { Id = 1, MovieId = 1, CinemaId = 1, HallId = 1, CinemaHallId = 1, StartTime = new DateTime(2025, 9, 16, 14, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2025, 9, 16, 16, 0, 0, DateTimeKind.Utc), Duration = 120, Price = 10m, AvailableSeats = 50 },
                new Showtime { Id = 2, MovieId = 2, CinemaId = 1, HallId = 2, CinemaHallId = 2, StartTime = new DateTime(2025, 9, 16, 17, 0, 0, DateTimeKind.Utc), EndTime = new DateTime(2025, 9, 16, 19, 0, 0, DateTimeKind.Utc), Duration = 120, Price = 12m, AvailableSeats = 50 }
            );
        }

        private static void SeedMovieActors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor { Id = 1, MovieId = 1, ActorId = 1 },
                new MovieActor { Id = 2, MovieId = 1, ActorId = 2 },
                new MovieActor { Id = 3, MovieId = 2, ActorId = 1 }
            );
        }

        private static void SeedMovieCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasData(
                new MovieCategory { Id = 1, MovieId = 1, CategoryId = 1 },
                new MovieCategory { Id = 2, MovieId = 2, CategoryId = 1 }
            );
        }
    }
}
