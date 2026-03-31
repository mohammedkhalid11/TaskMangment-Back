using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskMangement.Data.Data;

namespace TaskMangement.Data.Configurations
{
    public static class DataConfiguration
    {
        public static IServiceCollection AddProjectDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // appsettings.json
            // services.AddDbContext<AppDbContext>(options =>
            // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // AppDbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(AppDbContext.DBConnectionString));

            return services;
        }
    }
}


