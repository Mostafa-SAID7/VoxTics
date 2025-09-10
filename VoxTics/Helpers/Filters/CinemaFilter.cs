using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Helpers.Filters
{
    public class CinemaFilter : FilterBase<CinemaSortBy>
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool? IsActive { get; set; }
    }
}
