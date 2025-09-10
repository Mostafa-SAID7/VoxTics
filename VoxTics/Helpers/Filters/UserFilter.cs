using VoxTics.Areas.Identity.Models.Enums;
using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Helpers.Filters
{
    public class UserFilter : FilterBase<UserSortBy>
    {
        public UserRole? Role { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBanned { get; set; }
        public string? Email { get; set; }
        public DateTime? RegisteredFrom { get; set; }
        public DateTime? RegisteredTo { get; set; }
        public DateTime? LastLoginFrom { get; set; }
        public DateTime? LastLoginTo { get; set; }
    }
}
