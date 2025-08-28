using Microsoft.EntityFrameworkCore;
using VoxTics.Models;

namespace VoxTics.Data.Seeds
{
    public static class CategorySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Comedy" },
                new Category { Id = 3, Name = "Drama" },
                new Category { Id = 4, Name = "Documentary" },
                new Category { Id = 5, Name = "Cartoon" },
                new Category { Id = 6, Name = "Horror" }
            );
        }
    }
}
