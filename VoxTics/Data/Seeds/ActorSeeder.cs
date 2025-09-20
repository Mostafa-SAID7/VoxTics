using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class ActorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var actors = new List<Actor>
            {
                new Actor { Id = 1, FullName = "Robert Downey Jr.", Bio = "American actor known for Iron Man.", IsActive = true },
                new Actor { Id = 2, FullName = "Gwyneth Paltrow", Bio = "American actress and singer.", IsActive = true },
                new Actor { Id = 3, FullName = "Chris Evans", Bio = "American actor known for Captain America.", IsActive = true },
                new Actor { Id = 4, FullName = "Scarlett Johansson", Bio = "American actress known for Black Widow.", IsActive = true },
                new Actor { Id = 5, FullName = "Chris Hemsworth", Bio = "Australian actor known for Thor.", IsActive = true },
                new Actor { Id = 6, FullName = "Mark Ruffalo", Bio = "American actor known for Hulk.", IsActive = true },
                new Actor { Id = 7, FullName = "Tom Holland", Bio = "English actor known for Spider-Man.", IsActive = true },
                new Actor { Id = 8, FullName = "Zendaya", Bio = "American actress known for MJ.", IsActive = true }
            };

            modelBuilder.Entity<Actor>().HasData(actors);
        }
    }
}
