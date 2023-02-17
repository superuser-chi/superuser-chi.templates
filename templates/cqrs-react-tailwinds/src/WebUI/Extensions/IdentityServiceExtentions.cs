using System.Text;
using Domain;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using WebUI.Authorization;
using WebUI.Services;

namespace WebUI.Extensions
{
    public static class IdentityServiceExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<CanteenSystemContext>();

            var secret = config.GetValue<string>("JwtSettings:Secret");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false,
                        };
                    });

            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

            services.AddScoped<TokenService>();



            return services;
        }
    }
}