using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.DomainServices
{
    public static class DependencyInjectionV2
    {
        public static IServiceCollection AddDomainServicesV2(this IServiceCollection services)
        {
            // OrdersService is internal class. 
            // And it CAN NOT be public because it changes module contract.
            services.AddScoped<IOrdersServiceV2, OrdersServiceV2>();

            return services;
        }
    }
}
