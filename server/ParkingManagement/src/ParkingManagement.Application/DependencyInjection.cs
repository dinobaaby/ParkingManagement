

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingManagement.Application.Mappings;

namespace ParkingManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
        {
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
