using Microsoft.EntityFrameworkCore;
using VoxTics.Models;

namespace VoxTics.Data.Seeds
{
    public static class MovieActorSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasData(
                new MovieActor { ActorId = 1, MovieId = 1 },   // Leonardo DiCaprio -> Inception
                new MovieActor { ActorId = 2, MovieId = 1 },   // Joseph Gordon-Levitt -> Inception
                new MovieActor { ActorId = 3, MovieId = 2 },   // Sam Worthington -> Avatar 3
                new MovieActor { ActorId = 4, MovieId = 3 },   // Kate Winslet -> Titanic
                new MovieActor { ActorId = 1, MovieId = 3 },   // Leonardo DiCaprio -> Titanic
                new MovieActor { ActorId = 5, MovieId = 4 },   // Cillian Murphy -> Oppenheimer
                new MovieActor { ActorId = 6, MovieId = 5 },   // Christian Bale -> The Dark Knight
                new MovieActor { ActorId = 7, MovieId = 6 },   // Matthew Broderick -> The Lion King
                new MovieActor { ActorId = 8, MovieId = 7 },   // Matthew McConaughey -> Interstellar
                new MovieActor { ActorId = 25, MovieId = 8 },  // Joaquin Phoenix -> Joker
                new MovieActor { ActorId = 29, MovieId = 9 },  // Patrick Wilson -> The Conjuring
                new MovieActor { ActorId = 29, MovieId = 21 }, // Patrick Wilson -> The Conjuring 2
                new MovieActor { ActorId = 41, MovieId = 10 }, // Idina Menzel -> Frozen
                new MovieActor { ActorId = 41, MovieId = 26 }  // Idina Menzel -> Frozen II
            );
        }
    }
}
