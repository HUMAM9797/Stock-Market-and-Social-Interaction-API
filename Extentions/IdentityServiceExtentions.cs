using System.Text;
using Entities;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Extentions;

public static class IdentityServiceExtentions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentity<AppUser,IdentityRole>( options =>{
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase =true;
            options.Password.RequiredLength = 12;
            options.Password.RequireNonAlphanumeric = true;
        }
        ).AddEntityFrameworkStores<AppDbContext>();

        services.AddAuthentication(options =>
        {
        options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
        options.DefaultForbidScheme=
        options.DefaultScheme =
        options.DefaultSignInScheme=
        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }
        ).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = config["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = config["JWT:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["JWT:SigningKey"]))
            };
        });
        return services;
    }
}
