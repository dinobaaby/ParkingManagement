

using AutoMapper;

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
                config.AddProfile(new SlotMappingProfile());
                config.AddProfile(new VehicleTypeMappingProfile());
                config.AddProfile(new CustomerMappingProfile());
                config.AddProfile(new VehicleMappingProfile());
                config.AddProfile(new TicketMappingProfile());
                config.AddProfile(new BillMappingProfile());
                config.AddProfile(new PaymentMappingProfile());
            });


            return mappingConfig;
        }
    }
}
