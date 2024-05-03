

using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Services
{
    public interface ITicketTypeService
    {
        Task<IEnumerable<TicketType>> GetAllTicketTypesAsync();

        Task<IEnumerable<TicketType>> GetTicketTypesByNameAsync(string name);
        Task<TicketType> GetTicketTypeByIdAsync(int id);
        Task<TicketType> CreateTicketTypeAsync(TicketType ticketType);

        Task<bool> DeleteTicketTypeAsync(int id);
        Task<bool> UpdateTicketTypeAsync(TicketType ticketType);
    }
}
