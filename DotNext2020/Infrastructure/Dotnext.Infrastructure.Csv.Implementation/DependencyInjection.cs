using Dotnext.Infrastructure.Csv.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnext.Infrastructure.Csv.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCsv(this IServiceCollection services)
        {
            services.AddScoped<ICsvFileBuilder, CsvFileBuilder>();

            return services;
        }
    }
}
