using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.Enums;

namespace VoxTics.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }   // keep one "main poster" if needed
        [NotMapped]
        public List<IFormFile>? UploadedImages { get; set; }
        public string? TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; }

        // Foreign Keys
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Relations
        public ICollection<MovieActor> MovieActors { get; set; }

        // New: Multiple images
        public ICollection<MovieImg> MovieImgs { get; set; }= new List<MovieImg>();
    }
}
