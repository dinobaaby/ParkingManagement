

using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Mappings
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
                
                .ForMember(dest => dest.TicketTypeId, opt => opt.MapFrom(src => src.TicketTypeId))
                .ForMember(dest => dest.SlotId, opt => opt.MapFrom(src => src.SlotId))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.TicketStatus, opt => opt.MapFrom(src => src.TicketStatus))
             .ForMember(dest => dest.VehicleImage, opt => opt.MapFrom(src => src.VehicleImage));

            CreateMap<TicketDto, Ticket>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.PlateNumber, opt => opt.MapFrom(src => src.PlateNumber))
               
                .ForMember(dest => dest.TicketTypeId, opt => opt.MapFrom(src => src.TicketTypeId))
                .ForMember(dest => dest.SlotId, opt => opt.MapFrom(src => src.SlotId))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.TicketStatus, opt => opt.MapFrom(src => src.TicketStatus))
                .ForMember(dest => dest.VehicleImage, opt => opt.MapFrom(src => src.VehicleImage));


        }
    }
}
