using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class CinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Country { get; set; }
        public string DisplayImage { get; set; } = "/images/default-cinema.jpg";


    }
}
