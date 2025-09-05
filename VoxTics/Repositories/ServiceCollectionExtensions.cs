using Microsoft.Extensions.DependencyInjection;
using VoxTics.Repositories.Implementations;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVoxTicsRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>)); // optional: register generic base
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            return services;
        }
    }
}
