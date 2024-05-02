

using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Mappings
{
    public class SlotMappingProfile : Profile
    {
        public SlotMappingProfile() 
        {
            CreateMap<Slot, SlotDto>()
                .ForMember(dest => dest.SlotId, otp => otp.MapFrom(src => src.SlotId))
                .ForMember(dest => dest.SlotName, otp => otp.MapFrom(src => src.SlotName))
                .ForMember(dest => dest.AreaId, otp => otp.MapFrom(src => src.AreaId))
                .ForMember(dest => dest.SlotType, otp => otp.MapFrom(src => src.SlotType));
        }

    }
}
