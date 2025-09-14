using System;
using System.Collections.Generic;
using VoxTics.Models.Enums.Sorting;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class CinemaPageVM
    {
        // -------------------------
        // Cinema info
        // -------------------------
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Website { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public int TotalHalls { get; set; }
        public int TotalSeats { get; set; }
        public int TotalShowtimes { get; set; }

        public string DisplayImage => !string.IsNullOrEmpty(ImageUrl) ? ImageUrl! : "/images/default-cinema.jpg";

        // -------------------------
        // Filter & Sorting for Showtimes
        // -------------------------
        public DateTime? FilterStartDate { get; set; }
        public DateTime? FilterEndDate { get; set; }
        public string? SortBy { get; set; } = "StartTime";
        public SortOrder SortOrder { get; set; } = SortOrder.Asc;

        // -------------------------
        // Pagination
        // -------------------------
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<int> PageNumbers { get; set; } = new List<int>();

        // -------------------------
        // Showtimes
        // -------------------------
        public List<ShowtimePreviewVM> Showtimes { get; set; } = new List<ShowtimePreviewVM>();
    }
}
