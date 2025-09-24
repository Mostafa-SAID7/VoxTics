using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Areas.Admin.ViewModels.Showtime;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class ShowtimeAdminProfile : Profile
    {
        public ShowtimeAdminProfile()
        {
            // Entity -> ViewModel (List)
            CreateMap<Showtime, ShowtimeViewModel>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.AvailableSeats))
                .ForMember(dest => dest.BookedUsers, opt => opt.MapFrom(src => src.Bookings.Select(b => b.User.Name)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));

            // Entity -> ViewModel (Details)
            CreateMap<Showtime, ShowtimeDetailsViewModel>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.BookedSeats, opt => opt.MapFrom(src => src.Bookings.Count))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.AvailableSeats))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.StartTime));

            // ViewModel (Create/Edit) -> Entity
            CreateMap<ShowtimeCreateEditViewModel, Showtime>()
                .ForMember(dest => dest.EndTime, opt => opt.Ignore()) // Computed in entity
                .ForMember(dest => dest.AvailableSeats, opt => opt.Ignore()) // Initialize separately
                .ForMember(dest => dest.Bookings, opt => opt.Ignore())
                .ForMember(dest => dest.CartItems, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0));

            // Entity -> ViewModel (Create/Edit) for editing scenario
            CreateMap<Showtime, ShowtimeCreateEditViewModel>()
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));
        }
    }
}
