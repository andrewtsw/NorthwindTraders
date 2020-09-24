using Dotnext.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.Application.Services.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionsManager, PermissionsManager>();

            return services;
        }
    }
}
