using Dotnext.Infrastructure.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.Infrastructure.Notifications.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}
