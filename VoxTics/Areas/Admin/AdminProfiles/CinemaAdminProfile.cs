using AutoMapper;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class CinemaAdminProfile : Profile
    {
        public CinemaAdminProfile()
        {
            // Cinema -> CinemaViewModel
            CreateMap<Cinema, CinemaViewModel>()
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.Halls.Count))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Halls.Sum(h => h.Seats.Count)))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count))
                .ForMember(dest => dest.Showtimes, opt => opt.MapFrom(src => src.Showtimes.Select(st => new ShowtimeVM
                {
                    Id = st.Id,
                    MovieTitle = st.Movie.Title,
                    ShowDateTime = st.StartTime
                })))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ImageUrl) ? "/images/default-cinema.jpg" : src.ImageUrl));

            // Cinema -> CinemaTableViewModel
            CreateMap<Cinema, CinemaTableViewModel>()
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.Halls.Count))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Halls.Sum(h => h.Seats.Count)))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count))
                .ForMember(dest => dest.StatusBadge, opt => opt.MapFrom(src => src.IsActive ? "badge bg-success" : "badge bg-secondary"));

            // Cinema -> CinemaDetailsViewModel
            CreateMap<Cinema, CinemaDetailsViewModel>()
                .ForMember(dest => dest.Halls, opt => opt.MapFrom(src => src.Halls.Select(h => h.Name)))
                .ForMember(dest => dest.Showtimes, opt => opt.MapFrom(src => src.Showtimes.Select(st => st.Movie.Title)))
                .ForMember(dest => dest.SocialMediaLinks, opt => opt.MapFrom(src => src.SocialMediaLinks.Select(s => s.Url)))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Halls.Sum(h => h.Seats.Count)))
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.Halls.Count))
                .ForMember(dest => dest.ShowtimeCount, opt => opt.MapFrom(src => src.Showtimes.Count))
                .ForMember(dest => dest.DisplayImage, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ImageUrl) ? "/images/default-cinema.jpg" : src.ImageUrl))
                .ForMember(dest => dest.StatusBadge, opt => opt.MapFrom(src => src.IsActive ? "badge bg-success" : "badge bg-secondary"));

            // CinemaCreateEditViewModel -> Cinema
            CreateMap<CinemaCreateEditViewModel, Cinema>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
