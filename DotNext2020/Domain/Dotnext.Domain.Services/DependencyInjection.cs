using Dotnext.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.Domain.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // OrdersService is internal class. 
            // But it CAN be public because there are no references to this project 
            // (except Composition Root - WebUI project)
            services.AddScoped<IOrdersService, OrdersService>();

            return services;
        }
    }
}
