using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieEditVM
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        public string? ImgUrl { get; set; } // existing main image path
        public IFormFile? MainImage { get; set; }
        public List<IFormFile>? UploadedImages { get; set; }
        public string? TrailerUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Today;
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Today.AddMonths(1);

        public MovieStatus MovieStatus { get; set; } = MovieStatus.ComingSoon;

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int CinemaId { get; set; }

        // friendly names (if you want to display current values)
        public string? CategoryName { get; set; }
        public string? CinemaName { get; set; }

        // actors multi-select
        public List<int> SelectedActorIds { get; set; } = new List<int>();

        // selects for form dropdowns
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Cinemas { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Actors { get; set; } = Enumerable.Empty<SelectListItem>();

        // existing images
        public List<MovieImgVM> ExistingImages { get; set; } = new List<MovieImgVM>();
    }
}
