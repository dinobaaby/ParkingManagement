

using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Mappings
{
    public class SlotMappingProfile : Profile
    {
        public SlotMappingProfile() 
        {
            CreateMap<SlotDto, Slot>().ForMember(dest => dest.SlotId, otp => otp.MapFrom(src => src.SlotId)).ForMember(dest => dest.SlotName, otp => otp.MapFrom(src => src.SlotName)).ForMember(dest => dest.AreaId, otp => otp.MapFrom(src => src.AreaId));
        }

    }
}
