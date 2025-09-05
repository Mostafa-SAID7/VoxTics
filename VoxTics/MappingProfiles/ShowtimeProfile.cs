using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class ShowtimeProfile : Profile
    {
        public ShowtimeProfile()
        {
            // Public-facing VM
            CreateMap<Showtime, ShowtimeVM>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name));

            // Admin form VM
            CreateMap<Showtime, ShowtimeViewModel>().ReverseMap();
        }
    }
}
