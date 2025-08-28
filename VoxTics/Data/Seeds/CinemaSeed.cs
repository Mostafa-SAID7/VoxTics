using Microsoft.EntityFrameworkCore;
using VoxTics.Models;

namespace VoxTics.Data.Seeds
{
    public static class CinemaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema
                {
                    Id = 1,
                    Name = "Photospace",
                    Description = "Duis aliquam convallis nunc...",
                    CinemaLogo = "Quis.tiff",
                    Address = "395 Welch Junction"
                },
                new Cinema
                {
                    Id = 2,
                    Name = "Trilith",
                    Description = "Fusce posuere felis sed lacus...",
                    CinemaLogo = "Sagittis.tiff",
                    Address = "6958 Debra Avenue"
                },
                new Cinema
                {
                    Id = 3,
                    Name = "Oozz",
                    Description = "Praesent id massa id nisl venenatis lacinia...",
                    CinemaLogo = "DisParturientMontes.jpeg",
                    Address = "710 Weeping Birch Junction"
                },
                new Cinema
                {
                    Id = 4,
                    Name = "Cinemark",
                    Description = "State-of-the-art cinema experience...",
                    CinemaLogo = "Cinemark.png",
                    Address = "1200 Sunset Blvd"
                },
                new Cinema
                {
                    Id = 5,
                    Name = "Regal Theatres",
                    Description = "Family-friendly movie theatre...",
                    CinemaLogo = "Regal.jpg",
                    Address = "45 Main Street"
                },
                new Cinema
                {
                    Id = 6,
                    Name = "AMC Theatres",
                    Description = "Luxury recliners and IMAX screens...",
                    CinemaLogo = "AMC.png",
                    Address = "88 Broadway Ave"
                },
                new Cinema
                {
                    Id = 7,
                    Name = "IMAX Experience",
                    Description = "Immersive cinema with giant screens...",
                    CinemaLogo = "IMAX.jpg",
                    Address = "200 City Center Plaza"
                }
            );
        }
    }
}
