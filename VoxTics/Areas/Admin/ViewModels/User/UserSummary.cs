using VoxTics.Areas.Identity.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.User
{
    public class UserSummary
    {
        public string UserId { get; set; } = string.Empty;   // IdentityUser uses string keys by default
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
