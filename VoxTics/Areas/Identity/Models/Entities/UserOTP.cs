using VoxTics.Areas.Identity.Models.Entities;
namespace VoxTics.Areas.Identity.Models.Entities
{
    public class UserOTP
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public string OTPNumber { get; set; } = string.Empty;
        public bool IsUsed { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
