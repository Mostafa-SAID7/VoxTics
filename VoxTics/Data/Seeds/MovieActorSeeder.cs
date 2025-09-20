using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class MovieActorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var movieActors = new List<MovieActor>
            {
                new MovieActor { Id = 1, MovieId = 1, ActorId = 1, CharacterName = "Tony Stark" },
                new MovieActor { Id = 2, MovieId = 1, ActorId = 2, CharacterName = "Pepper Potts" },
                new MovieActor { Id = 3, MovieId = 2, ActorId = 3, CharacterName = "Steve Rogers" },
                new MovieActor { Id = 4, MovieId = 2, ActorId = 4, CharacterName = "Natasha Romanoff" },
                new MovieActor { Id = 5, MovieId = 3, ActorId = 5, CharacterName = "Thor" },
                new MovieActor { Id = 6, MovieId = 4, ActorId = 6, CharacterName = "Bruce Banner" },
                new MovieActor { Id = 7, MovieId = 5, ActorId = 7, CharacterName = "Peter Parker" },
                new MovieActor { Id = 8, MovieId = 6, ActorId = 8, CharacterName = "MJ" }
            };

            modelBuilder.Entity<MovieActor>().HasData(movieActors);
        }
    }
}
