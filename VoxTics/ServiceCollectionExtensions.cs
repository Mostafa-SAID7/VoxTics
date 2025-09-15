// ServiceCollectionExtensions.cs
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using VoxTics.Data;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Repositories;
using VoxTics.Repositories.IRepositories;

namespace VoxTics
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers application services: DbContext (optional), repositories, business services,
        /// AutoMapper scanning, email sender and other helpers.
        /// Uses reflection-based conditional registration for optional/missing concrete types.
        /// </summary>
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration,
            bool registerDbContextHere = true)
        {
            // logger factory for helpful warnings (can be used at runtime)
            services.AddLogging();

            if (registerDbContextHere)
            {
                services.AddDbContext<MovieDbContext>(opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            }

            // Unit of Work and generic base repository always registered
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // HttpContext accessor (commonly needed)
            services.AddHttpContextAccessor();

            // Configure SMTP options if present
            services.Configure<SmtpOptions>(configuration.GetSection("Smtp"));

            // Register email implementations if available
            TryRegisterTypePair(services, typeof(IEmailSender), "SmtpEmailSender");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.IEmailService", "SmtpEmailService");

            // Repositories: try to register known repository interfaces
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Repositories.IRepositories.IAdminBookingsRepository", "AdminBookingsRepository");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Repositories.IRepositories.IAdminCategoriesRepository", "AdminCategoriesRepository");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Repositories.IRepositories.IAdminCinemasRepository", "AdminCinemasRepository");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Repositories.IRepositories.IAdminMoviesRepository", "AdminMoviesRepository");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Repositories.IRepositories.IAdminShowtimesRepository", "AdminShowtimesRepository");

            TryRegisterTypePair(services, "VoxTics.Areas.Identity.Repositories.IRepositories.IApplicationUsersRepository", "ApplicationUsersRepository");
            TryRegisterTypePair(services, "VoxTics.Areas.Identity.Repositories.IRepositories.IApplicationUsersRepository", "ApplicationUsersRepository"); // duplicate safe

            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.IBookingsRepository", "BookingsRepository");
            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.IMoviesRepository", "MoviesRepository");
            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.ICategoriesRepository", "CategoriesRepository");
            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.ICinemasRepository", "CinemasRepository");
            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.IShowtimesRepository", "ShowtimesRepository");
            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.IDashboardRepository", "DashboardRepository");
            TryRegisterTypePair(services, "VoxTics.Repositories.IRepositories.IHomeRepository", "HomeRepository");

            // Business services: try to register interface -> implementation by naming convention
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.IBookingService", "VoxTics.Services.Implementations.BookingService");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.IMovieService", "VoxTics.Services.Implementations.MovieService");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.ICategoryService", "VoxTics.Services.Implementations.CategoryService");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.ICinemaService", "VoxTics.Services.Implementations.CinemaService");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.IShowtimeService", "VoxTics.Services.Implementations.ShowtimeService");
            TryRegisterTypePair(services, "VoxTics.Areas.Identity.Services.Interfaces.IAccountService", "VoxTics.Areas.Identity.Services.Implementations.AccountService");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.IHomeService", "VoxTics.Services.Implementations.HomeService");
            TryRegisterTypePair(services, "VoxTics.Services.Interfaces.IDashboardService", "VoxTics.Services.Implementations.DashboardService");

            // Admin services
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Services.Interfaces.IAdminBookingsService", "VoxTics.Areas.Admin.Services.Implementations.AdminBookingsService");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Services.Interfaces.IAdminCategoriesService", "VoxTics.Areas.Admin.Services.Implementations.AdminCategoriesService");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Services.Interfaces.IAdminCinemasService", "VoxTics.Areas.Admin.Services.Implementations.AdminCinemasService");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Services.Interfaces.IAdminMoviesService", "VoxTics.Areas.Admin.Services.Implementations.AdminMoviesService");
            TryRegisterTypePair(services, "VoxTics.Areas.Admin.Services.Interfaces.IAdminShowtimesService", "VoxTics.Areas.Admin.Services.Implementations.AdminShowtimesService");

            // AutoMapper: scan assemblies that contain your mapping profiles (adjust if profiles live elsewhere)
            var asmList = new[]
            {
                Assembly.GetExecutingAssembly(),
                typeof(Data.MovieDbContext).Assembly,
                // add more known assemblies if your profiles live in other projects:
                // typeof(YourProfileType).Assembly
            }.Distinct().ToArray();

            services.AddAutoMapper(asmList);

            return services;
        }

        /// <summary>
        /// Attempts to register interface (by Type) with implementation (by simple name) if implementation exists.
        /// Logs a warning if not found.
        /// </summary>
        private static void TryRegisterTypePair(IServiceCollection services, Type interfaceType, string implSimpleName)
        {
            var loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();
            var logger = loggerFactory?.CreateLogger("ServiceCollectionExtensions");

            var implType = FindTypeBySimpleName(implSimpleName);
            if (implType == null)
            {
                logger?.LogWarning("Implementation {Impl} not found for interface {Interface}. Skipping registration.", implSimpleName, interfaceType.FullName);
                return;
            }

            if (!interfaceType.IsAssignableFrom(implType))
            {
                logger?.LogWarning("Implementation {Impl} does not implement {Interface}. Skipping.", implSimpleName, interfaceType.FullName);
                return;
            }

            services.AddScoped(interfaceType, implType);
            logger?.LogInformation("Registered {Interface} -> {Impl}", interfaceType.FullName, implType.FullName);
        }

        /// <summary>
        /// Attempts to register interface (by full name string) with implementation (by full or simple name).
        /// </summary>
        private static void TryRegisterTypePair(IServiceCollection services, string interfaceFullName, string implementationFullOrSimpleName)
        {
            var loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();
            var logger = loggerFactory?.CreateLogger("ServiceCollectionExtensions");

            var interfaceType = FindTypeByFullName(interfaceFullName);
            if (interfaceType == null)
            {
                logger?.LogWarning("Interface {Interface} not found. Skipping registration for implementation {Impl}.", interfaceFullName, implementationFullOrSimpleName);
                return;
            }

            // Try full-name first, then simple-name
            var implType = FindTypeByFullName(implementationFullOrSimpleName) ?? FindTypeBySimpleName(implementationFullOrSimpleName);
            if (implType == null)
            {
                logger?.LogWarning("Implementation {Impl} not found for interface {Interface}. Skipping registration.", implementationFullOrSimpleName, interfaceFullName);
                return;
            }

            if (!interfaceType.IsAssignableFrom(implType))
            {
                logger?.LogWarning("Implementation {Impl} does not implement {Interface}. Skipping.", implType.FullName, interfaceType.FullName);
                return;
            }

            services.AddScoped(interfaceType, implType);
            logger?.LogInformation("Registered {Interface} -> {Impl}", interfaceType.FullName, implType.FullName);
        }

        /// <summary>
        /// Find a loaded type by exact full name.
        /// </summary>
        private static Type? FindTypeByFullName(string fullName)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => GetLoadableTypes(a))
                .FirstOrDefault(t => t.FullName != null && t.FullName.Equals(fullName, StringComparison.Ordinal));
        }

        /// <summary>
        /// Find a loaded type by simple name.
        /// </summary>
        private static Type? FindTypeBySimpleName(string simpleName)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => GetLoadableTypes(a))
                .FirstOrDefault(t => t.Name.Equals(simpleName, StringComparison.Ordinal));
        }

        /// <summary>
        /// Safely get loadable types from an assembly (avoids ReflectionTypeLoadException).
        /// </summary>
        private static Type[] GetLoadableTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null).Cast<Type>().ToArray();
            }
            catch
            {
                return Array.Empty<Type>();
            }
        }
    }
}
