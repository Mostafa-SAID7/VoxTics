using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Data.Seeds
{
    public static class ApplicationRoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var roles = new[]
            {
                new ApplicationRole
                {
                    Id = "role-admin",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Id = "role-user",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<ApplicationRole>().HasData(roles);
        }
    }
}
