using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Seeds
{
    public static class CinemaSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema
                {
                    Id = 1,
                    Name = "Vox City Center",
                    Description = "A modern cinema located in the heart of the city with multiple halls and premium services.",
                    Email = "contact@voxcity.com",
                    Phone = "+1-555-1234",
                    Address = "123 Main Street",
                    City = "Metropolis",
                    State = "NY",
                    Country = "USA",
                    PostalCode = "10001",
                    Website = "https://www.voxcitycinema.com",
                    ImageUrl = "https://example.com/images/cinema1.jpg",
                    IsActive = true
                },
                new Cinema
                {
                    Id = 2,
                    Name = "Galaxy Multiplex",
                    Description = "Popular cinema known for IMAX and 3D showings.",
                    Email = "info@galaxy.com",
                    Phone = "+1-555-5678",
                    Address = "456 Elm Street",
                    City = "Gotham",
                    State = "IL",
                    Country = "USA",
                    PostalCode = "60601",
                    Website = "https://www.galaxycinema.com",
                    ImageUrl = "https://example.com/images/cinema2.jpg",
                    IsActive = true
                },
                new Cinema
                {
                    Id = 3,
                    Name = "CineStar Premium",
                    Description = "Premium cinema experience with luxury seating and gourmet snacks.",
                    Email = "support@cinestar.com",
                    Phone = "+1-555-7890",
                    Address = "789 Oak Avenue",
                    City = "Star City",
                    State = "CA",
                    Country = "USA",
                    PostalCode = "90001",
                    Website = "https://www.cinestar.com",
                    ImageUrl = "https://example.com/images/cinema3.jpg",
                    IsActive = true
                }
            );
        }
    }
}
