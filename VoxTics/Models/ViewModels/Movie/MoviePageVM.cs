using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Models.ViewModels.Movie
{
   
        public class MoviePageVM
        {
            // -------------------------
            // Filter & Sorting
            // -------------------------
            public string? SearchTerm { get; set; }
            public int? CategoryId { get; set; }
            public DateTime? ReleaseStartDate { get; set; }
            public DateTime? ReleaseEndDate { get; set; }

            public string? SortBy { get; set; } = "ReleaseDate";
            public SortOrder SortOrder { get; set; } = SortOrder.Asc;

            // -------------------------
            // Pagination
            // -------------------------
            public int PageIndex { get; set; } = 1;
            public int PageSize { get; set; } = 12;
            public int TotalPages { get; set; }
            public bool HasPreviousPage => PageIndex > 1;
            public bool HasNextPage => PageIndex < TotalPages;
            public List<int> PageNumbers { get; set; } = new List<int>();

            // -------------------------
            // Movies list
            // -------------------------
            public List<MovieVM> Movies { get; set; } = new List<MovieVM>();
        }
    }

