using VoxTics.Models.Enums;

namespace VoxTics.Models.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ShortDescription
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Description)) return string.Empty;
                return Description.Length > 160 ? Description[..160] + "…" : Description;
            }
        }

        public string Description { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }

        public MovieStatus Status { get; set; } = MovieStatus.Upcoming;

        public decimal Price { get; set; }

        public int Duration { get; set; }

        public string? ImageUrl { get; set; }

        public List<CategoryItemVM> Categories { get; set; } = new();

        public IEnumerable<string>? Actors { get; set; }
    }
}
