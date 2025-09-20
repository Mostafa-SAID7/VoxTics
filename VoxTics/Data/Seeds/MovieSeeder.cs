using System;
using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Data.Seeds
{
    public static class MovieSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Iron Man",
                    Description = "Billionaire Tony Stark builds a high-tech suit to fight evil.",
                    Director = "Jon Favreau",
                    ReleaseDate = new DateTime(2008, 5, 2),
                    EndDate = new DateTime(2008, 12, 31),
                    Duration = 126,
                    Price = 10.00m,
                    Rating = 8.5m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/ironman.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=8hYlB38asDY",
                    IsFeatured = true,
                    Status = MovieStatus.NowShowing,
                    Slug = "iron-man",
                    CategoryId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Avengers",
                    Description = "Earth’s mightiest heroes unite against a common enemy.",
                    Director = "Joss Whedon",
                    ReleaseDate = new DateTime(2012, 5, 4),
                    EndDate = new DateTime(2012, 12, 31),
                    Duration = 143,
                    Price = 12.00m,
                    Rating = 9.0m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/avengers.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=eOrNdBpGMv8",
                    IsFeatured = true,
                    Status = MovieStatus.Ended,
                    Slug = "avengers",
                    CategoryId = 1
                },
                new Movie
                {
                    Id = 3,
                    Title = "Black Panther",
                    Description = "T'Challa fights for his kingdom of Wakanda.",
                    Director = "Ryan Coogler",
                    ReleaseDate = new DateTime(2018, 2, 16),
                    EndDate = new DateTime(2018, 12, 31),
                    Duration = 134,
                    Price = 11.50m,
                    Rating = 8.2m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/blackpanther.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=xjDjIWPwcPU",
                    IsFeatured = false,
                    Status = MovieStatus.Ended,
                    Slug = "black-panther",
                    CategoryId = 2
                },
                new Movie
                {
                    Id = 4,
                    Title = "Doctor Strange in the Multiverse of Madness",
                    Description = "Strange explores the multiverse with dangerous consequences.",
                    Director = "Sam Raimi",
                    ReleaseDate = new DateTime(2022, 5, 6),
                    EndDate = new DateTime(2022, 12, 31),
                    Duration = 126,
                    Price = 13.00m,
                    Rating = 7.8m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/doctorstrange2.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=aWzlQ2N6qqg",
                    IsFeatured = true,
                    Status = MovieStatus.NowShowing,
                    Slug = "doctor-strange-mom",
                    CategoryId = 3
                },
                new Movie
                {
                    Id = 5,
                    Title = "Guardians of the Galaxy Vol. 3",
                    Description = "The misfit heroes face a new cosmic challenge.",
                    Director = "James Gunn",
                    ReleaseDate = new DateTime(2023, 5, 5),
                    EndDate = new DateTime(2023, 12, 31),
                    Duration = 150,
                    Price = 14.00m,
                    Rating = 8.3m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/guardians3.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=u3V5KDHRQvk",
                    IsFeatured = true,
                    Status = MovieStatus.Upcoming,
                    Slug = "guardians-of-the-galaxy-vol-3",
                    CategoryId = 2
                },
                new Movie
                {
                    Id = 6,
                    Title = "Thor: Ragnarok",
                    Description = "Thor faces Hela to save Asgard.",
                    Director = "Taika Waititi",
                    ReleaseDate = new DateTime(2017, 11, 3),
                    EndDate = new DateTime(2018, 6, 30),
                    Duration = 130,
                    Price = 11.00m,
                    Rating = 7.9m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/thor-ragnarok.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=ue80QwXMRHg",
                    IsFeatured = false,
                    Status = MovieStatus.Ended,
                    Slug = "thor-ragnarok",
                    CategoryId = 3
                },
                new Movie
                {
                    Id = 7,
                    Title = "Spider-Man: No Way Home",
                    Description = "Peter Parker faces the multiverse's chaos.",
                    Director = "Jon Watts",
                    ReleaseDate = new DateTime(2021, 12, 17),
                    EndDate = new DateTime(2022, 6, 30),
                    Duration = 148,
                    Price = 14.50m,
                    Rating = 8.7m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/spiderman-nwh.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=JfVOs4VSpmA",
                    IsFeatured = true,
                    Status = MovieStatus.Ended,
                    Slug = "spider-man-no-way-home",
                    CategoryId = 1
                },
                new Movie
                {
                    Id = 8,
                    Title = "Captain Marvel",
                    Description = "Carol Danvers becomes Captain Marvel.",
                    Director = "Anna Boden & Ryan Fleck",
                    ReleaseDate = new DateTime(2019, 3, 8),
                    EndDate = new DateTime(2019, 12, 31),
                    Duration = 123,
                    Price = 10.50m,
                    Rating = 7.1m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/captainmarvel.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=Z1BCujX3pw8",
                    IsFeatured = false,
                    Status = MovieStatus.Ended,
                    Slug = "captain-marvel",
                    CategoryId = 2
                },
                new Movie
                {
                    Id = 9,
                    Title = "Ant-Man and the Wasp: Quantumania",
                    Description = "Scott Lang explores the Quantum Realm.",
                    Director = "Peyton Reed",
                    ReleaseDate = new DateTime(2023, 2, 17),
                    EndDate = new DateTime(2023, 8, 31),
                    Duration = 125,
                    Price = 13.50m,
                    Rating = 7.4m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/antman-quantumania.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=ZlNFpri-Y40",
                    IsFeatured = false,
                    Status = MovieStatus.NowShowing,
                    Slug = "ant-man-quantumania",
                    CategoryId = 3
                },
                new Movie
                {
                    Id = 10,
                    Title = "Eternals",
                    Description = "Immortal beings reunite to save humanity.",
                    Director = "Chloé Zhao",
                    ReleaseDate = new DateTime(2021, 11, 5),
                    EndDate = new DateTime(2022, 5, 31),
                    Duration = 156,
                    Price = 12.50m,
                    Rating = 6.9m,
                    Language = "EN",
                    Country = "USA",
                    MainImage = "https://example.com/images/eternals.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=x_me3xsvDgk",
                    IsFeatured = false,
                    Status = MovieStatus.Ended,
                    Slug = "eternals",
                    CategoryId = 2
                }
            );
        }
    }
}
