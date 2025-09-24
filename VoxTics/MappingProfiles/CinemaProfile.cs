using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Filter;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.MappingProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            // --- Cinema -> CinemaVM (minimal info for lists) ---
            CreateMap<Cinema, CinemaVM>()
                .ForMember(dest => dest.DisplayImage,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.ImageUrl) ? src.ImageUrl : "/images/defaults/placeholder.jpg"))
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.Halls.Count))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count));

            // --- Cinema -> CinemaDetailsVM (full info) ---
            CreateMap<Cinema, CinemaDetailsVM>()
                .ForMember(dest => dest.DisplayImage,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.ImageUrl) ? src.ImageUrl : "/images/defaults/placeholder.jpg"))
                .ForMember(dest => dest.Halls, opt => opt.MapFrom(src => src.Halls))
                .ForMember(dest => dest.Showtimes, opt => opt.MapFrom(src => src.Showtimes))
                .ForMember(dest => dest.SocialMediaLinks, opt => opt.MapFrom(src => src.SocialMediaLinks));

            // --- Hall -> HallVM ---
            CreateMap<Hall, HallVM>()
                .ForMember(dest => dest.SeatCount, opt => opt.MapFrom(src => src.Seats.Count))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Seats.Count))
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name));

            // --- Showtime -> ShowtimeVM ---
            CreateMap<Showtime, ShowtimeVM>();

            // --- Booking -> BookingDetailsVM ---
            CreateMap<Booking, BookingDetailsVM>();

            // --- SocialMediaLink -> SocialMediaLinkVM ---
            CreateMap<SocialMediaLink, SocialMediaLinkVM>();
        }
    }
}
