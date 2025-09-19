using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.Enums;

namespace VoxTics.Data.Seeds
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(MovieDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            await context.Database.EnsureCreatedAsync().ConfigureAwait(false);

            // Check if database has been seeded
            if (context.Movies.Any())
            {
                return; // Database has been seeded
            }

            await SeedCinemasAndHallsAsync(context).ConfigureAwait(false);
            await SeedMoviesAsync(context).ConfigureAwait(false);
            await SeedShowtimesAsync(context).ConfigureAwait(false);
            await SeedUsersAsync(context).ConfigureAwait(false);
        }

        private static async Task SeedCinemasAndHallsAsync(MovieDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var cinemas = new List<Cinema>
            {
                new Cinema
                {
                    Name = "Mega Cinema Mall",
                    Address = "Shopping Mall, Level 3",
                    City = "Downtown",
                    Phone = "555-0789",
                    Email = "info@megacinema.com",
                    Description = "Modern cinema with latest technology",
                    IsActive = true
                }
            };

            context.Cinemas.AddRange(cinemas);
            await context.SaveChangesAsync().ConfigureAwait(false);

            var cinema = context.Cinemas.First();
            var halls = new List<Hall>
            {
                new Hall { CinemaId = cinema.Id, Name = "Hall A", TotalSeats = 100, IsActive = true },
                new Hall { CinemaId = cinema.Id, Name = "Hall B", TotalSeats = 80, IsActive = true },
                new Hall { CinemaId = cinema.Id, Name = "Hall C", TotalSeats = 120, IsActive = true }
            };

            context.Halls.AddRange(halls);
            await context.SaveChangesAsync().ConfigureAwait(false);

            // Add seats for each hall
            foreach (var hall in halls)
            {
                var seats = new List<Seat>();
                var rows = hall.TotalSeats <= 80 ? 8 : hall.TotalSeats <= 100 ? 10 : 12;
                var seatsPerRow = hall.TotalSeats / rows;

                for (int row = 1; row <= rows; row++)
                {
                    for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                    {
                        seats.Add(new Seat
                        {
                            HallId = hall.Id,
                            SeatNumber = $"{(char)('A' + row - 1)}{seatNum}",
                            RowNumber = row,
                            SeatNumberInRow = seatNum,
                            Type = row <= 2 ? SeatType.Premium : SeatType.VIP,
                            IsActive = true
                        });
                    }
                }
                context.Seats.AddRange(seats);
            }
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        private static async Task SeedMoviesAsync(MovieDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "Avengers: Endgame",
                    Description = "The grave course of events set in motion by Thanos that wiped out half the universe...",
                    Duration = 181,
                    ReleaseDate = new DateTime(2019, 4, 26),
                    Director = "Anthony Russo, Joe Russo",
                    Language = "English",
                    Country = "USA",
                    Rating = 8,
                    Status = MovieStatus.NowShowing,
                    MainImage = "/images/movies/avengers-endgame.jpg"
                },
                new Movie
                {
                    Title = "The Lion King",
                    Description = "A young lion prince is cast out of his pride by his cruel uncle...",
                    Duration = 118,
                    ReleaseDate = new DateTime(2019, 7, 19),
                    Director = "Jon Favreau",
                    Language = "English",
                    Country = "USA",
                    Rating = 6,
                    Status = MovieStatus.NowShowing,
                    MainImage = "/images/movies/lion-king.jpg"
                }
            };

            context.Movies.AddRange(movies);
            await context.SaveChangesAsync().ConfigureAwait(false);

            // Link movies with categories and actors
            var actionCategory = context.Categories.First(c => c.Name == "Action");
            var animationCategory = context.Categories.First(c => c.Name == "Animation");

            var movieCategories = new List<MovieCategory>
            {
                new MovieCategory { MovieId = movies[0].Id, CategoryId = actionCategory.Id },
                new MovieCategory { MovieId = movies[1].Id, CategoryId = animationCategory.Id }
            };

            context.MovieCategories.AddRange(movieCategories);
            await context.SaveChangesAsync().ConfigureAwait(false);

            var actors = context.Actors.ToList();
            var movieActors = new List<MovieActor>
            {
                new MovieActor { MovieId = movies[0].Id, ActorId = actors[0].Id },
                new MovieActor { MovieId = movies[0].Id, ActorId = actors[1].Id },
                new MovieActor { MovieId = movies[0].Id, ActorId = actors[2].Id }
            };

            context.MovieActors.AddRange(movieActors);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        private static async Task SeedShowtimesAsync(MovieDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var movies = context.Movies.ToList();
            var cinemas = context.Cinemas.ToList();
            var halls = context.Halls.ToList();

            var showtimes = new List<Showtime>();
            var startDate = DateTime.Today;

            foreach (var movie in movies)
            {
                foreach (var cinema in cinemas)
                {
                    var cinemaHalls = halls.Where(h => h.CinemaId == cinema.Id).ToList();

                    for (int day = 0; day < 7; day++)
                    {
                        var showDate = startDate.AddDays(day);
                        var showTimes = new[] { "10:00", "13:00", "16:00", "19:00", "22:00" };

                        foreach (var timeStr in showTimes)
                        {
                            if (TimeSpan.TryParse(timeStr, out var time))
                            {
                                var hall = cinemaHalls[new Random().Next(cinemaHalls.Count)];
                                showtimes.Add(new Showtime
                                {
                                    MovieId = movie.Id,
                                    HallId = hall.Id,
                                    StartTime = showDate.Add(time),
                                    Price = 12.50m + (decimal)(new Random().NextDouble() * 5),
                                    Status = ShowtimeStatus.Scheduled
                                });
                            }
                        }
                    }
                }
            }

            context.Showtimes.AddRange(showtimes);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        private static async Task SeedUsersAsync(MovieDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEH3QhLhFhBpz9Kpx8qHiuZs1kJ2sNFKJCyKGXUwNdU9u6Vp8IJ1aGk3K3wIZl4M5QQ==",
                    PhoneNumber = "555-0001",
                },
                new ApplicationUser
                {
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEH3QhLhFhBpz9Kpx8qHiuZs1kJ2sNFKJCyKGXUwNdU9u6Vp8IJ1aGk3K3wIZl4M5QQ==",
                    PhoneNumber = "555-0002",
                },
                new ApplicationUser
                {
                    Name = "Mike Manager",
                    Email = "manager@cinema.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEH3QhLhFhBpz9Kpx8qHiuZs1kJ2sNFKJCyKGXUwNdU9u6Vp8IJ1aGk3K3wIZl4M5QQ==",
                    PhoneNumber = "555-0003",
                }
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
