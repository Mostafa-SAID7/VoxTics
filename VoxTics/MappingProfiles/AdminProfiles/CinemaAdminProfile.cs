using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles.AdminProfiles
{
    public class CinemaAdminProfile : Profile
    {
        public CinemaAdminProfile()
        {
            // Entity to ViewModel mappings
            CreateMap<Cinema, CinemaVM>()
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.Halls.Count))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Halls.Sum(h => h.SeatCount)));

            CreateMap<Cinema, CinemaViewModel>()
                .ForMember(dest => dest.HallCount, opt => opt.MapFrom(src => src.Halls.Count))
                .ForMember(dest => dest.TotalSeats, opt => opt.MapFrom(src => src.Halls.Sum(h => h.SeatCount)));

            CreateMap<Hall, HallVM>()
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name));

            CreateMap<Hall, HallViewModel>();

            // ViewModel to Entity mappings
            CreateMap<CinemaViewModel, Cinema>()
                .ForMember(dest => dest.Halls, opt => opt.Ignore())
                .ForMember(dest => dest.Showtimes, opt => opt.Ignore());

            CreateMap<CinemaVM, Cinema>()
                .ForMember(dest => dest.Halls, opt => opt.Ignore())
                .ForMember(dest => dest.Showtimes, opt => opt.Ignore());
        }
    }
}
