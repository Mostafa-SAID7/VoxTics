using AutoMapper;
using System.Linq;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Showtime;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.MappingProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            // -------------------------
            // Cinema → CinemaVM (summary card view)
            // -------------------------
            CreateMap<Cinema, CinemaVM>()
                .ForMember(dest => dest.DisplayImage,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.ImageUrl)
                            ? src.ImageUrl
                            : "/images/default-cinema.jpg"))
                .ForMember(dest => dest.Country,
                    opt => opt.MapFrom(src => src.Country));

            // -------------------------
            // Cinema → CinemaDetailsVM (detailed view)
            // -------------------------
            CreateMap<Cinema, CinemaDetailsVM>()
                .ForMember(dest => dest.DisplayImage,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.ImageUrl)
                            ? src.ImageUrl
                            : "/images/default-cinema.jpg"))
                .ForMember(dest => dest.Halls,
                    opt => opt.MapFrom(src => src.Halls))
                .ForMember(dest => dest.Showtimes,
                    opt => opt.MapFrom(src => src.Showtimes))
               
                .ForMember(dest => dest.SocialMediaLinks,
                    opt => opt.MapFrom(src => src.SocialMediaLinks));
        }
    }
}
