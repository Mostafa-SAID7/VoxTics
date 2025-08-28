using Microsoft.EntityFrameworkCore;
using VoxTics.Models;

namespace VoxTics.Data.Seeds
{
    public static class ActorSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    FirstName = "Leonardo",
                    LastName = "DiCaprio",
                    Bio = "American actor and film producer.",
                    ProfilePicture = "leo.png",
                    News = "Best known for Inception and Titanic."
                },
                new Actor
                {
                    Id = 2,
                    FirstName = "Joseph",
                    LastName = "Gordon-Levitt",
                    Bio = "American actor and filmmaker.",
                    ProfilePicture = "jgl.png",
                    News = "Starred in Inception."
                },
                new Actor
                {
                    Id = 3,
                    FirstName = "Sam",
                    LastName = "Worthington",
                    Bio = "Australian actor, best known for Avatar.",
                    ProfilePicture = "sam.png",
                    News = "Will reprise his role in Avatar 3."
                },
                new Actor
                {
                    Id = 4,
                    FirstName = "Kate",
                    LastName = "Winslet",
                    Bio = "English actress, known for Titanic.",
                    ProfilePicture = "kate.png",
                    News = "Won Academy Award for The Reader."
                },
                new Actor
                {
                    Id = 5,
                    FirstName = "Cillian",
                    LastName = "Murphy",
                    Bio = "Irish actor, known for Oppenheimer and Peaky Blinders.",
                    ProfilePicture = "cillian.png",
                    News = "Portrayed J. Robert Oppenheimer."
                },
                new Actor
                {
                    Id = 6,
                    FirstName = "Christian",
                    LastName = "Bale",
                    Bio = "English actor, known for Batman trilogy.",
                    ProfilePicture = "bale.png",
                    News = "Played Bruce Wayne in The Dark Knight."
                },
                new Actor
                {
                    Id = 7,
                    FirstName = "Matthew",
                    LastName = "Broderick",
                    Bio = "American actor, voiced Simba in The Lion King.",
                    ProfilePicture = "broderick.png",
                    News = "Tony Award-winning stage actor."
                },
                new Actor
                {
                    Id = 8,
                    FirstName = "Matthew",
                    LastName = "McConaughey",
                    Bio = "American actor, known for Interstellar.",
                    ProfilePicture = "mcconaughey.png",
                    News = "Won Academy Award for Dallas Buyers Club."
                },
                new Actor
                {
                    Id = 25,
                    FirstName = "Joaquin",
                    LastName = "Phoenix",
                    Bio = "American actor, known for Joker.",
                    ProfilePicture = "phoenix.png",
                    News = "Won Academy Award for Joker."
                },
                new Actor
                {
                    Id = 29,
                    FirstName = "Patrick",
                    LastName = "Wilson",
                    Bio = "American actor, starred in The Conjuring.",
                    ProfilePicture = "wilson.png",
                    News = "Also starred in Insidious franchise."
                },
                new Actor
                {
                    Id = 41,
                    FirstName = "Idina",
                    LastName = "Menzel",
                    Bio = "American actress and singer, voice of Elsa in Frozen.",
                    ProfilePicture = "idina.png",
                    News = "Famous for singing Let It Go."
                }
            );
        }
    }
}
