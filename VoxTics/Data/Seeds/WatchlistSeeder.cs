using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class WatchlistSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var watchlists = new List<Watchlist>
            {
                new Watchlist { Id = 1, UserId = "user1", Name = "Favorites" },
                new Watchlist { Id = 2, UserId = "user2", Name = "Must Watch" },
                new Watchlist { Id = 3, UserId = "user3", Name = "Weekend Picks" },
                new Watchlist { Id = 4, UserId = "user4", Name = "Top Movies" },
                new Watchlist { Id = 5, UserId = "user5", Name = "Action Collection" }
            };

            modelBuilder.Entity<Watchlist>().HasData(watchlists);
        }
    }
}
