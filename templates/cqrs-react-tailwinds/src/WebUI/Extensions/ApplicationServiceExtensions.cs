// using Application.Audit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using WebUI.Core;

namespace WebUI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                     IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.UseAllOfForInheritance();

            });
            services.AddDbContext<CanteenSystemContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            services.AddHttpContextAccessor();

            // services.AddMediatR(typeof(GetAudits.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}