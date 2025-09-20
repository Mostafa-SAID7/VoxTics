using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Action", Slug = "action", Description = "Action-packed movies", IsActive = true },
                new Category { Id = 2, Name = "Comedy", Slug = "comedy", Description = "Funny and entertaining movies", IsActive = true },
                new Category { Id = 3, Name = "Drama", Slug = "drama", Description = "Dramatic and emotional stories", IsActive = true },
                new Category { Id = 4, Name = "Horror", Slug = "horror", Description = "Scary and thrilling movies", IsActive = true },
                new Category { Id = 5, Name = "Sci-Fi", Slug = "sci-fi", Description = "Science fiction movies", IsActive = true },
                new Category { Id = 6, Name = "Romance", Slug = "romance", Description = "Romantic movies", IsActive = true },
                new Category { Id = 7, Name = "Animation", Slug = "animation", Description = "Animated movies for all ages", IsActive = true },
                new Category { Id = 8, Name = "Adventure", Slug = "adventure", Description = "Exciting adventure movies", IsActive = true },
                new Category { Id = 9, Name = "Fantasy", Slug = "fantasy", Description = "Fantasy worlds and stories", IsActive = true },
                new Category { Id = 10, Name = "Thriller", Slug = "thriller", Description = "Suspenseful and thrilling movies", IsActive = true }
            };

            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
