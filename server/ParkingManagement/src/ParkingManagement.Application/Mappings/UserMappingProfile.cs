using AutoMapper;
using ParkingManagement.Application.DTOs.Authentication;
using ParkingManagement.Domain.Entities.Authetication;


namespace ParkingManagement.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<ApplicationUser, UserDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.CardId));
        }

    }
}
