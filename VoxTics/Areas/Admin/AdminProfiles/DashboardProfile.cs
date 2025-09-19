using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Admin;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Areas.Admin.ViewModels.Booking;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Areas.Admin.MappingProfiles
{
    public class DashboardAdminProfile : Profile
    {
        public DashboardAdminProfile()
        {
            // Movie -> MovieListItemViewModel
            CreateMap<Movie, MovieListItemViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.MainImage))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category));

            // Cinema -> CinemaViewModel
            CreateMap<Cinema, CinemaViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Halls.Sum(h => h.SeatCount)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

            // Booking -> BookingViewModel
            CreateMap<Booking, BookingViewModel>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Showtime.Cinema.Name))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));

            // ApplicationUser -> ApplicationInfo (for dashboard recent users)
            CreateMap<ApplicationUser, PersonalInfoVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            // Optionally, you can map AdminDashboardViewModel if needed
            // but usually it's manually loaded via repository methods
        }
    }
}
