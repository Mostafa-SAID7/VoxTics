using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Data.Seeds
{
    public static class PaymentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, BookingId = 1, UserId = "user1", Amount = 20, Method = PaymentMethod.CreditCard, Status = PaymentStatus.Completed },
                new Payment { Id = 2, BookingId = 2, UserId = "user2", Amount = 30, Method = PaymentMethod.Paypal, Status = PaymentStatus.Pending }
            );
        }
    }
}
