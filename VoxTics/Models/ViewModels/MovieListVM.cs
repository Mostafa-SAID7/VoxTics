using System;
using System.Collections.Generic;
using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Models.ViewModels
{
    public class MovieListVM
    {
        // Movies to display
        public List<MovieVM> Movies { get; set; } = new List<MovieVM>();

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        // Filtering
        public string SearchTerm { get; set; } = string.Empty;
        public List<int> SelectedCategories { get; set; } = new List<int>();
        public MovieStatus? SelectedStatus { get; set; }
        public string? SelectedLanguage { get; set; }
        public string? SelectedRating { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        // Sorting
        public MovieSortBy SortBy { get; set; } = MovieSortBy.Title;
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;

        // Filter options for UI
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public Dictionary<MovieStatus, string> StatusOptions { get; set; } = new Dictionary<MovieStatus, string>
        {
            { MovieStatus.Upcoming, "Upcoming" },
            { MovieStatus.NowShowing, "Now Showing" },
            { MovieStatus.Ended, "Ended Showing" }
        };

        // Sort options for UI
        public Dictionary<string, string> SortOptions { get; set; } = new Dictionary<string, string>
        {
            { "Title", "Title" },
            { "ReleaseDate", "Release Date" },
            { "Price", "Price" },
            { "Duration", "Duration" }
        };
    }
}
