using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Admin form mapping
            CreateMap<Booking, BookingViewModel>().ReverseMap();

            // Public-facing mapping
            CreateMap<Booking, BookingVM>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.Showtime, opt => opt.MapFrom(src => src.Showtime.StartTime));
        }
    }
}
