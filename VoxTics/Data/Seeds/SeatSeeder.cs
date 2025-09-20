using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using System.Collections.Generic;

namespace VoxTics.Data.Seeds
{
    public static class SeatSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var seats = new List<Seat>();
            int seatId = 1;
            for (int hallId = 1; hallId <= 6; hallId++)
            {
                for (char row = 'A'; row <= 'E'; row++)
                {
                    for (int number = 1; number <= 10; number++)
                    {
                        seats.Add(new Seat
                        {
                            Id = seatId++,
                            HallId = hallId,
                            Row = row.ToString(),
                            NumberInRow = number,
                            SeatNumber = $"{row}{number}",
                            Type = SeatType.VIP,
                            IsActive = true,
                            IsAvailable = true
                        });
                    }
                }
            }
            modelBuilder.Entity<Seat>().HasData(seats);
        }
    }
}
