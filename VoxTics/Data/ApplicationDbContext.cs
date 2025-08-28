using Microsoft.EntityFrameworkCore;
using VoxTics.Data.Seeds;
using VoxTics.Models;

namespace VoxTics.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<MovieImg> MovieImgs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieImg>()
    .HasOne(mi => mi.Movie)
    .WithMany(m => m.MovieImgs)
    .HasForeignKey(mi => mi.MovieId)
    .OnDelete(DeleteBehavior.Cascade);

            // Enum conversion
            modelBuilder.Entity<Movie>()
                .Property(m => m.MovieStatus)
                .HasConversion<string>();

            // Composite Key
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            // Relationships
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);

            // Call Seeds
            ActorSeed.Seed(modelBuilder);
            CategorySeed.Seed(modelBuilder);
            CinemaSeed.Seed(modelBuilder);
            MovieActorSeed.Seed(modelBuilder);
            MovieSeed.Seed(modelBuilder);
        }
    }
}
