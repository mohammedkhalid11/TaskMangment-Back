using Microsoft.Extensions.DependencyInjection;
using TaskMangement.Service.IService;
using TaskMangement.Service.Service;

namespace TaskMangement.Service.Configurations;
public static class ServiceConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IITaskService, TaskService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IPriorityService, PriorityService>();
        services.AddScoped<IProjectMemberService, ProjectMemberService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskAssignmentService, TaskAssignmentService>();

        return services;
    }
}