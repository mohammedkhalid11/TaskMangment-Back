using Microsoft.Extensions.DependencyInjection;
using TaskMangement.Service.IService;
using TaskMangement.Service.Service;

namespace TaskMangement.Service.Configurations;
public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}