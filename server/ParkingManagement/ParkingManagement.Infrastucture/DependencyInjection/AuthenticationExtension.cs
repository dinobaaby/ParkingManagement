

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ParkingManagement.Infrastucture.DependencyInjection
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddAuthenticationEx(this IServiceCollection services, IConfiguration config)
        {
            var jwtOptionsSection = config.GetSection("ApiSettings:JwtOptions");
            string secret = jwtOptionsSection["Secret"]!;
            string issuer = jwtOptionsSection["Issuer"]!;
            string audience = jwtOptionsSection["Audience"]!;

            var key = Encoding.UTF8.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidIssuer = issuer,
                ValidAudience = audience,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero

            };

            services.AddSingleton(tokenValidationParameters);

            return services;

        }
    }
}
