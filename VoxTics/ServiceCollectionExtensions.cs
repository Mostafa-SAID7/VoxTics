using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.MappingProfiles;
using VoxTics.Areas.Identity.MappingProfiles;
using VoxTics.Areas.Identity.Repositories;
using VoxTics.Areas.Identity.Repositories.IRepositories;

namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Add services
            services.AddTransient<IEmailSender, EmailSender>();
            
            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
            
            // Repository for Identity
            services.AddScoped<IUserRepository, UserRepository>();
            
            // Add AutoMapper
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            
            // Add Helpers 

            return services;
        }
    }
}
