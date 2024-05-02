
using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Mappings
{
    public class VehicleTypeMappingProfile : Profile
    {
        public VehicleTypeMappingProfile()
        {
            CreateMap<VehicleType, VehicleTypeDto>()
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
                .ForMember(dest => dest.VehicleTypeName, opt => opt.MapFrom(src => src.VehicleTypeName));

            CreateMap<VehicleTypeDto, VehicleType>()
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
                .ForMember(dest => dest.VehicleTypeName, opt => opt.MapFrom(src => src.VehicleTypeName));
        }
    }
}
