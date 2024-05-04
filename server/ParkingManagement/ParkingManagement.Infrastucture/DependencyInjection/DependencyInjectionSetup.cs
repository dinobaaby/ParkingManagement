



using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Utilities.Zlib;
using ParkingManagement.Application.Common.Interface.Authentication;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Infrastucture.Repos;


namespace ParkingManagement.Infrastucture.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;


                // lock accout
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;


                // confirm email before register
                options.User.RequireUniqueEmail = true;


                // options signi
                options.SignIn.RequireConfirmedEmail = true;
            });
            services.Configure<EmailSettings>(options =>
            {
                options.Email = configuration["EmailSettings:Email"]!;
                options.Password = configuration["EmailSettings:Password"]!;
                options.Host = configuration["EmailSettings:Host"]!;
                options.DisplayName = configuration["EmailSettings:DisplayName"]!;
                options.Port = int.Parse(configuration["EmailSettings:Port"]!);
            });

            services.Configure<JwtOptions>(options =>
            {
                options.Secret = configuration["ApiSettings:JwtOptions:Secret"]!;
                options.Audience = configuration["ApiSettings:JwtOptions:Audience"]!;
                options.Issuer = configuration["ApiSettings:JwtOptions:Issuer"]!;
            });

            services.AddAuthenticationEx(configuration);

            services.AddMemoryCache();


            // config life cycle
            services.AddScoped(typeof(IServiceRepo<,>), typeof(ServiceRepo<,>));
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITicketTypeService, TicketTypeService>();
            return services;
        }
    }
}
