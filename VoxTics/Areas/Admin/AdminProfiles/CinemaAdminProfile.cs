using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.Entities;
using System.Linq;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class CinemaAdminProfile : Profile
    {
        public CinemaAdminProfile()
        {
            // -------------------
            // Cinema -> Create/Edit VM
            // -------------------
            CreateMap<Cinema, CinemaCreateEditViewModel>()
                .ForMember(dest => dest.ImageFile, opt => opt.Ignore()) // file upload handled separately
                .ReverseMap(); // Allows creating/updating Cinema from form

            // -------------------
            // Cinema -> Details VM
            // -------------------
            CreateMap<Cinema, CinemaDetailsViewModel>()
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.TotalSeats))
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.HallCount))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.ShowtimeCount))
                .ForMember(dest => dest.Halls, opt => opt.MapFrom(src => src.Halls.Select(h => h.Name)))
                .ForMember(dest => dest.Showtimes, opt => opt.MapFrom(src => src.Showtimes.Select(s => s.Movie.Title)))
                .ForMember(dest => dest.SocialMediaLinks, opt => opt.MapFrom(src => src.SocialMediaLinks.Select(s => s.Url)));

            // -------------------
            // Cinema -> Index/List VM
            // -------------------
            CreateMap<Cinema, CinemaViewModel>()
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.TotalSeats))
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.HallCount))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.ShowtimeCount))
                .ForMember(dest => dest.DisplayImage, opt => opt.MapFrom(src => src.DisplayImage));
        }
    }
}
