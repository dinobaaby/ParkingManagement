
using Microsoft.AspNetCore.Http;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTicketsAsync();
        Task<IEnumerable<TicketDto>> GetTicketsByTypeAsync(int ticketType);
        Task<IEnumerable<TicketDto>> GetTicketsByStatusAsync(int ticketStatus);
        Task<IEnumerable<TicketDto>> GetTicketsByPlateNumberAsync(string plateNumber);
        Task<IEnumerable<TicketDto>> GetTicketsBySlotIdAsync(int slotId);
        Task<TicketDto> GetTicketByIdAsync(int ticketId);
        Task<TicketDto> CreateTicketAsync(TicketDto ticketDto, IFormFile file);
        Task<TicketDto> UpdateTicketAsync(TicketDto ticketDto);
        Task<TicketDto> DeleteTicketAsync(int ticketId);
        Task<TicketDto> CheckInAsync(int ticketId, string plateNumber, IFormFile file);
        Task<object> CheckOutAsync(int ticketId, string plateNumber, string imageUrl);
    }
}
