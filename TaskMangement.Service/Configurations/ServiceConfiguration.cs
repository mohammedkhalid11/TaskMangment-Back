using Microsoft.Extensions.DependencyInjection;

namespace TaskMangement.Service.Configurations;
public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}