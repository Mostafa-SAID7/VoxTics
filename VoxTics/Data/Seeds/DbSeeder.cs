using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using System;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            ApplicationUserSeeder.Seed(modelBuilder);
            ActorSeeder.Seed(modelBuilder);
            CategorySeeder.Seed(modelBuilder);
            CinemaSeeder.Seed(modelBuilder);
            HallSeeder.Seed(modelBuilder);
            MovieSeeder.Seed(modelBuilder);
            ShowtimeSeeder.Seed(modelBuilder);
            SeatSeeder.Seed(modelBuilder);
            BookingSeeder.Seed(modelBuilder);
            BookingSeatSeeder.Seed(modelBuilder);
            PaymentSeeder.Seed(modelBuilder);
            CouponSeeder.Seed(modelBuilder);
            WatchlistSeeder.Seed(modelBuilder);
        }
    }

}
