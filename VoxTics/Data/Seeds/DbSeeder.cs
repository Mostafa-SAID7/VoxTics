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
        private static readonly DateTime STATIC_NOW = new DateTime(2025, 9, 16, 12, 0, 0, DateTimeKind.Utc);

        // Replace with precomputed password hashes
        private const string PASSWORD_HASH_ADMIN = "PASTE_ADMIN_HASH_HERE";
        private const string PASSWORD_HASH_USER = "PASTE_USER_HASH_HERE";

        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedCategories(modelBuilder);
            SeedActors(modelBuilder);
            SeedMovies(modelBuilder);
            SeedCinemas(modelBuilder);
            SeedHalls(modelBuilder);
            SeedSeats(modelBuilder);
            SeedShowtimes(modelBuilder);
            SeedMovieActors(modelBuilder);
            SeedMovieCategories(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
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
                },
                new ApplicationUser
                {
                    Id = "user-2",
                    UserName = "jane.doe@voxtics.com",
                    NormalizedUserName = "JANE.DOE@VOXTICS.COM",
                    Email = "jane.doe@voxtics.com",
                    NormalizedEmail = "JANE.DOE@VOXTICS.COM",
                    EmailConfirmed = true,
                    PasswordHash = PASSWORD_HASH_USER,
                    SecurityStamp = "33333333-3333-3333-3333-333333333333"
                }
            );
        }

        private static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", Slug = "action", IsActive = true },
                new Category { Id = 2, Name = "Drama", Slug = "drama", IsActive = true },
                new Category { Id = 3, Name = "Comedy", Slug = "comedy", IsActive = true },
                new Category { Id = 4, Name = "Horror", Slug = "horror", IsActive = true },
                new Category { Id = 5, Name = "Sci-Fi", Slug = "sci-fi", IsActive = true }
            );
        }

        private static void SeedActors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FullName = "Robert Downey Jr." },
                new Actor { Id = 2, FullName = "Scarlett Johansson" },
                new Actor { Id = 3, FullName = "Chris Hemsworth" },
                new Actor { Id = 4, FullName = "Mark Ruffalo" },
                new Actor { Id = 5, FullName = "Chris Evans" },
                new Actor { Id = 6, FullName = "Jeremy Renner" },
                new Actor { Id = 7, FullName = "Tom Holland" },
                new Actor { Id = 8, FullName = "Benedict Cumberbatch" },
                new Actor { Id = 9, FullName = "Elizabeth Olsen" },
                new Actor { Id = 10, FullName = "Paul Rudd" }
            );
        }

        private static void SeedMovies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, CinemaId = 1, Title = "Avengers: Endgame", Director = "Russo Brothers", ReleaseDate = STATIC_NOW, Duration = 181, Price = 10m, Status = MovieStatus.NowShowing, Language = "EN", CategoryId = 1 },
                new Movie { Id = 2, CinemaId = 1, Title = "Iron Man", Director = "Jon Favreau", ReleaseDate = STATIC_NOW.AddYears(-15), Duration = 126, Price = 8m, Status = MovieStatus.Ended, Language = "EN", CategoryId = 1 },
                new Movie { Id = 3, CinemaId = 1, Title = "Spider-Man: No Way Home", Director = "Jon Watts", ReleaseDate = STATIC_NOW, Duration = 148, Price = 12m, Status = MovieStatus.NowShowing, Language = "EN", CategoryId = 5 },
                new Movie { Id = 4, CinemaId = 1, Title = "Doctor Strange", Director = "Scott Derrickson", ReleaseDate = STATIC_NOW, Duration = 115, Price = 9m, Status = MovieStatus.Ended, Language = "EN", CategoryId = 5 },
                new Movie { Id = 5, CinemaId = 1, Title = "Black Widow", Director = "Cate Shortland", ReleaseDate = STATIC_NOW, Duration = 134, Price = 11m, Status = MovieStatus.NowShowing, Language = "EN", CategoryId = 1 },
                new Movie { Id = 6, CinemaId = 1, Title = "Thor: Ragnarok", Director = "Taika Waititi", ReleaseDate = STATIC_NOW.AddYears(-3), Duration = 130, Price = 10m, Status = MovieStatus.Ended, Language = "EN", CategoryId = 1 },
                new Movie { Id = 7, CinemaId = 1, Title = "Captain America: Civil War", Director = "Anthony Russo", ReleaseDate = STATIC_NOW.AddYears(-4), Duration = 147, Price = 9m, Status = MovieStatus.Ended, Language = "EN", CategoryId = 1 },
                new Movie { Id = 8, CinemaId = 1, Title = "Ant-Man", Director = "Peyton Reed", ReleaseDate = STATIC_NOW.AddYears(-5), Duration = 117, Price = 8m, Status = MovieStatus.Ended, Language = "EN", CategoryId = 5 },
                new Movie { Id = 9, CinemaId = 1, Title = "WandaVision", Director = "Matt Shakman", ReleaseDate = STATIC_NOW, Duration = 120, Price = 15m, Status = MovieStatus.NowShowing, Language = "EN", CategoryId = 2 },
                new Movie { Id = 10, CinemaId = 1, Title = "Doctor Strange in the Multiverse of Madness", Director = "Sam Raimi", ReleaseDate = STATIC_NOW, Duration = 150, Price = 14m, Status = MovieStatus.NowShowing, Language = "EN", CategoryId = 5 }
            );
        }

        private static void SeedCinemas(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema { Id = 1, Name = "Grand Cinema", IsActive = true },
                new Cinema { Id = 2, Name = "Downtown Cinema", IsActive = true },
                new Cinema { Id = 3, Name = "City Lights Cinema", IsActive = true }
            );
        }

        private static void SeedHalls(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(
                new Hall { Id = 1, Name = "Hall 1", CinemaId = 1, CreatedAt = STATIC_NOW },
                new Hall { Id = 2, Name = "Hall 2", CinemaId = 1, CreatedAt = STATIC_NOW },
                new Hall { Id = 3, Name = "Hall A", CinemaId = 2, CreatedAt = STATIC_NOW },
                new Hall { Id = 4, Name = "Hall B", CinemaId = 2, CreatedAt = STATIC_NOW },
                new Hall { Id = 5, Name = "Hall Main", CinemaId = 3, CreatedAt = STATIC_NOW }
            );
        }

        private static void SeedSeats(ModelBuilder modelBuilder)
        {
            var seats = new List<Seat>();
            int seatId = 1;
            for (int hallId = 1; hallId <= 5; hallId++)
                for (int row = 1; row <= 5; row++)
                    for (int col = 1; col <= 10; col++)
                        seats.Add(new Seat { Id = seatId++, HallId = hallId, SeatNumber = $"{row}{(char)(64 + col)}" });

            modelBuilder.Entity<Seat>().HasData(seats);
        }

        private static void SeedShowtimes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Showtime>().HasData(
                new Showtime { Id = 1, MovieId = 1, CinemaId = 1, HallId = 1, CinemaHallId = 1, StartTime = STATIC_NOW.AddHours(2), EndTime = STATIC_NOW.AddHours(4), Duration = 120, Price = 10m, AvailableSeats = 50 },
                new Showtime { Id = 2, MovieId = 2, CinemaId = 1, HallId = 2, CinemaHallId = 2, StartTime = STATIC_NOW.AddHours(5), EndTime = STATIC_NOW.AddHours(7), Duration = 120, Price = 12m, AvailableSeats = 50 },
                new Showtime { Id = 3, MovieId = 3, CinemaId = 2, HallId = 3, CinemaHallId = 3, StartTime = STATIC_NOW.AddHours(3), EndTime = STATIC_NOW.AddHours(5), Duration = 120, Price = 15m, AvailableSeats = 50 },
                new Showtime { Id = 4, MovieId = 4, CinemaId = 2, HallId = 4, CinemaHallId = 4, StartTime = STATIC_NOW.AddHours(6), EndTime = STATIC_NOW.AddHours(8), Duration = 120, Price = 9m, AvailableSeats = 50 },
                new Showtime { Id = 5, MovieId = 5, CinemaId = 3, HallId = 5, CinemaHallId = 5, StartTime = STATIC_NOW.AddHours(4), EndTime = STATIC_NOW.AddHours(6), Duration = 120, Price = 11m, AvailableSeats = 50 }
            );
        }

        private static void SeedMovieActors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor { Id = 1, MovieId = 1, ActorId = 1 },
                new MovieActor { Id = 2, MovieId = 1, ActorId = 2 },
                new MovieActor { Id = 3, MovieId = 1, ActorId = 3 },
                new MovieActor { Id = 4, MovieId = 2, ActorId = 1 },
                new MovieActor { Id = 5, MovieId = 3, ActorId = 7 },
                new MovieActor { Id = 6, MovieId = 4, ActorId = 8 },
                new MovieActor { Id = 7, MovieId = 5, ActorId = 2 },
                new MovieActor { Id = 8, MovieId = 6, ActorId = 3 },
                new MovieActor { Id = 9, MovieId = 7, ActorId = 5 },
                new MovieActor { Id = 10, MovieId = 8, ActorId = 10 },
                new MovieActor { Id = 11, MovieId = 9, ActorId = 9 },
                new MovieActor { Id = 12, MovieId = 10, ActorId = 8 }
            );
        }

        private static void SeedMovieCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>().HasData(
                new MovieCategory { Id = 1, MovieId = 1, CategoryId = 1 },
                new MovieCategory { Id = 2, MovieId = 2, CategoryId = 1 },
                new MovieCategory { Id = 3, MovieId = 3, CategoryId = 5 },
                new MovieCategory { Id = 4, MovieId = 4, CategoryId = 5 },
                new MovieCategory { Id = 5, MovieId = 5, CategoryId = 1 },
                new MovieCategory { Id = 6, MovieId = 6, CategoryId = 1 },
                new MovieCategory { Id = 7, MovieId = 7, CategoryId = 1 },
                new MovieCategory { Id = 8, MovieId = 8, CategoryId = 5 },
                new MovieCategory { Id = 9, MovieId = 9, CategoryId = 2 },
                new MovieCategory { Id = 10, MovieId = 10, CategoryId = 5 }
            );
        }
    }
}
