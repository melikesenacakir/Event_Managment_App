using Core.Interfaces;
using Infra.Repositories;  
using Infra.Services.Concrete;

namespace Application.Extensions
{
    /// <summary>
    /// Application layer service registrations
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Add application services to DI container
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repository registrations
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            services.AddScoped<IFeedbackRepository, FeedbacksRepository>();
            services.AddScoped<IMessagesRepository, MessageRepository>();
            services.AddScoped<IHomepageRepository, HomepageRepository>();

            // Service registrations  
            services.AddScoped<IUsersService, UserServices>();
            services.AddScoped<IEventsService, EventsServices>();
            services.AddScoped<IFeedbackService, FeedbackServices>();
            services.AddScoped<IMessagesService, Message>();
            services.AddScoped<IHomepageService, HomepageService>();
            services.AddScoped<IAuthService, AuthServices>();
            services.AddScoped<IMiddlewareService, Middleware>();
            services.AddScoped<IRedisCacheService, RedisCacheService>();

            return services;
        }
    }
}