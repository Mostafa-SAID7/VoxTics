using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Data.Seeds
{
    public static class ApplicationUserRoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var userRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    UserId = "admin",
                    RoleId = "role-admin"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user1",
                    RoleId = "role-user"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user2",
                    RoleId = "role-user"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user3",
                    RoleId = "role-user"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user4",
                    RoleId = "role-user"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user5",
                    RoleId = "role-user"
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
