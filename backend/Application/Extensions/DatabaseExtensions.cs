using Microsoft.EntityFrameworkCore;
using Infra.Database;

namespace Application.Extensions
{
    /// <summary>
    /// Database configuration extensions
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Add database services to DI container
        /// </summary>
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDB>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}