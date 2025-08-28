using Microsoft.EntityFrameworkCore;
using VoxTics.Models;
using VoxTics.Models.Enums;

namespace VoxTics.Data.Seeds
{
    public static class MovieSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Description = "A mind-bending thriller",
                    Price = 50,
                    StartDate = new DateTime(2010, 07, 16),
                    EndDate = new DateTime(2011, 07, 16),
                    CinemaId = 1,
                    CategoryId = 1, // Action
                    MovieStatus = MovieStatus.Available
                },
                new Movie
                {
                    Id = 2,
                    Title = "Avatar 3",
                    Description = "The next epic sci-fi adventure",
                    Price = 60,
                    StartDate = new DateTime(2025, 12, 15),
                    EndDate = new DateTime(2026, 03, 15),
                    CinemaId = 2,
                    CategoryId = 2, // Comedy (placeholder for Sci-Fi)
                    MovieStatus = MovieStatus.ComingSoon
                },
                new Movie
                {
                    Id = 3,
                    Title = "Titanic",
                    Description = "A tragic love story",
                    Price = 40,
                    StartDate = new DateTime(1997, 12, 19),
                    EndDate = new DateTime(1998, 12, 19),
                    CinemaId = 3,
                    CategoryId = 3, // Drama
                    MovieStatus = MovieStatus.Expired
                },
                new Movie
                {
                    Id = 4,
                    Title = "Oppenheimer",
                    Description = "The story of J. Robert Oppenheimer",
                    Price = 55,
                    StartDate = new DateTime(2023, 07, 21),
                    EndDate = new DateTime(2024, 01, 21),
                    CinemaId = 1,
                    CategoryId = 3, // Drama
                    MovieStatus = MovieStatus.Available
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Dark Knight",
                    Description = "Batman faces the Joker in Gotham",
                    Price = 45,
                    StartDate = new DateTime(2008, 07, 18),
                    EndDate = new DateTime(2009, 07, 18),
                    CinemaId = 4,
                    CategoryId = 1, // Action
                    MovieStatus = MovieStatus.Expired
                },
                new Movie
                {
                    Id = 6,
                    Title = "The Lion King",
                    Description = "A young lion prince flees his kingdom",
                    Price = 35,
                    StartDate = new DateTime(1994, 06, 24),
                    EndDate = new DateTime(1995, 06, 24),
                    CinemaId = 5,
                    CategoryId = 5, // Cartoon
                    MovieStatus = MovieStatus.Expired
                },
                new Movie
                {
                    Id = 7,
                    Title = "Interstellar",
                    Description = "A journey through space and time",
                    Price = 65,
                    StartDate = new DateTime(2014, 11, 7),
                    EndDate = new DateTime(2015, 11, 7),
                    CinemaId = 6,
                    CategoryId = 1, // Action
                    MovieStatus = MovieStatus.Available
                },
                new Movie
                {
                    Id = 8,
                    Title = "Joker",
                    Description = "The origin story of Gotham’s villain",
                    Price = 50,
                    StartDate = new DateTime(2019, 10, 4),
                    EndDate = new DateTime(2020, 04, 4),
                    CinemaId = 7,
                    CategoryId = 3, // Drama
                    MovieStatus = MovieStatus.Available
                },
                new Movie
                {
                    Id = 9,
                    Title = "The Conjuring",
                    Description = "A chilling horror story",
                    Price = 40,
                    StartDate = new DateTime(2013, 07, 19),
                    EndDate = new DateTime(2014, 07, 19),
                    CinemaId = 6,
                    CategoryId = 6, // Horror
                    MovieStatus = MovieStatus.Expired
                },
                new Movie
                {
                    Id = 10,
                    Title = "Frozen",
                    Description = "A magical Disney animated film",
                    Price = 30,
                    StartDate = new DateTime(2013, 11, 27),
                    EndDate = new DateTime(2014, 11, 27),
                    CinemaId = 5,
                    CategoryId = 5, // Cartoon
                    MovieStatus = MovieStatus.Available
                },
                new Movie
                {
                    Id = 21,
                    Title = "The Conjuring 2",
                    Description = "A terrifying sequel to the horror hit",
                    Price = 45,
                    StartDate = new DateTime(2016, 06, 10),
                    EndDate = new DateTime(2017, 06, 10),
                    CinemaId = 6,
                    CategoryId = 6, // Horror
                    MovieStatus = MovieStatus.Expired
                },
                new Movie
                {
                    Id = 26,
                    Title = "Frozen II",
                    Description = "Elsa and Anna’s new magical journey",
                    Price = 35,
                    StartDate = new DateTime(2019, 11, 22),
                    EndDate = new DateTime(2020, 11, 22),
                    CinemaId = 5,
                    CategoryId = 5, // Cartoon
                    MovieStatus = MovieStatus.Available
                }
            );
        }
    }
}
