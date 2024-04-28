

using AutoMapper;
using ParkingManagement.Application.DTOs.Accout;
using ParkingManagement.Application.DTOs.Authentication;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Application.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new AccoutMappingProfile());
                config.AddProfile(new UserMappingProfile());

            });


            return mappingConfig;
        }
    }
}
