using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.DomainServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // OrdersService is internal class. 
            // And it CAN NOT be public because it changes module contract.
            services.AddScoped<IOrdersService, OrdersService>();

            return services;
        }
    }
}
