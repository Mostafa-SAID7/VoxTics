using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VoxTics.Repositories.Implementations;
using VoxTics.Repositories.Interfaces;

namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IShowtimeRepository, ShowtimeRepository>();

            // Add AutoMapper
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
