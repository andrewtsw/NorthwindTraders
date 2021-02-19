using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Common.Interfaces;

namespace Northwind.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureNotifications(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            return services;
        }
    }
}
