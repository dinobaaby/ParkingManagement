

using Microsoft.Extensions.Caching.Memory;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IServiceRepo<TicketType, int> _serviceRepo;
        private readonly IMemoryCache _cache;
        public TicketTypeService(IServiceRepo<TicketType, int> serviceRepo, IMemoryCache cache)
        {
            _serviceRepo = serviceRepo;
            _cache = cache;
        }

        public Task<TicketType> CreateTicketTypeAsync(TicketType ticketType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTicketTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketType>> GetAllTicketTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TicketType> GetTicketTypeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketType>> GetTicketTypesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTicketTypeAsync(TicketType ticketType)
        {
            throw new NotImplementedException();
        }
    }
}
