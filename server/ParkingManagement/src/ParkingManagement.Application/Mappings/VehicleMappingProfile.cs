

using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Mappings
{
    public class VehicleMappingProfile : Profile
    {
        public VehicleMappingProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.VehicleColor, opt => opt.MapFrom(src => src.VehicleColor))
                .ForMember(dest => dest.VehiclePlateNumber, opt => opt.MapFrom(src => src.VehiclePlateNumber))
                .ForMember(dest => dest.VehicleImage, opt => opt.MapFrom(src => src.VehicleImage))
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));


            CreateMap<VehicleDto, Vehicle>()
                 .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.VehicleColor, opt => opt.MapFrom(src => src.VehicleColor))
                .ForMember(dest => dest.VehiclePlateNumber, opt => opt.MapFrom(src => src.VehiclePlateNumber))
                .ForMember(dest => dest.VehicleImage, opt => opt.MapFrom(src => src.VehicleImage))
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));
        }
    }
}
