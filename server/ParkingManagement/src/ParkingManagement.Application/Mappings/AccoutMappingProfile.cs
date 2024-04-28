

using AutoMapper;
using ParkingManagement.Application.DTOs.Accout;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Application.Mappings
{
    public class AccoutMappingProfile : Profile
    {
        public AccoutMappingProfile() 
        {
            CreateMap<ApplicationUser, AccountResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.CardId))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }

    }
}
