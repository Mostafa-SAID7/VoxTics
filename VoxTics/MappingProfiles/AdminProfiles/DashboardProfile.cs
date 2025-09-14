using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using VoxTics.Areas.Admin.ViewModels.Booking;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Areas.Admin.ViewModels.Movie;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.MappingProfiles.AdminProfiles
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            // Movies mapping
            CreateMap<Movie, MovieListItemViewModel>().ReverseMap();

            // Bookings mapping
            CreateMap<Booking, BookingViewModel>().ReverseMap();

            // Users mapping
            CreateMap<ApplicationUser, ApplicationInfo>().ReverseMap();

            // Cinemas mapping
            CreateMap<Cinema, CinemaViewModel>().ReverseMap();
        }
    }
}
