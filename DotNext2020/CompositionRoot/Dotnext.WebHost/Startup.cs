using Dotnext.Application;
using Dotnext.Application.Services.Implementation;
using Dotnext.Domain.Services;
using Dotnext.Infrastructure.Csv.Implementation;
using Dotnext.Infrastructure.Host.Interfaces;
using Dotnext.Infrastructure.Notifications.Implementation;
using Dotnext.Infrastructure.Persistence.Implementation;
using Dotnext.WebHost.Common;
using Dotnext.WebHost.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnext.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Domain
            services.AddDomainServices();

            // Infrastructure
            services.AddCsv();
            services.AddNotifications();
            services.AddPersistence(Configuration);
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            // Application
            services.AddApplication();
            services.AddApplicationServices();

            // Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
