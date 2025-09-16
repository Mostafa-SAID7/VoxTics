using AutoMapper;
using System;
using System.Linq;
using VoxTics.Areas.Admin.ViewModels.Showtime;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class ShowtimeAdminProfile : Profile
    {
        public ShowtimeAdminProfile()
        {
            // Showtime -> ShowtimeTableViewModel
            CreateMap<Showtime, ShowtimeTableViewModel>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.StartTime.AddMinutes(src.Duration)))
                .ForMember(dest => dest.StatusBadge, opt => opt.MapFrom(src =>
                    src.Status == ShowtimeStatus.Scheduled ? "badge bg-info" :
                    src.Status == ShowtimeStatus.Active ? "badge bg-success" :
                    src.Status == ShowtimeStatus.Cancelled ? "badge bg-danger" :
                    "badge bg-secondary"));

            // Showtime -> ShowtimeViewModel
            CreateMap<Showtime, ShowtimeViewModel>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.StartTime.AddMinutes(src.Duration)))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Hall.Seats.Count))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.Hall.Seats.Count - src.Bookings.Sum(b => b.BookingSeats.Count)))
                .ForMember(dest => dest.BookedUsers, opt => opt.MapFrom(src => src.Bookings.SelectMany(b => b.BookingSeats.Select(bs => bs.Booking.User.Name))))
                .ForMember(dest => dest.StatusBadge, opt => opt.MapFrom(src =>
                    src.Status == ShowtimeStatus.Scheduled ? "badge bg-info" :
                    src.Status == ShowtimeStatus.Active ? "badge bg-success" :
                    src.Status == ShowtimeStatus.Cancelled ? "badge bg-danger" :
                    "badge bg-secondary"));

            // ShowtimeCreateEditViewModel -> Showtime
            CreateMap<ShowtimeCreateEditViewModel, Showtime>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Is3D, opt => opt.MapFrom(src => src.Is3D))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.ScreenType, opt => opt.MapFrom(src => src.ScreenType))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
        }
    }
}
