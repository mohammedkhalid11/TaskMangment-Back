namespace TaskMangement.API.Extensions
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("TaskMangementAPI", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
