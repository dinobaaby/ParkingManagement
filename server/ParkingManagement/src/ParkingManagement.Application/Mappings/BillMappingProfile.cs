
using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Mappings
{
    public class BillMappingProfile : Profile
    {
        public BillMappingProfile()
        {
            CreateMap<Bill, BillDto>()
                .ForMember(dest => dest.BillId, opt => opt.MapFrom(src => src.BillId))
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.TimeIn, opt => opt.MapFrom(src => src.TimeIn))
                .ForMember(dest => dest.TimeOut, opt => opt.MapFrom(src => src.TimeOut))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));


            CreateMap<BillDto, Bill>()
                .ForMember(dest => dest.BillId, opt => opt.MapFrom(src => src.BillId))
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                .ForMember(dest => dest.TimeIn, opt => opt.MapFrom(src => src.TimeIn))
                .ForMember(dest => dest.TimeOut, opt => opt.MapFrom(src => src.TimeOut))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
