using Microsoft.EntityFrameworkCore;
using VoxTics.Models.Entities;

namespace VoxTics.Data.Seeds
{
    public static class CouponSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, Code = "DISC10", DiscountPercentage = 10, IsActive = true },
                new Coupon { Id = 2, Code = "DISC20", DiscountPercentage = 20, IsActive = true }
            );
        }
    }
}
