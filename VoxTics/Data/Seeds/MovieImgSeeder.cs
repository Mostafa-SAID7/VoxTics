using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class MovieImgSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var movieImages = new List<MovieImg>
            {
                new MovieImg { Id = 1, MovieId = 1, ImageUrl = "https://example.com/images/ironman1.jpg" },
                new MovieImg { Id = 2, MovieId = 1, ImageUrl = "https://example.com/images/ironman2.jpg" },
                new MovieImg { Id = 3, MovieId = 2, ImageUrl = "https://example.com/images/avengers1.jpg" },
                new MovieImg { Id = 4, MovieId = 2, ImageUrl = "https://example.com/images/avengers2.jpg" },
                new MovieImg { Id = 5, MovieId = 3, ImageUrl = "https://example.com/images/thor1.jpg" },
                new MovieImg { Id = 6, MovieId = 4, ImageUrl = "https://example.com/images/hulk1.jpg" },
                new MovieImg { Id = 7, MovieId = 5, ImageUrl = "https://example.com/images/spiderman1.jpg" },
                new MovieImg { Id = 8, MovieId = 6, ImageUrl = "https://example.com/images/mj1.jpg" }
            };

            modelBuilder.Entity<MovieImg>().HasData(movieImages);
        }
    }
}
