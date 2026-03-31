using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskMangement.Data.Data;
using TaskMangement.Data.DTOs;
using TaskMangement.Data.Models;

namespace TaskMangement.API.Extensions
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configure Authentication
            services.Configure<JWT>(configuration.GetSection("JWT"));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            #endregion

            services.AddControllers();
            services.AddOpenApi();
            services.AddCors(options =>
            {
                options.AddPolicy("TaskMangementAPI", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            #region This section to enable project to use auth by jwt (Bearer jwtToken) 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            return services;
        }
    }
}