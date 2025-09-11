using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VoxTics.Areas.Identity.MappingProfiles;
using VoxTics.MappingProfiles;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Implementations;
using VoxTics.Services.Interfaces;

namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Add services
            services.AddTransient<IEmailSender, EmailSender>();

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
            
            // Repository for Identity
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Add AutoMapper
            
            services.AddAutoMapper(typeof(MovieProfile).Assembly);

            // Add Helpers 

            return services;
        }
    }
}
