using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.MappingProfiles
{
    public class ShowtimeProfile : Profile
    {
        public ShowtimeProfile()
        {
            // -------- Showtime → ShowtimeVM --------
            CreateMap<Showtime, ShowtimeVM>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.MoviePoster, opt => opt.MapFrom(src => src.Movie.MainImage))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));

            // -------- Showtime → ShowtimePreviewVM --------
            CreateMap<Showtime, ShowtimeDetailsVM>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.MoviePosterImage, opt => opt.MapFrom(src => src.Movie.MainImage))
                .ForMember(dest => dest.MovieDuration, opt => opt.MapFrom(src => src.Movie.Duration))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.CinemaAddress, opt => opt.MapFrom(src => src.Cinema.Address))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall.Name))
                .ForMember(dest => dest.ShowDateTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.AvailableSeats));
        }
    }
}
